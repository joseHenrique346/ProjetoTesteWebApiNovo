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
            NotificationBuilder.CreateDictionary();

            //(from i in RemoveIgnore(listCategoryValidateDTO)
            // where listCategoryValidateDTO == null
            // let setIgnore = i.SetIgnore()
            // select Invalid(listCategoryValidateDTO.IndexOf(i))).ToList();

            (from i in RemoveIgnore(listCategoryValidateDTO)
             let resultInvalidLength = InvalidLength(i.InputCreateCategory!.Code, 1, 6)
             where resultInvalidLength != EnumValidateType.Valid
             let setInvalid = i.SetInvalid()
             select InvalidLength(i.InputCreateCategory.Code, nameof(i.InputCreateCategory.Code), 1, 6)).ToList();

            (from i in RemoveIgnore(listCategoryValidateDTO)
             let resultInvalidLength = InvalidLength(i.InputCreateCategory!.Description, 1, 100)
             where resultInvalidLength != EnumValidateType.Valid
             let setInvalid = i.SetInvalid()
             select InvalidLength(i.InputCreateCategory.Code, nameof(i.InputCreateCategory.Description), 1, 100)).ToList();

            (from i in RemoveIgnore(listCategoryValidateDTO)
             where i.RepeatedCode != null
             let setInvalid = i.SetInvalid()
             select AlreadyExists(i.InputCreateCategory!.Code)).ToList();

            (from i in RemoveInvalid(listCategoryValidateDTO)
             select CreateSuccessNotification(i.InputCreateCategory!.Code, i.InputCreateCategory.Description)).ToList();
        }

        public void Update(List<CategoryValidateDTO> listCategoryValidateDTO)
        {
            NotificationBuilder.CreateDictionary();

            //(from i in RemoveIgnore(listCategoryValidateDTO)
            // where listCategoryValidateDTO == null
            // let setIgnore = i.SetIgnore()
            // select Invalid(listCategoryValidateDTO.IndexOf(i))).ToList();

            (from i in RemoveIgnore(listCategoryValidateDTO)
             let resultInvalidLength = InvalidLength(i.InputCreateCategory!.Code, 1, 6)
             where resultInvalidLength != EnumValidateType.Valid
             let setInvalid = i.SetInvalid()
             select InvalidLength(i.InputCreateCategory.Code, nameof(i.InputCreateCategory.Code), 1, 6)).ToList();

            (from i in RemoveIgnore(listCategoryValidateDTO)
             let resultInvalidLength = InvalidLength(i.InputCreateCategory!.Description, 1, 100)
             where resultInvalidLength != EnumValidateType.Valid
             let setInvalid = i.SetInvalid()
             select InvalidLength(i.InputCreateCategory.Description, nameof(i.InputCreateCategory.Description), 1, 100)).ToList();

            (from i in RemoveIgnore(listCategoryValidateDTO)
             where i.OriginalCategory == null
             let setIgnore = i.SetIgnore()
             select OriginalNotFound(i.InputIdentityUpdateCategory.Id)).ToList();

            (from i in RemoveInvalid(listCategoryValidateDTO)
             select CreateSuccessNotification((i.InputIdentityUpdateCategory!.Id).ToString(), i.InputIdentityUpdateCategory.InputUpdateCategory.Description)).ToList();
        }

        public void Delete(List<CategoryValidateDTO> listCategoryValidateDTO)
        {
            NotificationBuilder.CreateDictionary();

            (from i in RemoveIgnore(listCategoryValidateDTO)
             where listCategoryValidateDTO == null
             let setIgnore = i.SetIgnore()
             select OriginalNotFound(i.InputIdentityDeleteCategory.Id)).ToList();

            (from i in RemoveIgnore(listCategoryValidateDTO)
             where i.OriginalCategoryId == default
             let setInvalid = i.SetInvalid()
             select OriginalNotFound(i.InputIdentityDeleteCategory.Id)).ToList();

            (from i in RemoveInvalid(listCategoryValidateDTO)
             select DeleteSuccessNotification((i.InputIdentityDeleteCategory!.Id).ToString())).ToList();
        }
    }
}