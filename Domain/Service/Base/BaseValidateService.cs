using Arguments.Argument.Enum;
using Domain.DTO.Base;
using Domain.Interface.Service.Base;

namespace Domain.Service.Base
{
    public class BaseValidateService<TValidateDTO> : BaseValidate<TValidateDTO>, IBaseValidateService<TValidateDTO>
        where TValidateDTO : BaseValidateDTO
    {
        public void ValidateNullDTO(List<TValidateDTO> listValidateDTO)
        {
            (from i in RemoveIgnore(listValidateDTO)
             where i == null
             let setInvalid = i.SetIgnore()
             select i).ToList();
        }

        public bool InvalidLengthValidation(TValidateDTO validateDTO, string valueString, string input, int minLeght, int maxLenght)
        {
            var propertyInput = validateDTO.GetType().GetProperty(input);
            if (propertyInput != null)
            {
                var inputValue = propertyInput.GetValue(validateDTO);
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

        public bool AlreadyExistingCodeValidation(TValidateDTO validateDTO, string key, string input)
        {
            var existingCodeProperty = validateDTO.GetType().GetProperty("ExistingCode");
            if (existingCodeProperty != null)
            {
                var propertyValue = existingCodeProperty.GetValue(validateDTO);
                if (propertyValue != null)
                {
                    var propertyInput = validateDTO.GetType().GetProperty(input);
                    var inputValue = propertyInput!.GetValue(validateDTO);
                    var propertyKey = inputValue!.GetType().GetProperty(key);

                    var keyValue = propertyKey.GetValue(inputValue)!.ToString();
                    validateDTO.SetInvalid();
                    AlreadyExists(keyValue!);
                }
            }
            return true;
        }

        public bool RepeatedCodeValidation(TValidateDTO validateDTO, string key, string input)
        {
            var repeatedCodeProperty = validateDTO.GetType().GetProperty("RepeatedCode");
            if (repeatedCodeProperty != null)
            {
                var propertyValue = repeatedCodeProperty.GetValue(validateDTO);
                if (propertyValue != default)
                {
                    var propertyInput = validateDTO.GetType().GetProperty(input);
                    var inputValue = propertyInput.GetValue(validateDTO);
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
                    var propertyInputOriginalEntityId = validateDTO.GetType().GetProperty("InputOriginalEntityId");
                    long valueInputOriginalEntityId = (long)(propertyInputOriginalEntityId?.GetValue(validateDTO) ?? 0);
                    validateDTO.SetInvalid();
                    OriginalNotFound(valueInputOriginalEntityId);
                }
            }
            return true;
        }
    }
}