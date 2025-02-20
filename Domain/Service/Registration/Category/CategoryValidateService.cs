using Arguments.Argument.Enum;
using Domain.DTO.Entity.Category;
using Domain.Interface.Service.Category;
using Domain.Service.Base;
using Domain.Utils.Helper;

namespace Domain.Service.Registration.Category
{
    public class CategoryValidateService : BaseValidateService<CategoryValidateDTO>, ICategoryValidateService
    {
        public void Create(List<CategoryValidateDTO> listCategoryValidateDTO)
        {
            NotificationHelper.CreateNewDictionary();

            (from i in RemoveIgnore(listCategoryValidateDTO)
             where listCategoryValidateDTO == null
             let setIgnore = i.SetIgnore()
             select Invalid(listCategoryValidateDTO.IndexOf(i))).ToList();

            (from i in RemoveIgnore(listCategoryValidateDTO)
             let resultInvalidLenght = InvalidLenght(i.InputCreateCategory!.Code, 1, 6)
             where resultInvalidLenght != EnumValidateType.Valid
             let setInvalid = i.SetInvalid()
             select InvalidLenght(i.InputCreateCategory.Code, resultInvalidLenght, nameof(i.InputCreateCategory.Code), 1, 6)).ToList();

            (from i in RemoveIgnore(listCategoryValidateDTO)
             let resultInvalidLenght = InvalidLenght(i.InputCreateCategory!.Description, 1, 100)
             where resultInvalidLenght != EnumValidateType.Valid
             let setInvalid = i.SetInvalid()
             select InvalidLenght(i.InputCreateCategory.Code, resultInvalidLenght, nameof(i.InputCreateCategory.Description), 1, 100)).ToList();

            (from i in RemoveIgnore(listCategoryValidateDTO)
             where i.RepeatedCode != null
             let setInvalid = i.SetInvalid()
             select AlreadyExists(i.InputCreateCategory!.Code, EnumValidateType.Invalid)).ToList();

            (from i in RemoveInvalid(listCategoryValidateDTO)
             select AddSuccessMessage(i.InputCreateCategory!.Code, NotificationMessagesKey.SuccesfullyCreatedKey)).ToList();
        }

        public void Update(List<CategoryValidateDTO> listCategoryValidateDTO)
        {
            NotificationHelper.CreateNewDictionary();

            (from i in RemoveIgnore(listCategoryValidateDTO)
             where listCategoryValidateDTO == null
             let setIgnore = i.SetIgnore()
             select Invalid(listCategoryValidateDTO.IndexOf(i))).ToList();

            (from i in RemoveIgnore(listCategoryValidateDTO)
             let resultInvalidLenght = InvalidLenght(i.InputCreateCategory!.Code, 1, 6)
             where resultInvalidLenght != EnumValidateType.Valid
             let setInvalid = i.SetInvalid()
             select InvalidLenght(i.InputCreateCategory.Code, resultInvalidLenght, nameof(i.InputCreateCategory.Code), 1, 6)).ToList();

            (from i in RemoveIgnore(listCategoryValidateDTO)
             let resultInvalidLenght = InvalidLenght(i.InputCreateCategory!.Description, 1, 100)
             where resultInvalidLenght != EnumValidateType.Valid
             let setInvalid = i.SetInvalid()
             select InvalidLenght(i.InputCreateCategory.Description, resultInvalidLenght, nameof(i.InputCreateCategory.Description), 1, 100)).ToList();

            (from i in RemoveIgnore(listCategoryValidateDTO)
             where i.OriginalCategory == null
             let setIgnore = i.SetIgnore()
             select Invalid(listCategoryValidateDTO.IndexOf(i))).ToList();

            (from i in RemoveInvalid(listCategoryValidateDTO)
             select AddSuccessMessage((i.InputIdentityUpdateCategory!.Id).ToString(), NotificationMessagesKey.SuccesfullyUpdatedKey)).ToList();
        }

        public void Delete(List<CategoryValidateDTO> listCategoryValidateDTO)
        {
            (from i in RemoveIgnore(listCategoryValidateDTO)
             where listCategoryValidateDTO == null
             let setIgnore = i.SetIgnore()
             select Invalid(listCategoryValidateDTO.IndexOf(i))).ToList();

            (from i in RemoveIgnore(listCategoryValidateDTO)
             where i.OriginalCategoryId == default
             let setInvalid = i.SetInvalid()
             select Invalid(listCategoryValidateDTO.IndexOf(i))).ToList();

            (from i in RemoveInvalid(listCategoryValidateDTO)
             select AddSuccessMessage((i.InputIdentityDeleteCategory!.Id).ToString(), NotificationMessagesKey.SuccesfullyDeletedKey)).ToList();
        }
    }
}