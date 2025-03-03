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
            NotificationHelper.CreateNewDictionary();

            ValidateNullDTO(listBrandValidateDTO);

            (from i in RemoveIgnore(listBrandValidateDTO)
             let resultInvalidLenght = InvalidLenght(i.InputCreateBrand!.Code, 1, 6)
             where resultInvalidLenght != EnumValidateType.Valid
             let setInvalid = i.SetInvalid()
             select InvalidLenght(i.InputCreateBrand.Code, resultInvalidLenght, nameof(i.InputCreateBrand.Code), 1, 6)).ToList();

            (from i in RemoveIgnore(listBrandValidateDTO)
             let resultInvalidLenght = InvalidLenght(i.InputCreateBrand!.Description, 1, 100)
             where resultInvalidLenght != EnumValidateType.Valid
             let setInvalid = i.SetInvalid()
             select InvalidLenght(i.InputCreateBrand.Code, resultInvalidLenght, nameof(i.InputCreateBrand.Description), 1, 100)).ToList();

            (from i in RemoveIgnore(listBrandValidateDTO)
             where i.ExistingCode != null
             let setInvalid = i.SetInvalid()
             select AlreadyExists(i.InputCreateBrand!.Code, EnumValidateType.Invalid)).ToList();

            (from i in RemoveIgnore(listBrandValidateDTO)
             where i.RepeatedCode != null
             let setInvalid = i.SetInvalid()
             select RepeatedCode(i.InputCreateBrand!.Code, EnumValidateType.Invalid)).ToList();

            (from i in RemoveInvalid(listBrandValidateDTO)
             select AddSuccessMessage(i.InputCreateBrand!.Code, NotificationMessagesKey.SuccesfullyCreatedKey)).ToList();
        }

        public void Update(List<BrandValidateDTO> listBrandValidateDTO)
        {
            NotificationHelper.CreateNewDictionary();

            ValidateNullDTO(listBrandValidateDTO);

            (from i in RemoveIgnore(listBrandValidateDTO)
             let code = i.InputIdentityUpdateBrand.InputUpdateBrand!.Code
             let resultInvalidLenght = InvalidLenght(code, 1, 6)
             where resultInvalidLenght != EnumValidateType.Valid
             let setInvalid = i.SetInvalid()
             select InvalidLenght(code, resultInvalidLenght, nameof(code), 1, 6)).ToList();

            (from i in RemoveIgnore(listBrandValidateDTO)
             let description = i.InputIdentityUpdateBrand.InputUpdateBrand!.Description
             let resultInvalidLenght = InvalidLenght(description, 1, 100)
             where resultInvalidLenght != EnumValidateType.Valid
             let setInvalid = i.SetInvalid()
             select InvalidLenght(description, resultInvalidLenght, nameof(description), 1, 100)).ToList();

            (from i in RemoveIgnore(listBrandValidateDTO)
             where i.ExistingCode == null
             let setInvalid = i.SetInvalid()
             select AlreadyExists(i.InputIdentityUpdateBrand.InputUpdateBrand!.Code, EnumValidateType.Invalid)).ToList();

            (from i in RemoveIgnore(listBrandValidateDTO)
             where i.RepeatedCode != null
             let setInvalid = i.SetInvalid()
             select RepeatedCode(i.InputIdentityUpdateBrand.InputUpdateBrand!.Code, EnumValidateType.Invalid)).ToList();

            (from i in RemoveIgnore(listBrandValidateDTO)
             where i.OriginalBrand == null
             let setIgnore = i.SetIgnore()
             select Invalid(listBrandValidateDTO.IndexOf(i))).ToList();

            (from i in RemoveInvalid(listBrandValidateDTO)
             select AddSuccessMessage((i.InputIdentityUpdateBrand!.Id).ToString(), NotificationMessagesKey.SuccesfullyUpdatedKey)).ToList();
        }

        public void Delete(List<BrandValidateDTO> listBrandValidateDTO)
        {
            ValidateNullDTO(listBrandValidateDTO);

            (from i in RemoveIgnore(listBrandValidateDTO)
             where i.OriginalBrand == default
             let setInvalid = i.SetInvalid()
             select Invalid(listBrandValidateDTO.IndexOf(i))).ToList();

            (from i in RemoveInvalid(listBrandValidateDTO)
             select AddSuccessMessage((i.InputIdentityDeleteBrand!.Id).ToString(), NotificationMessagesKey.SuccesfullyDeletedKey)).ToList();
        }
    }
}