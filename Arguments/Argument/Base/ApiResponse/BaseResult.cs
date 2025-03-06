namespace Arguments.Argument.Base.ApiResponse
{
    public class BaseResult<TOutput>(bool isSuccess, List<DetailedNotification> listNotification, TOutput? value)
    {
        public bool IsSuccess { get; private set; } = isSuccess;
        public List<DetailedNotification> ListNotification { get; private set; } = listNotification;
        public TOutput? Value { get; private set; } = value;

        public static BaseResult<TOutput> Failure() => new(false, [], default);
        public static BaseResult<TOutput> Failure(List<DetailedNotification> ListNotification) => new(false, ListNotification, default);
        public static BaseResult<TOutput> Success(TOutput value, List<DetailedNotification> ListNotification) => new(true, ListNotification, value);
    }
}