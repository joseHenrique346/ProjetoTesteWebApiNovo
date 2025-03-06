using Arguments.Argument.Base.ApiResponse;
using Arguments.Argument.Enum;
using Domain.DTO.Base;
using Domain.Interface.Service.Base;
using Domain.Utils.Helper;

namespace Domain.Service.Base
{
    public class BaseValidate<TValidateDTO> : IBaseValidate<TValidateDTO>
        where TValidateDTO : BaseValidateDTO
    {
        public List<TValidateDTO> RemoveInvalid(List<TValidateDTO> listValidateDTO) => (from i in listValidateDTO where !i.Invalid select i).ToList();
        public List<TValidateDTO> RemoveIgnore(List<TValidateDTO> listValidateDTO) => (from i in listValidateDTO where !i.Ignore select i).ToList();

        public EnumValidateType InvalidLength(string value, int mingLength, int maxLength)
        {
            var valueLenght = value.Length;

            if (valueLenght < mingLength && mingLength != 0)
                return EnumValidateType.Invalid;

            if (valueLenght > maxLength)
                return EnumValidateType.Invalid;

            return EnumValidateType.Valid;
        }

        public bool InvalidLength(string key, string name, int mingLength, int maxLength)
        {
            CreateErrorNotification(key, , NotificationMessage.InvalidLength(name, mingLength, maxLength));
            return true;
        }

        public bool AlreadyExists(string key)
        {
            CreateErrorNotification(key, NotificationMessage.AlreadyExists(key));
            return true;
        }

        public bool RepeatedCode(string key)
        {
            CreateErrorNotification(key, NotificationMessage.RepeatedCode(key));
            return true;
        }

        public bool NonInformedField(string key, string name)
        {
            CreateErrorNotification(key, NotificationMessage.NonInformedField(name));
            return true;
        }

        public bool OriginalNotFound(long id)
        {
            CreateErrorNotification(id.ToString(), NotificationMessage.OriginalNotFound(id));
            return true;
        }

        public bool CreateSuccessNotification(string key, string description)
        {
            NotificationBuilder.AddSuccessMessage(key, NotificationMessage.CreateSuccess(key, description));
            return true;
        }

        public bool CreateSuccessNotification(string key)
        {
            NotificationBuilder.AddSuccessMessage(key, NotificationMessage.DeleteSuccess(key));
            return true;
        }

        public void CreateErrorNotification(string key, string errorMessage)
        {
            NotificationBuilder.AddErrorMessage(key, errorMessage);
        }
    }

    public class NotificationMessage
    {
        public static string InvalidLength(string name, int minLength, int maxLength) => $"*ERRO: InvalidLength* O campo {name} deve ter o tamanho entre {minLength} e {maxLength} caracteres!";
        public static string AlreadyExists(string key) => $"*ERRO: AlreadyExists* O campo {key} já é utilizado!";
        public static string RepeatedCode(string key) => $"*ERRO: RepeatedCode* O campo {key} foi digitado mais de uma vez na requisição";
        public static string OriginalNotFound(long id) => $"*ERRO: OriginalNotFound* O Id: {id} não foi encontrado como entidade original, digite corretamente!";
        public static string NonInformedField(string name) => $"*ERRO: NonInformedField* O campo {name} não pode ser vazio!";
        public static string CreateSuccess(string key, string description) => $"{description} com o código {key} criado com sucesso!";
        public static string DeleteSuccess(string key) => $"Id: {key}, deletado com sucesso!";
    }
}