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

            InvalidLengthValidation(listValidateDTO, "Code", "InputCreate", 1, 6);

            InvalidLengthValidation(listValidateDTO, "Description", "InputCreate", 1, 100);

            AlreadyExistingCodeValidation(listValidateDTO, "Code", "InputCreate");

            RepeatedCodeValidation(listValidateDTO, "Code", "InputCreate");

            (from i in RemoveInvalid(listValidateDTO)
             select CreateSuccessNotification(i.InputCreate!.Code, i.InputCreate!.Description)).ToList();
        }

        public void Update(List<BrandValidateDTO> listBrandValidateDTO)
        {
            NotificationBuilder.CreateDictionary();

            ValidateNullDTO(listBrandValidateDTO);

            InvalidLengthValidation(listBrandValidateDTO, "Code", "InputUpdate", 1, 6);

            InvalidLengthValidation(listBrandValidateDTO, "Description", "InputUpdate", 1, 100);

            AlreadyExistingCodeValidation(listBrandValidateDTO, "Code", "InputUpdate");

            RepeatedCodeValidation(listBrandValidateDTO, "Code", "InputUpdate");

            //ExistingOriginalEntityValidation(listBrandValidateDTO, "Code",  "InputUpdate")

            //(from i in RemoveIgnore(listBrandValidateDTO)
            // where i.OriginalEntity == null
            // let setIgnore = i.SetIgnore()
            // select OriginalNotFound(i.InputIdentityUpdateBrand.Id)).ToList();

            (from i in RemoveInvalid(listBrandValidateDTO)
             select UpdateSuccessNotification(i.InputUpdate.Code, i.InputUpdate.Description)).ToList();
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
             select DeleteSuccessNotification(i.InputIdentityDeleteBrand!.Id.ToString())).ToList();
        }
    }
}