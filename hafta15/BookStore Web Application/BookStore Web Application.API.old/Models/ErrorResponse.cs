namespace BookStore_Web_Application.API.Models
{
    public class ErrorResponse
    {
        public string? TraceId { get; set; }
        public string? Message { get; set; }
        public IDictionary<string, string[]>? Errors { get; set; }
    }
}
