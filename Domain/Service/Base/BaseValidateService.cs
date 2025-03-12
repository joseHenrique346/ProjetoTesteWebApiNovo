using Arguments.Argument.Base.Crud;
using Arguments.Argument.Enum;
using Domain.DTO.Base;
using Domain.Interface.Service.Base;

namespace Domain.Service.Base
{
    public class BaseValidateService<TValidateDTO, TInputCreate, TInputUpdate, TInputIdentityDelete> : BaseValidate<TValidateDTO>, IBaseValidateService<TValidateDTO>
        where TValidateDTO : BaseValidateDTO_1<TInputCreate, TInputUpdate, TInputIdentityDelete>
        where TInputCreate : BaseInputCreate<TInputCreate>
        where TInputUpdate : BaseInputUpdate<TInputUpdate>
        where TInputIdentityDelete : BaseInputIdentityDelete<TInputIdentityDelete>
    {
        public void ValidateNullDTO(List<TValidateDTO> listValidateDTO)
        {
            (from i in RemoveIgnore(listValidateDTO)
             where i == null
             let setIgnore = i.SetIgnore()
             select i).ToList();
        }

        public void ValidateNullInput(List<TValidateDTO> listValidateDTO)
        {
            (from i in RemoveIgnore(listValidateDTO)
             where i.InputCreate == null
             where i.InputUpdate == null
             let setIgnore = i.SetIgnore()
             select i).ToList();
        }

        public void ValidateNullCode(List<TValidateDTO> listValidateDTO)
        {
            (from i in RemoveIgnore(listValidateDTO)
             let inputValue = FindInput(i)
             let propertyCode = inputValue.GetType().GetProperty("Code")
             let valueCode = propertyCode.GetValue(inputValue)
             where valueCode == null
             let setIgnore = i.SetIgnore()
             select i).ToList();
        }

        public bool InvalidLengthValidation(TValidateDTO validateDTO, string valueString, int minLeght, int maxLenght)
        {
            var inputValue = FindInput(validateDTO);
            if (inputValue != null)
            {
                var property = inputValue!.GetType().GetProperty(valueString);
                var propertyValue = property!.GetValue(inputValue)!.ToString();
                EnumValidateType validate = InvalidLength(propertyValue!, minLeght, maxLenght);
                if (validate != EnumValidateType.Valid)
                {
                    validateDTO.SetInvalid();
                    var propertyKey = inputValue.GetType().GetProperty("Code");
                    var keyValue = propertyKey.GetValue(inputValue)!.ToString();
                    bool _ = validate == EnumValidateType.Invalid ? InvalidLength(keyValue, valueString, minLeght, maxLenght) : NonInformedField(keyValue!, valueString);
                }
            }
            return true;
        }

        public bool AlreadyExistingCodeValidation(TValidateDTO validateDTO, string key)
        {
            var existingCodeProperty = validateDTO.GetType().GetProperty("ExistingCode");
            if (existingCodeProperty != null)
            {
                var propertyValue = existingCodeProperty.GetValue(validateDTO);
                if (propertyValue != null)
                {
                    var inputValue = FindInput(validateDTO);
                    var propertyKey = inputValue!.GetType().GetProperty(key);

                    var keyValue = propertyKey.GetValue(inputValue)!.ToString();
                    validateDTO.SetInvalid();
                    AlreadyExists(keyValue!);
                }
            }
            return true;
        }

        public bool RepeatedCodeValidation(TValidateDTO validateDTO, string key)
        {
            var repeatedCodeProperty = validateDTO.GetType().GetProperty("RepeatedCode");
            if (repeatedCodeProperty != null)
            {
                var propertyValue = repeatedCodeProperty.GetValue(validateDTO);
                if (propertyValue != default)
                {
                    var inputValue = FindInput(validateDTO);
                    var propertyKey = inputValue.GetType().GetProperty(key);
                    var keyValue = propertyKey.GetValue(inputValue)!.ToString();
                    validateDTO.SetInvalid();
                    RepeatedCode(keyValue);
                }
            }
            return true;
        }

        public bool ExistingOriginalEntityValidation(TValidateDTO validateDTO, string key)
        {
            var existingOriginalProperty = validateDTO.GetType().GetProperty("OriginalEntity");
            if (existingOriginalProperty != null)
            {
                var propertyValue = existingOriginalProperty.GetValue(validateDTO);
                if (propertyValue == default)
                {
                    var inputValue = FindInput(validateDTO);
                    var propertyInputOriginalEntityId = validateDTO.GetType().GetProperty("InputOriginalEntityId");
                    long valueInputOriginalEntityId = (long)(propertyInputOriginalEntityId?.GetValue(validateDTO) ?? 0);
                    var propertyKey = inputValue.GetType().GetProperty(key);
                    var keyValue = propertyKey!.GetValue(inputValue)!.ToString();
                    validateDTO.SetInvalid();
                    OriginalNotFound(keyValue, valueInputOriginalEntityId);
                }
            }
            return true;
        }

        public dynamic FindInput(TValidateDTO validateDTO)
        {
            dynamic inputValue = validateDTO.InputCreate == null ? validateDTO.InputUpdate! : validateDTO.InputCreate;
            return inputValue;
        }
    }
}