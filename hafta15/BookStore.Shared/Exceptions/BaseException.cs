namespace BookStore.Shared.Exceptions
{
    public class BaseException : Exception
    {
        public string? ErrorCode { get; }

        public BaseException(string message, string? errorCode = null) : base(message)
        {
            ErrorCode = errorCode;
        }
    }
}