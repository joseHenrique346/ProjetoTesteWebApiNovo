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

        #region Messages

        internal static class NotificationMessages
        {
            public const string SuccesfullyCreatedKey = "SuccessfullyCreated";
            public const string SuccesfullyDeletedKey = "SuccessfullyDeleted";
            public const string SuccesfullyUpdatedKey = "SuccessfullyUpdated";
            public const string InvalidRecordKey = "InvalidRecord";
            public const string InvalidLenghtKey = "InvalidLenght";
            public const string AlreadyExistsKey = "AlreadyExists";
            //public const string GenericNotProvideKey = "GenericNotProvide";
        }

        #endregion

        #region Validations

        public bool Invalid(int index)
        {
            return HandleValidation(index.ToString(), EnumValidateType.Invalid, NotificationMessages.InvalidRecordKey, string.Empty);
        }

        public bool InvalidLenght(string value, EnumValidateType validateType, string propertyName)
        {
            return HandleValidation(value, validateType, NotificationMessages.InvalidLenghtKey, propertyName);
        }

        //public bool InvalidLength(string key, string? value, int minLength, int maxLength, EnumValidateType validateType, string propertyName)
        //{
        //    return HandleValidation(key, validateType, NotificationMessages.InvalidLenghtKey, value!, propertyName, minLength, maxLength, NotificationMessages.GenericNotProvideKey, propertyName);
        //}

        public bool AlreadyExists(string value, EnumValidateType validateType)
        {
            return HandleValidation(value, validateType, NotificationMessages.AlreadyExistsKey, string.Empty);
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

        public (List<DetailedNotification> Successes, List<DetailedNotification> Errors) GetValidationResult(string key)
        {
            var notificationHelper = NotificationHelper.Get(key);

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