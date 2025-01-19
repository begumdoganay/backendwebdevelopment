using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;
using BookStore_Web_Application.Core.Exceptions;
using FluentValidation;
using ValidationException = BookStore_Web_Application.Core.Exceptions.ValidationException;

public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
{
    public readonly IDictionary<Type, Action<ExceptionContext>> _exceptionHandlers;
    public readonly ILogger<ApiExceptionFilterAttribute> _logger;

    public ApiExceptionFilterAttribute(ILogger<ApiExceptionFilterAttribute> logger)
    {
        _logger = logger;
        _exceptionHandlers = new Dictionary<Type, Action<ExceptionContext>>
        {
            { typeof(ValidationException), HandleValidationException },
            { typeof(NotFoundException), HandleNotFoundException },
            { typeof(UnauthorizedException), HandleUnauthorizedException },
            { typeof(ForbiddenException), HandleForbiddenException },
            { typeof(BusinessException), HandleBusinessException }
        };
    }

    private void HandleValidationException(ExceptionContext context)
    {
        throw new NotImplementedException();
    }

    public override void OnException(ExceptionContext context)
    {
        _logger.LogError(context.Exception, context.Exception.Message);
        HandleException(context);
        base.OnException(context);
    }

    private void HandleException(ExceptionContext context)
    {
        throw new NotImplementedException();
    }

    private void HandleUnknownException(ExceptionContext context)
    {
        var details = new ProblemDetails
        {
            Status = StatusCodes.Status500InternalServerError,
            Title = "An error occurred while processing your request.",
            Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
            Instance = context.HttpContext.Request.Path
        };

        context.Result = new ObjectResult(details)
        {
            StatusCode = StatusCodes.Status500InternalServerError
        };

        context.ExceptionHandled = true;
    }

    private void HandleInvalidModelStateException(ExceptionContext context)
    {
        var details = new ValidationProblemDetails(context.ModelState)
        {
            Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
            Title = "One or more validation errors occurred."
        };

        context.Result = new BadRequestObjectResult(details);
        context.ExceptionHandled = true;
    }

    private void HandleNotFoundException(ExceptionContext context)
    {
        var exception = (NotFoundException)context.Exception;

        var details = new ProblemDetails
        {
            Type = "https://tools.ietf.org/html/rfc7231#section-6.5.4",
            Title = "The specified resource was not found.",
            Detail = exception.Message,
            Status = StatusCodes.Status404NotFound,
            Instance = context.HttpContext.Request.Path
        };

        context.Result = new NotFoundObjectResult(details);
        context.ExceptionHandled = true;
    }

    private void HandleUnauthorizedException(ExceptionContext context)
    {
        var exception = (UnauthorizedException)context.Exception;

        var details = new ProblemDetails
        {
            Type = "https://tools.ietf.org/html/rfc7235#section-3.1",
            Title = "Unauthorized",
            Detail = exception.Message,
            Status = StatusCodes.Status401Unauthorized,
            Instance = context.HttpContext.Request.Path
        };

        context.Result = new UnauthorizedObjectResult(details);
        context.ExceptionHandled = true;
    }

    private void HandleForbiddenException(ExceptionContext context)
    {
        var exception = (ForbiddenException)context.Exception;

        var details = new ProblemDetails
        {
            Type = "https://tools.ietf.org/html/rfc7231#section-6.5.3",
            Title = "Forbidden",
            Detail = exception.Message,
            Status = StatusCodes.Status403Forbidden,
            Instance = context.HttpContext.Request.Path
        };

        context.Result = new ObjectResult(details)
        {
            StatusCode = StatusCodes.Status403Forbidden
        };

        context.ExceptionHandled = true;
    }

    private void HandleBusinessException(ExceptionContext context)
    {
        var exception = (BusinessException)context.Exception;

        var details = new ProblemDetails
        {
            Type = "https://tools.ietf.org/html/rfc7231#section-6.5.8",
            Title = "Business Rule Violation",
            Detail = exception.Message,
            Status = StatusCodes.Status409Conflict,
            Instance = context.HttpContext.Request.Path
        };

        context.Result = new ConflictObjectResult(details);
        context.ExceptionHandled = true;
    }
}