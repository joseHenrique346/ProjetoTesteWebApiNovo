using Arguments.Argument.Base.ApiResponse;
using Arguments.Argument.Enum;
using System.Collections.Concurrent;

namespace Domain.Utils.Helper
{
    public class NotificationBuilder
    {
        public static ConcurrentDictionary<string, List<DetailedNotification>>? ListNotification { get; set; }
        public static void CreateDictionary()
        {
            ListNotification = new ConcurrentDictionary<string, List<DetailedNotification>>();
        }

        public static void Add(string key, DetailedNotification detailedNotification)
        {
            ListNotification.TryGetValue(key, out List<DetailedNotification>? listValue);

            if (listValue == null)
            {
                listValue = new List<DetailedNotification>();

                listValue.Add(detailedNotification);
                ListNotification.TryAdd(key, listValue);
            }
            else
            {
                var listMessage = listValue?.FirstOrDefault()?.ListMessage;
                listMessage?.Add(detailedNotification.ListMessage!.FirstOrDefault()!);
            }
        }

        public static void AddSuccessMessage(string key, string successMessage)
        {
            Add(key, new DetailedNotification(key, EnumNotificationType.Success, [successMessage]));
        }

        public static void AddErrorMessage(string key, string errorMessage)
        {
            Add(key, new DetailedNotification(key, EnumNotificationType.Error, [errorMessage]));
        }

        public static List<DetailedNotification> GetAll()
        {
            var value = (from i in ListNotification
                         from j in i.Value
                         select j).ToList();
            return value;
        }
    }
}