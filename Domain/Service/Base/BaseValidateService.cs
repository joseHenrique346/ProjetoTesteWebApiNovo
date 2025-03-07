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

        public void ValidateNonInformedStringField(List<TValidateDTO> listValidateDTO, string key, string propertyName, string input)
        {
            //(from i in RemoveIgnore(listValidateDTO)
            // let property = i.GetType().GetProperty(propertyName)
            // let propertyValue = property.GetValue(i)
            // where propertyValue == null
            // let setIgnore = i.SetIgnore()
            // let propertyKey = i.GetType().GetProperty(key)
            // let keyValue = propertyKey.GetValue(i)!.ToString()
            // select NonInformedField(keyValue, nameof(propertyValue), EnumValidateType.NonInformed)).ToList();
        }

        public void InvalidLengthValidation(List<TValidateDTO> listValidateDTO, string key, string valueString, string input, int minLeght, int maxLenght)
        {
            (from i in RemoveIgnore(listValidateDTO)
             let propertyInput = i.GetType().GetProperty(input)
             where propertyInput != null
             let inputvalue = propertyInput.GetValue(i)
             let property = inputvalue.GetType().GetProperty(valueString)
             let propertyValue = property.GetValue(inputvalue).ToString()
             let validate = InvalidLength(propertyValue, minLeght, maxLenght)
             where validate != EnumValidateType.Valid
             let setValidate = validate == EnumValidateType.Invalid ? i.SetInvalid() : i.SetInvalid()
             let propertyKey = inputvalue.GetType().GetProperty(key)
             let keyValue = propertyKey.GetValue(inputvalue)!.ToString()
             select validate == EnumValidateType.Invalid ? InvalidLength(keyValue, valueString, minLeght, maxLenght) : NonInformedField(keyValue, valueString)).ToList();
        }

        //public void ValidateNonInformedLongField(List<TValidateDTO> listValidateDTO, string key, long valueLong)
        //{
        //    (from i in RemoveIgnore(listValidateDTO)
        //     let property = i.GetType().GetProperty(valueLong())
        //     let propertyValue = property.GetValue(i)
        //     where propertyValue == null
        //     let setIgnore = i.SetIgnore()
        //     select NonInformedField(key, nameof(propertyValue), EnumValidateType.NonInformed)).ToList();
        //}

        public void ValidateInvalidLength(List<TValidateDTO> listValidateDTO, string key, string propertyName, int minLength, int maxLength)
        {
            (from i in RemoveIgnore(listValidateDTO)
             let property = listValidateDTO.GetType().GetProperty(propertyName)
             let propertyValue = property.GetValue(i)!.ToString()
             let resultInvalidLength = InvalidLength(propertyValue, minLength, maxLength)
             where resultInvalidLength != EnumValidateType.Valid
             let setInvalid = i.SetInvalid()
             select InvalidLength(key, nameof(propertyValue), minLength, maxLength)).ToList();
        }
    }
}