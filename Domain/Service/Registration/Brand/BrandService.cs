using Arguments.Argument.Base.ApiResponse;
using Arguments.Argument.Enum;
using Arguments.Argument.Registration.Brand;
using Arguments.Conversor;
using Domain.DTO.Entity.Brand;
using Domain.Interface.Repository;
using Domain.Interface.Service;
using Domain.Service.Base;
using Domain.Utils.Helper;
using System.Security.Cryptography;

namespace Domain.Service.Registration.Brand
{
    public class BrandService : BaseService<BrandDTO, IBrandRepository, InputIdentityViewBrand, InputCreateBrand, InputUpdateBrand, InputIdentityUpdateBrand, InputIdentityDeleteBrand, BrandValidateDTO, OutputBrand>
    {
        private readonly IBrandValidateService _validate;
        public BrandService(IBrandRepository repository, IBrandValidateService validate) : base(repository)
        {
            validate = _validate;
        }

        public override async Task<BaseResult<List<OutputBrand>>> CreateMultiple(List<InputCreateBrand> listInputCreateBrand)
        {
            var listOriginalBrandDTO = await GetAll();

            var listNewBrand = (from i in listInputCreateBrand
                                select new
                                {
                                    InputCreateBrand = i,
                                    RepeatedCode = listOriginalBrandDTO.FirstOrDefault(j => i.Code == j.Code).Code
                                }).ToList();
            List<BrandValidateDTO> listBrandValidateDTO = listNewBrand.Select(i => new BrandValidateDTO().ValidateCreate(i.InputCreateBrand, i.RepeatedCode)).ToList();
            _validate.Create(listBrandValidateDTO);

            List<DetailedNotification> success = [];
            List<DetailedNotification> error = [];

            foreach (var i in listBrandValidateDTO)
            {
                (success, error) = GetValidationResult(i.InputCreateBrand.Code);
            }

            if (error.Count == listInputCreateBrand.Count)
                return BaseResult<List<OutputBrand>>.Failure(error);

            var validlistBrand = (from i in RemoveInvalid(listBrandValidateDTO) where !i.Invalid select i).ToList();
            var newListBrand = (from i in validlistBrand select new BrandDTO(i.InputCreateBrand.Code, i.InputCreateBrand.Description)).ToList();
            return BaseResult<List<OutputBrand>>.Success(Conversor.GenericConvertList<OutputBrand, BrandDTO>(newListBrand), success);
        }

        public override async Task<BaseResult<List<OutputBrand>>> UpdateMultiple(List<InputIdentityUpdateBrand> listInputIdentityUpdateBrand)
        {
            var listOriginalBrandDTO = await GetListByListId(listInputIdentityUpdateBrand.Select(i => i.Id).ToList());

            var listBrandToUpdate = (from i in listInputIdentityUpdateBrand
                                     select new
                                     {
                                         InputIdentityUpdateBrand = i,
                                         OriginalBrand = listOriginalBrandDTO.FirstOrDefault(j => i.Id == j.Id)
                                     }).ToList();

            List<BrandValidateDTO> listBrandValidateDTO = listBrandToUpdate.Select(i => new BrandValidateDTO().ValidateUpdate(i.InputIdentityUpdateBrand, i.OriginalBrand)).ToList();

            List<DetailedNotification> success = [];
            List<DetailedNotification> error = [];

            _validate.Update(listBrandValidateDTO);
            foreach (var i in listBrandValidateDTO)
            {
                (success, error) = GetValidationResult(i.InputUpdateBrand.Code);
            }

            if (error.Count == listInputIdentityUpdateBrand.Count)
                return BaseResult<List<OutputBrand>>.Failure(error);

            var validlistBrand = (from i in RemoveInvalid(listBrandValidateDTO) where !i.Invalid select i).ToList();

            var originalBrandUpdated = (from i in validlistBrand
                                        from j in listOriginalBrandDTO
                                        where j.Id == i.InputIdentityUpdateBrand.Id
                                        let inputUpdate = i.InputIdentityUpdateBrand.InputUpdateBrand
                                        let description = j.Description = inputUpdate.Description
                                        let code = j.Code = inputUpdate.Code
                                        select j).ToList();

            var outputOriginalBrandUpdated = Conversor.GenericConvertList<OutputBrand, BrandDTO>(originalBrandUpdated);
            return BaseResult<List<OutputBrand>>.Success(outputOriginalBrandUpdated, success);
        }

        public override BaseResult<bool> DeleteMultiple(List<InputIdentityDeleteBrand> listInputIdentityDeleteBrand)
        {
            throw new NotImplementedException();
        }
    }
}