using Arguments.Argument.Base.ApiResponse;
using Arguments.Argument.Enum;
using Arguments.Argument.Registration.Category;
using Arguments.Conversor;
using Domain.DTO.Entity.Category;
using Domain.Interface.Repository;
using Domain.Interface.Service.Category;
using Domain.Service.Base;
using Domain.Utils.Helper;

namespace Domain.Service.Registration.Category
{
    public class CategoryService : BaseService<CategoryDTO, ICategoryRepository, InputIdentityViewCategory, InputCreateCategory, InputUpdateCategory, InputIdentityUpdateCategory, InputIdentityDeleteCategory, CategoryValidateDTO, OutputCategory>, ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly ICategoryValidateService _validate;
        public CategoryService(ICategoryRepository repository, ICategoryValidateService validate) : base(repository)
        {
            _validate = validate;
            _repository = repository;
        }

        public override async Task<BaseResult<List<OutputCategory>>> CreateMultiple(List<InputCreateCategory> listInputCreateCategory)
        {
            var listOriginalCategoryDTO = await _repository.GetAll();
            var selectedListOriginalCategoryDTO = listOriginalCategoryDTO.Select(i => i.Code);

            var listNewCategory = (from i in listInputCreateCategory
                                   select new
                                   {
                                       InputCreateCategory = i,
                                       RepeatedCode = selectedListOriginalCategoryDTO.FirstOrDefault(j => i.Code == j)
                                   }).ToList();
            List<CategoryValidateDTO> listCategoryValidateDTO = listNewCategory.Select(i => new CategoryValidateDTO().ValidateCreate(i.InputCreateCategory, i.RepeatedCode)).ToList();
            _validate.Create(listCategoryValidateDTO);

            var listNotification = NotificationBuilder.GetAll();

            if (listNotification.Where(i => i.Type == EnumNotificationType.Error).ToList().Count > 0 && listNotification.Where(i => i.Type == EnumNotificationType.Success).ToList().Count == 0)
                return BaseResult<List<OutputCategory>>.Failure(listNotification);

            var validlistCategory = (from i in RemoveInvalid(listCategoryValidateDTO) where !i.Invalid select i).ToList();
            var newListCategory = (from i in validlistCategory select new CategoryDTO(i.InputCreateCategory.Code, i.InputCreateCategory.Description)).ToList();

            await _repository.Create(newListCategory);

            return BaseResult<List<OutputCategory>>.Success(Conversor.GenericConvertList<OutputCategory, CategoryDTO>(newListCategory), listNotification);
        }

        public override async Task<BaseResult<List<OutputCategory>>> UpdateMultiple(List<InputIdentityUpdateCategory> listInputIdentityUpdateCategory)
        {
            var listOriginalCategoryDTO = await _repository.GetListByListId(listInputIdentityUpdateCategory.Select(i => i.Id).ToList());

            var listCategoryToUpdate = (from i in listInputIdentityUpdateCategory
                                        select new
                                        {
                                            InputUpdate = i.InputUpdateCategory,
                                            OriginalCategory = listOriginalCategoryDTO.FirstOrDefault(j => i.Id == j.Id)
                                        }).ToList();

            List<CategoryValidateDTO> listCategoryValidateDTO = listCategoryToUpdate.Select(i => new CategoryValidateDTO().ValidateUpdate(i.InputUpdate, i.OriginalCategory)).ToList();

            _validate.Update(listCategoryValidateDTO);

            var listNotification = NotificationBuilder.GetAll();

            if (listNotification.Where(i => i.Type == EnumNotificationType.Error).ToList().Count > 0 && listNotification.Where(i => i.Type == EnumNotificationType.Success).ToList().Count == 0)
                return BaseResult<List<OutputCategory>>.Failure(listNotification);

            var validlistCategory = (from i in RemoveInvalid(listCategoryValidateDTO) where !i.Invalid select i).ToList();

            (from i in validlistCategory
             select UpdateDTO<CategoryDTO, InputUpdateCategory>(i.OriginalCategory, i.InputUpdate)).ToList();

            var originalCategoryListToUpdate = validlistCategory.Select(i => i.OriginalCategory).ToList();

            await _repository.Update(originalCategoryListToUpdate!);

            var outputOriginalCategoryUpdated = Conversor.GenericConvertList<OutputCategory, CategoryDTO>(originalCategoryListToUpdate!);
            return BaseResult<List<OutputCategory>>.Success(outputOriginalCategoryUpdated, listNotification);
        }

        public override async Task<BaseResult<bool>> DeleteMultiple(List<InputIdentityDeleteCategory> listInputIdentityDeleteCategory)
        {
            var listOriginalCategoryDTO = await _repository.GetAll();
            var selectedListOriginalCategoryDTO = listOriginalCategoryDTO.Select(i => i.Id).ToList();

            var listCategoryToDelete = (from i in listInputIdentityDeleteCategory
                                        select new
                                        {
                                            InputIdentityDeleteCategory = i,
                                            OriginalCategoryId = selectedListOriginalCategoryDTO.FirstOrDefault(j => j == i.Id)
                                        }).ToList();

            var listCategoryValidateDTO = listCategoryToDelete.Select(i => new CategoryValidateDTO().ValidateDelete(i.InputIdentityDeleteCategory, i.OriginalCategoryId)).ToList();
            _validate.Delete(listCategoryValidateDTO);

            var listNotification = NotificationBuilder.GetAll();

            if (listNotification.Where(i => i.Type == EnumNotificationType.Error).ToList().Count > 0 && listNotification.Where(i => i.Type == EnumNotificationType.Success).ToList().Count == 0)
                return BaseResult<bool>.Failure(listNotification);

            var validlistDeleteCategory = (from i in RemoveInvalid(listCategoryValidateDTO) where !i.Invalid select i).ToList();
            var listCategoryDTO = Conversor.GenericConvertList<CategoryDTO, CategoryValidateDTO>(validlistDeleteCategory);

            await _repository.Delete(listCategoryDTO);

            return BaseResult<bool>.Success(true, listNotification);
        }

        public Task<List<CategoryDTO>> GetListByListId(List<InputIdentityViewCategory> listInputIdentityView)
        {
            throw new NotImplementedException();
        }
    }
}