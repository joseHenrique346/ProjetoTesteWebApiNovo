using Arguments.Argument.Registration.Brand;
using Domain.DTO.Entity.Brand;
using Domain.Interface.Service.Brand;
using Domain.Service.Base;
using Domain.Utils.Helper;

namespace Domain.Service.Registration.Brand
{
    public class BrandValidateService : BaseValidateService<BrandValidateDTO, InputCreateBrand, InputUpdateBrand, InputIdentityDeleteBrand>, IBrandValidateService
    {
        public void Create(List<BrandValidateDTO> listBrandValidateDTO)
        {
            NotificationBuilder.CreateDictionary();

            ValidateNullDTO(listBrandValidateDTO);

            ValidateNullInput(listBrandValidateDTO);

            ValidateNullCode(listBrandValidateDTO);

            (from i in RemoveIgnore(listBrandValidateDTO)
             let validateAlreadyExistingCode = AlreadyExistingCodeValidation(i, "Code")
             let validateRepeatedCode = RepeatedCodeValidation(i, "Code")
             let validateInvalidLengthCode = InvalidLengthValidation(i, "Code", "Code", 1, 6)
             let validateInvalidLengthDescription = InvalidLengthValidation(i, "Description", "Code", 1, 100)
             select true).ToList();

            (from i in RemoveInvalid(listBrandValidateDTO)
             select CreateSuccessNotification(i.InputCreate!.Code, i.InputCreate!.Description)).ToList();
        }

        public void Update(List<BrandValidateDTO> listBrandValidateDTO)
        {
            NotificationBuilder.CreateDictionary();

            ValidateNullDTO(listBrandValidateDTO);

            ValidateNullInput(listBrandValidateDTO);

            ValidateNullCode(listBrandValidateDTO);

            (from i in RemoveIgnore(listBrandValidateDTO)
             let validateExistingOriginalEntity = ExistingOriginalEntityValidation(i, "Code")
             let validateRepeatedCode = RepeatedCodeValidation(i, "Code")
             let validateInvalidLengthCode = InvalidLengthValidation(i, "Code", "Code", 1, 6)
             let validateInvalidLengthDescription = InvalidLengthValidation(i, "Description", "Code", 1, 100)
             let validateAlreadyExistingCode = AlreadyExistingCodeValidation(i, "Code")
             select true).ToList();

            (from i in RemoveInvalid(listBrandValidateDTO)
             select UpdateSuccessNotification(i.InputUpdate!.Code, i.InputUpdate.Description)).ToList();
        }

        public void Delete(List<BrandValidateDTO> listBrandValidateDTO)
        {
            NotificationBuilder.CreateDictionary();

            ValidateNullDTO(listBrandValidateDTO);

            (from i in RemoveIgnore(listBrandValidateDTO)
             where i.OriginalBrandId == default
             let setInvalid = i.SetInvalid()
             select OriginalNotFound((i.InputIdentityDelete!.Id).ToString(), i.InputIdentityDelete.Id)).ToList();

            (from i in RemoveInvalid(listBrandValidateDTO)
             select DeleteSuccessNotification(i.InputIdentityDelete!.Id.ToString())).ToList();
        }
    }
}