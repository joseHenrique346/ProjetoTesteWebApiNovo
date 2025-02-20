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

            (from i in RemoveIgnore(listBrandValidateDTO)
             where listBrandValidateDTO == null
             let setIgnore = i.SetIgnore()
             select Invalid(listBrandValidateDTO.IndexOf(i))).ToList();

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
             where i.OriginalBrand != null
             let setInvalid = i.SetInvalid()
             select AlreadyExists(i.InputCreateBrand!.Code, EnumValidateType.Invalid)).ToList();

            (from i in RemoveInvalid(listBrandValidateDTO)
             select AddSuccessMessage(i.InputCreateBrand!.Code, NotificationMessagesKey.SuccesfullyCreatedKey)).ToList();
        }

        public void Update(List<BrandValidateDTO> listBrandValidateDTO)
        {
            NotificationHelper.CreateNewDictionary();

            (from i in RemoveIgnore(listBrandValidateDTO)
             where listBrandValidateDTO == null
             let setIgnore = i.SetIgnore()
             select Invalid(listBrandValidateDTO.IndexOf(i))).ToList();

            (from i in RemoveIgnore(listBrandValidateDTO)
             let resultInvalidLenght = InvalidLenght(i.InputCreateBrand!.Code, 1, 6)
             where resultInvalidLenght != EnumValidateType.Valid
             let setInvalid = i.SetInvalid()
             select InvalidLenght(i.InputCreateBrand.Code, resultInvalidLenght, nameof(i.InputCreateBrand.Code), 1, 6)).ToList();

            (from i in RemoveIgnore(listBrandValidateDTO)
             let resultInvalidLenght = InvalidLenght(i.InputCreateBrand!.Description, 1, 100)
             where resultInvalidLenght != EnumValidateType.Valid
             let setInvalid = i.SetInvalid()
             select InvalidLenght(i.InputCreateBrand.Description, resultInvalidLenght, nameof(i.InputCreateBrand.Description), 1, 100)).ToList();

            (from i in RemoveIgnore(listBrandValidateDTO)
             where i.OriginalBrand == null
             let setIgnore = i.SetIgnore()
             select Invalid(listBrandValidateDTO.IndexOf(i))).ToList();

            (from i in RemoveInvalid(listBrandValidateDTO)
             select AddSuccessMessage((i.InputIdentityUpdateBrand!.Id).ToString(), NotificationMessagesKey.SuccesfullyUpdatedKey)).ToList();
        }

        public void Delete(List<BrandValidateDTO> listBrandValidateDTO)
        {
            (from i in RemoveIgnore(listBrandValidateDTO)
             where listBrandValidateDTO == null
             let setIgnore = i.SetIgnore()
             select Invalid(listBrandValidateDTO.IndexOf(i))).ToList();

            (from i in RemoveIgnore(listBrandValidateDTO)
             where i.OriginalBrand == default
             let setInvalid = i.SetInvalid()
             select Invalid(listBrandValidateDTO.IndexOf(i))).ToList();

            (from i in RemoveInvalid(listBrandValidateDTO)
             select AddSuccessMessage((i.InputIdentityDeleteBrand!.Id).ToString(), NotificationMessagesKey.SuccesfullyDeletedKey)).ToList();
        }
    }
}