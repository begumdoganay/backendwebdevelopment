using BookStore_Web_Application.Core.Exceptions;

namespace BookStore_Web_Application.API.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                await HandleExceptionAsync(context, ex);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var response = context.Response;
            response.ContentType = "application/json";

            var errorResponse = new ErrorResponse
            {
                Message = exception.Message
            };

            switch (exception)
            {
                case FluentValidation.ValidationException e:
                    response.StatusCode = StatusCodes.Status400BadRequest;
                    errorResponse.Errors = new Dictionary<string, string[]>
                        {
                            { "ValidationErrors", new[] { e.Message } }
                        };
                    break;

                case NotFoundException e:
                    response.StatusCode = StatusCodes.Status404NotFound;
                    break;

                case BadRequestException e:
                    response.StatusCode = StatusCodes.Status400BadRequest;
                    break;

                case UnauthorizedException e:
                    response.StatusCode = StatusCodes.Status401Unauthorized;
                    break;

                case ForbiddenException e:
                    response.StatusCode = StatusCodes.Status403Forbidden;
                    break;

                case BusinessException e:
                    response.StatusCode = StatusCodes.Status409Conflict;
                    break;

                default:
                    response.StatusCode = StatusCodes.Status500InternalServerError;
                    errorResponse.Message = "An error occurred while processing your request.";
                    break;
            }

            await response.WriteAsJsonAsync(errorResponse);
        }
    }

    public class ErrorResponse
    {
        public string? Message { get; set; }
        public IDictionary<string, string[]>? Errors { get; set; }
    }
}
