namespace BookStore.Shared.Models
{
    public class Result<T>
    {
        public bool IsSuccess { get; set; }
        public T? Data { get; set; }
        public string? Message { get; set; }
        public List<string>? Errors { get; set; }

        public static Result<T> Success(T data, string? message = null)
        {
            return new Result<T>
            {
                IsSuccess = true,
                Data = data,
                Message = message,
                Errors = new List<string>()
            };
        }

        public static Result<T> Failure(string error)
        {
            return new Result<T>
            {
                IsSuccess = false,
                Errors = new List<string> { error }
            };
        }
    }
}