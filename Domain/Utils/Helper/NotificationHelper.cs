using Arguments.Argument.Base.ApiResponse;
using System.Collections.Concurrent;

namespace Domain.Utils.Helper
{
    public static class NotificationHelper
    {
        public static ConcurrentDictionary<string, List<DetailedNotification>> ListNotification { get; set; } = [];

        public static void Add(string key, DetailedNotification detailedNotification)
        {
            var existingNotification = ListNotification.GetOrAdd(key, _ => []);
            var notification = existingNotification.FirstOrDefault();
            if (notification != null)
            {
                notification.ListMessage ??= [];
                notification.ListMessage.AddRange(detailedNotification.ListMessage ?? []);
            }
        }

        public static List<DetailedNotification>? Get(string key)
        {
            if (ListNotification.TryGetValue(key, out List<DetailedNotification>? value))
                if (value != null)
                    return value;
            return default;
        }

        public static void Remove(string key)
        {
            ListNotification.TryRemove(key, out _);
        }
    }
}