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
                return minLenght == 0 ? EnumValidateType.Valid : EnumValidateType.Invalid;

            int lenght = value.Length;
            if (lenght < minLenght || lenght > maxLenght)
                return EnumValidateType.Invalid;

            return EnumValidateType.Valid;
        }

        #region Messages

        internal static class NotificationMessages
        {
            public const string SuccesfullyDeletedKey = "SuccessfullyDeleted";
            public const string SuccesfullyUpdatedKey = "SuccessfullyUpdated";
            public const string InvalidRecordKey = "InvalidRecord";
            public const string InvalidLenghtKey = "InvalidLenght";
            public const string AlreadyExistsKey = "AlreadyExists";
        }

        #endregion

        #region Validations

        public bool Invalid(int index)
        {
            return HandleValidation(index.ToString(), EnumValidateType.Invalid, NotificationMessages.InvalidRecordKey, string.Empty);
        }

        public bool InvalidLenght(string key, EnumValidateType validateType, string propertyName)
        {
            return HandleValidation(key, validateType, NotificationMessages.InvalidLenghtKey, propertyName);
        }

        public bool AlreadyExists(string key, EnumValidateType validateType)
        {
            return HandleValidation(key, validateType, NotificationMessages.AlreadyExistsKey, string.Empty);
        }

        #endregion

        #region Helpers

        private bool AddToDictionary(string key, DetailedNotification validationMessage)
        {
            NotificationHelper.Add(key, validationMessage);
            return true;
        }

        public bool AddSuccessMessage(string key, string message)
        {
            return AddToDictionary(key, new DetailedNotification(key, [message], EnumNotificationType.Success));
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