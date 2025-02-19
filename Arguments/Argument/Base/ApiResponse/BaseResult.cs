namespace Arguments.Argument.Base.ApiResponse
{
    public class BaseResult<T>(bool isSuccess, List<DetailedNotification> listNotification, T? value)
    {
        public bool IsSuccess { get; private set; } = isSuccess;
        public List<DetailedNotification>? listNotification { get; private set; } = listNotification;
        public T? Value { get; private set; } = value;

        public static BaseResult<T> Success(T value, List<DetailedNotification> listNotification) => new(true, listNotification, value);
        public static BaseResult<T> Failure(List<DetailedNotification> listNotification) => new(false, listNotification, default);
    }
}