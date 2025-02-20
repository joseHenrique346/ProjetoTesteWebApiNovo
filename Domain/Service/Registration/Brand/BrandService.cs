using Arguments.Argument.Base.ApiResponse;
using Arguments.Argument.Registration.Brand;
using Arguments.Conversor;
using Domain.DTO.Entity.Brand;
using Domain.Interface.Repository;
using Domain.Interface.Service.Brand;
using Domain.Service.Base;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

            var listNewBrand = (from i in listInputCreateBrand
                                select new
                                {
                                    InputCreateBrand = i,
                                    RepeatedCode = selectedListOriginalBrandDTO.FirstOrDefault(j => i.Code == j)
                                }).ToList();
            List<BrandValidateDTO> listBrandValidateDTO = listNewBrand.Select(i => new BrandValidateDTO().ValidateCreate(i.InputCreateBrand, i.RepeatedCode)).ToList();
            _validate.Create(listBrandValidateDTO);

            var (success, error) = GetValidationResult();

            if (success.Count == 0 && error.Count > 0)
                return BaseResult<List<OutputBrand>>.Failure(error);

            var validlistBrand = (from i in RemoveInvalid(listBrandValidateDTO) where !i.Invalid select i).ToList();
            var newListBrand = (from i in validlistBrand select new BrandDTO(i.InputCreateBrand.Code, i.InputCreateBrand.Description)).ToList();

            await _repository.Create(newListBrand);

            return BaseResult<List<OutputBrand>>.Success(Conversor.GenericConvertList<OutputBrand, BrandDTO>(newListBrand), success);
        }

        public override async Task<BaseResult<List<OutputBrand>>> UpdateMultiple(List<InputIdentityUpdateBrand> listInputIdentityUpdateBrand)
        {
            var listOriginalBrandDTO = await _repository.GetListByListId(listInputIdentityUpdateBrand.Select(i => i.Id).ToList());

            var listBrandToUpdate = (from i in listInputIdentityUpdateBrand
                                     select new
                                     {
                                         InputIdentityUpdateBrand = i,
                                         OriginalBrand = listOriginalBrandDTO.FirstOrDefault(j => i.Id == j.Id)
                                     }).ToList();

            List<BrandValidateDTO> listBrandValidateDTO = listBrandToUpdate.Select(i => new BrandValidateDTO().ValidateUpdate(i.InputIdentityUpdateBrand, i.OriginalBrand)).ToList();

            _validate.Update(listBrandValidateDTO);

            var (success, error) = GetValidationResult();

            if (success.Count == 0 && error.Count > 0)
                return BaseResult<List<OutputBrand>>.Failure(error);

            var validlistBrand = (from i in RemoveInvalid(listBrandValidateDTO) where !i.Invalid select i).ToList();

            var originalBrandUpdated = (from i in validlistBrand
                                        from j in listOriginalBrandDTO
                                        where j.Id == i.InputIdentityUpdateBrand.Id
                                        let inputUpdate = i.InputIdentityUpdateBrand.InputUpdateBrand
                                        let description = j.Description = inputUpdate.Description
                                        let code = j.Code = inputUpdate.Code
                                        select j).ToList();

            await _repository.Update(originalBrandUpdated);

            var outputOriginalBrandUpdated = Conversor.GenericConvertList<OutputBrand, BrandDTO>(originalBrandUpdated);
            return BaseResult<List<OutputBrand>>.Success(outputOriginalBrandUpdated, success);
        }

        public override async Task<BaseResult<bool>> DeleteMultiple(List<InputIdentityDeleteBrand> listInputIdentityDeleteBrand)
        {
            var listOriginalBrandDTO = await _repository.GetAll();
            var selectedListOriginalBrandDTO = listOriginalBrandDTO.Select(i => i.Id).ToList();

            var listBrandToDelete = (from i in listInputIdentityDeleteBrand
                                     select new
                                     {
                                         InputIdentityDeleteBrand = i,
                                         OriginalBrand = selectedListOriginalBrandDTO.FirstOrDefault(j => j == i.Id)
                                     }).ToList();

            var listBrandValidateDTO = listBrandToDelete.Select(i => new BrandValidateDTO().ValidateDelete(i.InputIdentityDeleteBrand, i.OriginalBrand)).ToList();
            _validate.Delete(listBrandValidateDTO);

            var (success, error) = GetValidationResult();

            if (success.Count == 0 && error.Count > 0)
                return BaseResult<bool>.Failure(error);

            var validlistDeleteBrand = (from i in RemoveInvalid(listBrandValidateDTO) where !i.Invalid select i).ToList();
            var listBrandDTO = Conversor.GenericConvertList<BrandDTO, BrandValidateDTO>(validlistDeleteBrand);

            await _repository.Delete(listBrandDTO);

            return BaseResult<bool>.Success(true, success);
        }
    }
}