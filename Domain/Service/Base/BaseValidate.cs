using Arguments.Argument.Base.ApiResponse;
using Arguments.Argument.Enum;
using Domain.DTO.Base;
using Domain.Utils.Helper;

namespace Domain.Service.Base
{
    public class BaseValidate<TValidateDTO>
        where TValidateDTO : BaseValidateDTO
    {
        #region Remove

        internal static List<TValidateDTO> RemoveInvalid(List<TValidateDTO> listValidateDTO) => (from i in listValidateDTO where !i.Invalid select i).ToList();
        internal static List<TValidateDTO> RemoveIgnore(List<TValidateDTO> listValidateDTO) => (from i in listValidateDTO where !i.Ignore select i).ToList();

        #endregion

        public static EnumValidateType InvalidLenght(string? value, int minLenght, int maxLenght)
        {
            if (string.IsNullOrEmpty(value))
                return minLenght == 0 ? EnumValidateType.Valid : EnumValidateType.NonInformed;

            int lenght = value.Length;
            if (lenght < minLenght || lenght > maxLenght)
                return EnumValidateType.Invalid;

            return EnumValidateType.Valid;
        }

        public static EnumValidateType InvalidLenght(string? value, int maxLenght)
        {
            if (string.IsNullOrEmpty(value))
                return EnumValidateType.NonInformed;

            int lenght = value.Length;
            if (lenght != maxLenght)
                return EnumValidateType.Invalid;

            return EnumValidateType.Valid;
        }

        public static EnumValidateType InvalidRelatedProperty(object? relatedProperty, object? value)
        {
            if (value == null)
                return EnumValidateType.Valid;

            return value.Equals(0) ? EnumValidateType.NonInformed : !value.Equals(0) && relatedProperty == null ? EnumValidateType.Invalid : EnumValidateType.Valid;
        }

        #region Messages

        internal static class NotificationMessagesKey
        {
            public const string SuccesfullyCreatedKey = "SuccessfullyCreated";
            public const string SuccesfullyDeletedKey = "SuccessfullyDeleted";
            public const string SuccesfullyUpdatedKey = "SuccessfullyUpdated";
            public const string InvalidRecordKey = "InvalidRecord";
            public const string InvalidLenghtKey = "InvalidLenght";
            public const string InvalidBirthDateKey = "InvalidBirthDate";
            public const string NonInformedKey = "NonInformedField";
            public const string AlreadyExistsKey = "AlreadyExists";
            public const string RepeatedCodeKey = "RepeatedCode";
        }

        internal static class NotificationMessage
        {
            public static string InvalidLenghtMessage(string name, int minLenght, int maxLenght) => $"ERRO: {NotificationMessagesKey.InvalidLenghtKey}, o campo {name} tem que possuir um nome entre {minLenght} e {maxLenght} caracteres.";
            public static string InvalidLenghtMessage(string name, int maxLenght) => $"ERRO: {NotificationMessagesKey.InvalidLenghtKey}, o campo {name} tem que possuir {maxLenght} caracteres.";
            public static string AlreadyExists(string key) => $"ERRO {NotificationMessagesKey.AlreadyExistsKey}, o código {key} já está sendo usado";
            public static string RepeatedCode(string key) => $"ERRO {NotificationMessagesKey.RepeatedCodeKey}, o código {key} foi digitado mais de uma vez na requisição";
            public static string NullLenghtMessage(string name) => $"ERRO: {NotificationMessagesKey.NonInformedKey}, o campo {name} tem que ser preenchido.";
            public static string InvalidBirthDateMessage(string name, DateOnly? birthDate) => $"Erro: {NotificationMessagesKey.InvalidBirthDateKey} a data {birthDate} é inválida para o(a) cliente {name}";
        }

        #endregion

        #region Validations

        public bool Invalid(int index)
        {
            return HandleValidation(index.ToString(), EnumValidateType.Invalid, NotificationMessagesKey.InvalidRecordKey, string.Empty);
        }

        public bool InvalidLenght(string value, EnumValidateType validateType, string propertyName, int minLenght, int maxLenght)
        {
            return HandleValidation(value, validateType, NotificationMessage.InvalidLenghtMessage(propertyName, minLenght, maxLenght), NotificationMessage.NullLenghtMessage(propertyName));
        }

        public bool InvalidLenght(string value, EnumValidateType validateType, string propertyName, int maxLenght)
        {
            return HandleValidation(value, validateType, NotificationMessage.InvalidLenghtMessage(propertyName, maxLenght), NotificationMessage.NullLenghtMessage(propertyName));
        }

        public bool AlreadyExists(string value, EnumValidateType validateType)
        {
            return HandleValidation(value, validateType, NotificationMessagesKey.AlreadyExistsKey, string.Empty);
        }

        public bool RepeatedCode(string value, EnumValidateType validateType)
        {
            return HandleValidation(value, validateType, NotificationMessagesKey.RepeatedCodeKey, string.Empty);
        }

        public bool InvalidBirthDate(string value, DateOnly? birthDate, EnumValidateType validateType, string customerName)
        {
            return HandleValidation(value, validateType, NotificationMessage.InvalidBirthDateMessage(customerName, birthDate), string.Empty);
        }

        #endregion

        #region Helpers

        private bool AddToDictionary(string value, DetailedNotification validationMessage)
        {
            NotificationHelper.Add(value, validationMessage);
            return true;
        }

        public bool AddSuccessMessage(string value, string message)
        {
            return AddToDictionary(value, new DetailedNotification(value, [message], EnumNotificationType.Success));
        }

        public (List<DetailedNotification> Successes, List<DetailedNotification> Errors) GetValidationResult()
        {
            var notificationHelper = NotificationHelper.Get();

            var success = notificationHelper.Where(m => m.NotificationType == EnumNotificationType.Success).ToList();
            var error = notificationHelper.Where(m => m.NotificationType == EnumNotificationType.Error).ToList();

            return (success, error);
        }

        private bool HandleValidation(string key, EnumValidateType validType, string invalidMessage, string nonInformedMessage)
        {
            return validType switch
            {
                EnumValidateType.Invalid => AddToDictionary(key, new DetailedNotification(key, [invalidMessage], EnumNotificationType.Error)),
                EnumValidateType.NonInformed => AddToDictionary(key, new DetailedNotification(key, [nonInformedMessage], EnumNotificationType.Error)),
                _ => true
            };
        }

        #endregion
    }
}