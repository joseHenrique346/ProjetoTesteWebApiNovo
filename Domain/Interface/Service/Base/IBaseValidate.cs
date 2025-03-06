using Arguments.Argument.Base.ApiResponse;
using Arguments.Argument.Enum;
using Domain.DTO.Base;

namespace Domain.Interface.Service.Base
{
    public interface IBaseValidate<TValidateDTO>
        where TValidateDTO : BaseValidateDTO
    {
        List<TValidateDTO> RemoveInvalid(List<TValidateDTO> listValidateDTO) => (from i in listValidateDTO where !i.Invalid select i).ToList();
        List<TValidateDTO> RemoveIgnore(List<TValidateDTO> listValidateDTO) => (from i in listValidateDTO where !i.Ignore select i).ToList();

        EnumValidateType InvalidLength(string value, int mingLength, int maxLength);

        bool InvalidLength(string key, string name, int mingLength, int maxLength);

        bool OriginalNotFound(long id);

        bool AlreadyExists(string key);

        bool RepeatedCode(string key);

        bool CreateSuccessNotification(string key, string description);

        bool CreateSuccessNotification(string key);

        void CreateErrorNotification(string key, string validationMessage);
    }
}