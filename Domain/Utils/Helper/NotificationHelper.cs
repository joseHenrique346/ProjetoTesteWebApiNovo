using Arguments.Argument.Base.ApiResponse;
using System.Collections.Concurrent;

namespace Domain.Utils.Helper
{
    public static class NotificationHelper
    {
        public static ConcurrentDictionary<string, List<DetailedNotification>>? ListNotification { get; set; }

        public static void CreateNewDictionary()
        {
            ListNotification = [];
        }

        public static void Add(string key, DetailedNotification detailedNotification)
        {
            var existingNotification = ListNotification.GetOrAdd(key, _ => new List<DetailedNotification>());
            var notification = existingNotification.FirstOrDefault();

            if (notification == null)
            {
                notification = new DetailedNotification(key, new List<string>(), detailedNotification.NotificationType);
                existingNotification.Add(notification);
            }

            if (notification != null)
            {
                notification.ListMessage ??= [];
                notification.ListMessage.AddRange(detailedNotification.ListMessage ?? []);
            }
        }

        public static List<DetailedNotification>? Get()
        {
            return (from i in ListNotification
                    from j in i.Value
                    select j).ToList();
        }

        public static void Remove(string key)
        {
            ListNotification.TryRemove(key, out _);
        }
    }
}