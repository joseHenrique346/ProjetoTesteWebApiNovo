using Arguments.Argument.Enum;

namespace Arguments.Argument.Base.ApiResponse
{
    public class DetailedNotification
    {
        public string Key { get; set; }
        public EnumNotificationType Type { get; set; }
        public List<string>? ListMessage { get; set; }

        public DetailedNotification(string key, EnumNotificationType type, List<string>? listMessage)
        {
            Key = key;
            Type = type;
            ListMessage = listMessage;
        }

        public DetailedNotification() { }
    }
}