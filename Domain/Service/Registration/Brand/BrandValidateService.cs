using Domain.DTO.Entity.Brand;
using Domain.Interface.Service.Brand;
using Domain.Service.Base;
using Domain.Utils.Helper;

namespace Domain.Service.Registration.Brand
{
    public class BrandValidateService : BaseValidateService<BrandValidateDTO>, IBrandValidateService
    {
        public void Create(List<BrandValidateDTO> listValidateDTO)
        {
            NotificationBuilder.CreateDictionary();

            ValidateNullDTO(listValidateDTO);

            (from i in RemoveIgnore(listValidateDTO)
             let validateInvalidLengthCode = InvalidLengthValidation(i, "Code", "InputCreate", 1, 6)
             let validateInvalidLengthDescription = InvalidLengthValidation(i, "Description", "InputCreate", 1, 100)
             let validateRepeatedCode = RepeatedCodeValidation(i, "Code", "InputCreate")
             let validateAlreadyExistingCode = AlreadyExistingCodeValidation(i, "Code", "InputCreate")
             select true).ToList();

            (from i in RemoveInvalid(listValidateDTO)
             select CreateSuccessNotification(i.InputCreate!.Code, i.InputCreate!.Description)).ToList();
        }

        public void Update(List<BrandValidateDTO> listValidateDTO)
        {
            NotificationBuilder.CreateDictionary();

            ValidateNullDTO(listValidateDTO);

            (from i in RemoveIgnore(listValidateDTO)
             let validateInvalidLengthCode = InvalidLengthValidation(i, "Code", "InputUpdate", 1, 6)
             let validateInvalidLengthDescription = InvalidLengthValidation(i, "Description", "InputUpdate", 1, 100)
             let validateRepeatedCode = RepeatedCodeValidation(i, "Code", "InputUpdate")
             let validateAlreadyExistingCode = AlreadyExistingCodeValidation(i, "Code", "InputUpdate")
             let validateExistingOriginalEntity = ExistingOriginalEntityValidation(i, "Code")
             select true).ToList();

            (from i in RemoveInvalid(listValidateDTO)
             select UpdateSuccessNotification(i.InputUpdate.Code, i.InputUpdate.Description)).ToList();
        }

        public void Delete(List<BrandValidateDTO> listBrandValidateDTO)
        {
            NotificationBuilder.CreateDictionary();

            ValidateNullDTO(listBrandValidateDTO);

            (from i in RemoveIgnore(listBrandValidateDTO)
             where i.OriginalBrandId == default
             let setInvalid = i.SetInvalid()
             select OriginalNotFound(i.InputIdentityDeleteBrand.Id)).ToList();

            (from i in RemoveInvalid(listBrandValidateDTO)
             select DeleteSuccessNotification(i.InputIdentityDeleteBrand!.Id.ToString())).ToList();
        }
    }
}