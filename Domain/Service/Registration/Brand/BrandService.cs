using Arguments.Argument.Base.ApiResponse;
using Arguments.Argument.Enum;
using Arguments.Argument.Registration.Brand;
using Arguments.Conversor;
using Domain.DTO.Entity.Brand;
using Domain.Interface.Repository;
using Domain.Interface.Service.Brand;
using Domain.Service.Base;
using Domain.Utils.Helper;

namespace Domain.Service.Registration.Brand
{
    public class BrandService : BaseService<BrandDTO, IBrandRepository, InputIdentityViewBrand, InputCreateBrand, InputUpdateBrand, InputIdentityUpdateBrand, InputIdentityDeleteBrand, BrandValidateDTO, OutputBrand>, IBrandService
    {
        private readonly IBrandValidateService _validate;
        private readonly IBrandRepository _repository;
        public BrandService(IBrandRepository repository, IBrandValidateService validate) : base(repository)
        {
            _repository = repository;
            _validate = validate;
        }

        public override async Task<BaseResult<List<OutputBrand>>> CreateMultiple(List<InputCreateBrand> listInputCreateBrand)
        {
            var listOriginalBrandDTO = await _repository.GetAll();
            var selectedListOriginalBrandDTO = listOriginalBrandDTO.Select(i => i.Code);

            var repeatedCode = (from i in listInputCreateBrand
                                where listInputCreateBrand.Count(j => j.Code == i.Code) > 1
                                select i).ToList();

            var newListInputBrandToValidate = (from i in listInputCreateBrand
                                               select new
                                               {
                                                   InputCreate = i,
                                                   ExistingCode = selectedListOriginalBrandDTO.FirstOrDefault(j => i.Code == j),
                                                   RepeatedCode = repeatedCode.FirstOrDefault(j => i.Code == j.Code)
                                               }).ToList();

            List<BrandValidateDTO> listBrandValidateDTO = newListInputBrandToValidate.Select(i => new BrandValidateDTO().ValidateCreate(i.InputCreate, i.ExistingCode, i.RepeatedCode)).ToList();
            _validate.Create(listBrandValidateDTO);

            var listNotification = NotificationBuilder.GetAll();

            if (listNotification.Where(i => i.Type == EnumNotificationType.Error).ToList().Count > 0 && listNotification.Where(i => i.Type == EnumNotificationType.Success).ToList().Count == 0)
                return BaseResult<List<OutputBrand>>.Failure(listNotification);

            var validlistBrand = (from i in RemoveInvalid(listBrandValidateDTO) where !i.Invalid select i).ToList();

            var ListBrandToCreate = (from i in validlistBrand
                                     select new BrandDTO(i.InputCreate.Code, i.InputCreate.Description)).ToList();

            var listNewBrand = await _repository.Create(ListBrandToCreate);

            return BaseResult<List<OutputBrand>>.Success(Conversor.GenericConvertList<OutputBrand, BrandDTO>(listNewBrand), listNotification);
        }

        public override async Task<BaseResult<List<OutputBrand>>> UpdateMultiple(List<InputIdentityUpdateBrand> listInputIdentityUpdateBrand)
        {
            var listOriginalBrandDTO = await _repository.GetListByListId(listInputIdentityUpdateBrand.Select(i => i.Id).ToList());

            var repeatedCode = (from i in listInputIdentityUpdateBrand
                                where listInputIdentityUpdateBrand.Count(j => j.InputUpdateBrand.Code == i.InputUpdateBrand.Code) > 1
                                select i).ToList();

            var listInputOriginalIdentifiers = listInputIdentityUpdateBrand.Select(i => i.Id).ToList();

            var newListBrandToValidate = (from i in listInputIdentityUpdateBrand
                                          select new
                                          {
                                              InputIdentity = i,
                                              InputUpdate = i.InputUpdateBrand,
                                              InputOriginalEntityId = listInputOriginalIdentifiers.FirstOrDefault(),
                                              OriginalEntity = listOriginalBrandDTO.FirstOrDefault(j => i.Id == j.Id)?.Id ?? 0,
                                              ExistingCode = listOriginalBrandDTO?.FirstOrDefault(j => i.InputUpdateBrand.Code != j.Code)?.Code ?? null,
                                              RepeatedCode = repeatedCode.FirstOrDefault()
                                          }).ToList();

            List<BrandValidateDTO> listBrandValidateDTO = newListBrandToValidate.Select(i => new BrandValidateDTO().ValidateUpdate(i.InputUpdate, i.OriginalEntity, i.ExistingCode, i.RepeatedCode, i.InputOriginalEntityId)).ToList();

            _validate.Update(listBrandValidateDTO);

            var listNotification = NotificationBuilder.GetAll();

            if (listNotification.Where(i => i.Type == EnumNotificationType.Error).ToList().Count > 0 && listNotification.Where(i => i.Type == EnumNotificationType.Success).ToList().Count == 0)
                return BaseResult<List<OutputBrand>>.Failure(listNotification);

            var validlistBrand = (from i in RemoveInvalid(listBrandValidateDTO) where !i.Invalid select i).ToList();

            (from i in validlistBrand
             select UpdateDTO<BrandDTO, InputUpdateBrand>(i.OriginalEntity, i.InputUpdate)).ToList();

            var originalBrandToUpdate = validlistBrand.Select(i => i.OriginalEntity).ToList();

            await _repository.Update(originalBrandToUpdate);

            return BaseResult<List<OutputBrand>>.Success(Conversor.GenericConvertList<OutputBrand, BrandDTO>(originalBrandToUpdate), listNotification);
        }

        public override async Task<BaseResult<bool>> DeleteMultiple(List<InputIdentityDeleteBrand> listInputIdentityDeleteBrand)
        {
            var listOriginalBrandDTO = await _repository.GetAll();
            var selectedListOriginalBrandDTO = listOriginalBrandDTO.Select(i => i.Id).ToList();

            var newListBrandToValidate = (from i in listInputIdentityDeleteBrand
                                          select new
                                          {
                                              InputIdentityDeleteBrand = i,
                                              OriginalBrand = selectedListOriginalBrandDTO.FirstOrDefault(j => j == i.Id)
                                          }).ToList();

            var listBrandValidateDTO = newListBrandToValidate.Select(i => new BrandValidateDTO().ValidateDelete(i.InputIdentityDeleteBrand, i.OriginalBrand)).ToList();
            _validate.Delete(listBrandValidateDTO);

            var listNotification = NotificationBuilder.GetAll();

            if (listNotification.Where(i => i.Type == EnumNotificationType.Error).ToList().Count > 0 && listNotification.Where(i => i.Type == EnumNotificationType.Success).ToList().Count == 0)
                return BaseResult<bool>.Failure(listNotification);

            var newValidBrandList = (from i in RemoveInvalid(listBrandValidateDTO) where !i.Invalid select i).ToList();
            var listBrandDTOToDelete = Conversor.GenericConvertList<BrandDTO, BrandValidateDTO>(newValidBrandList);

            await _repository.Delete(listBrandDTOToDelete);

            return BaseResult<bool>.Success(true, listNotification);
        }
    }
}