using Arguments.Argument.Enum;
using Domain.DTO.Entity.Brand;
using Domain.Interface.Service.Brand;
using Domain.Service.Base;
using Domain.Utils.Helper;

namespace Domain.Service.Registration.Brand
{
    public class BrandValidateService : BaseValidateService<BrandValidateDTO>, IBrandValidateService
    {
        public void Create(List<BrandValidateDTO> listBrandValidateDTO)
        {
            NotificationBuilder.CreateDictionary();

            ValidateNullDTO(listBrandValidateDTO);

            InvalidLengthValidation(listBrandValidateDTO, "Code", "Code", "InputCreate", 1, 6);

            InvalidLengthValidation(listBrandValidateDTO, "Code", "Description", "InputCreate", 1, 100);

            (from i in RemoveIgnore(listBrandValidateDTO)
             where i.ExistingCode != null
             let setInvalid = i.SetInvalid()
             select AlreadyExists(i.InputCreate!.Code)).ToList();

            (from i in RemoveIgnore(listBrandValidateDTO)
             where i.RepeatedCode != null
             let setInvalid = i.SetInvalid()
             select RepeatedCode(i.InputCreate!.Code)).ToList();

            (from i in RemoveInvalid(listBrandValidateDTO)
             select CreateSuccessNotification(i.InputCreate!.Code, i.InputCreate!.Description)).ToList();
        }

        public void Update(List<BrandValidateDTO> listBrandValidateDTO)
        {
            NotificationBuilder.CreateDictionary();

            ValidateNullDTO(listBrandValidateDTO);

            (from i in RemoveIgnore(listBrandValidateDTO)
             let code = i.InputIdentityUpdateBrand.InputUpdateBrand!.Code
             let resultInvalidLength = InvalidLength(code, 1, 6)
             where resultInvalidLength != EnumValidateType.Valid
             let setInvalid = i.SetInvalid()
             select InvalidLength(code, nameof(code), 1, 6)).ToList();

            (from i in RemoveIgnore(listBrandValidateDTO)
             let description = i.InputIdentityUpdateBrand.InputUpdateBrand!.Description
             let resultInvalidLength = InvalidLength(description, 1, 100)
             where resultInvalidLength != EnumValidateType.Valid
             let setInvalid = i.SetInvalid()
             select InvalidLength(description, nameof(description), 1, 100)).ToList();

            (from i in RemoveIgnore(listBrandValidateDTO)
             where i.ExistingCode == null
             let setInvalid = i.SetInvalid()
             select AlreadyExists(i.InputIdentityUpdateBrand.InputUpdateBrand!.Code)).ToList();

            (from i in RemoveIgnore(listBrandValidateDTO)
             where i.RepeatedCode != null
             let setInvalid = i.SetInvalid()
             select RepeatedCode(i.InputIdentityUpdateBrand.InputUpdateBrand!.Code)).ToList();

            (from i in RemoveIgnore(listBrandValidateDTO)
             where i.OriginalBrand == null
             let setIgnore = i.SetIgnore()
             select OriginalNotFound(i.InputIdentityUpdateBrand.Id)).ToList();

            (from i in RemoveInvalid(listBrandValidateDTO)
             select CreateSuccessNotification(i.InputIdentityUpdateBrand!.InputUpdateBrand.Code, i.InputIdentityUpdateBrand!.InputUpdateBrand.Description)).ToList();
        }

        public void Delete(List<BrandValidateDTO> listBrandValidateDTO)
        {
            NotificationBuilder.CreateDictionary();

            ValidateNullDTO(listBrandValidateDTO);

            (from i in RemoveIgnore(listBrandValidateDTO)
             where i.OriginalBrand == default
             let setInvalid = i.SetInvalid()
             select OriginalNotFound(i.InputIdentityDeleteBrand.Id)).ToList();

            (from i in RemoveInvalid(listBrandValidateDTO)
             select CreateSuccessNotification(i.InputIdentityDeleteBrand!.Id.ToString())).ToList();
        }
    }
}