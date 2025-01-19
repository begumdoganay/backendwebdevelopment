using BookStore_Web_Application.Core.Exceptions;
using Microsoft.AspNetCore.Http;
using FluentValidation;
using System.Text.Json;

namespace BookStore_Web_Application.API.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;
        private readonly IWebHostEnvironment _env;

        public ErrorHandlingMiddleware(
            RequestDelegate next,
            ILogger<ErrorHandlingMiddleware> logger,
            IWebHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unhandled exception occurred during request {Path}", context.Request.Path);
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var response = context.Response;
            response.ContentType = "application/json";

            var errorResponse = new ErrorResponse
            {
                TraceId = context.TraceIdentifier,
                Message = exception.Message
            };

            switch (exception)
            {
                case FluentValidation.ValidationException e:
                    response.StatusCode = StatusCodes.Status400BadRequest;
                    errorResponse.Errors = e.Errors.GroupBy(
                        x => x.PropertyName,
                        x => x.ErrorMessage,
                        (propertyName, errorMessages) => new
                        {
                            Key = propertyName,
                            Values = errorMessages.Distinct().ToArray()
                        })
                        .ToDictionary(x => x.Key, x => x.Values);
                    _logger.LogWarning("Validation error occurred: {@ValidationErrors}", errorResponse.Errors);
                    break;

                case NotFoundException e:
                    response.StatusCode = StatusCodes.Status404NotFound;
                    _logger.LogWarning("Resource not found: {Message}", e.Message);
                    break;

                case BadRequestException e:
                    response.StatusCode = StatusCodes.Status400BadRequest;
                    _logger.LogWarning("Bad request: {Message}", e.Message);
                    break;

                case UnauthorizedException e:
                    response.StatusCode = StatusCodes.Status401Unauthorized;
                    _logger.LogWarning("Unauthorized access attempt: {Message}", e.Message);
                    break;

                case ForbiddenException e:
                    response.StatusCode = StatusCodes.Status403Forbidden;
                    _logger.LogWarning("Forbidden access attempt: {Message}", e.Message);
                    break;

                case BusinessException e:
                    response.StatusCode = StatusCodes.Status409Conflict;
                    _logger.LogWarning("Business rule violation: {Message}", e.Message);
                    break;

                default:
                    response.StatusCode = StatusCodes.Status500InternalServerError;
                    errorResponse.Message = "An error occurred while processing your request.";

                    if (_env.IsDevelopment())
                    {
                        errorResponse.DeveloperMessage = new
                        {
                            ExceptionType = exception.GetType().Name,
                            ExceptionMessage = exception.Message,
                            StackTrace = exception.StackTrace
                        };
                    }

                    _logger.LogError(exception, "An unexpected error occurred");
                    break;
            }

            var jsonOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };

            await response.WriteAsJsonAsync(errorResponse, jsonOptions);
        }
    }

    public class ErrorResponse
    {
        public string? TraceId { get; set; }
        public string? Message { get; set; }
        public IDictionary<string, string[]>? Errors { get; set; }
        public object? DeveloperMessage { get; set; }
    }
}