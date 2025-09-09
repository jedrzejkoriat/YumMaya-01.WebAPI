using System.Net;
using YumMaya_01.WebAPI.Application.Base;

namespace YumMaya_01.WebAPI.API.Middleware;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlerMiddleware> _logger;

    public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ForbiddenException ex)
        {
            _logger.LogWarning(ex, "Forbidden access at {Path}", context.Request.Path);
            await HandleExceptionAsync(context, HttpStatusCode.Forbidden, "Access Denied", "You don't have permission to access this resource.");
        }
        catch (UnauthorizedAccessException ex)
        {
            _logger.LogWarning(ex, "Unauthorized access at {Path}", context.Request.Path);
            await HandleExceptionAsync(context, HttpStatusCode.Unauthorized, "Unauthorized", "Authentication required.");
        }
        catch (NotFoundException ex)
        {
            _logger.LogInformation(ex, "Resource not found at {Path}", context.Request.Path);
            await HandleExceptionAsync(context, HttpStatusCode.NotFound, "Resource Not Found", "The requested resource could not be found.");
        }
        catch (OperationFailedException ex)
        {
            _logger.LogError(ex, "Operation failed at {Path}", context.Request.Path);
            await HandleExceptionAsync(context, HttpStatusCode.InternalServerError, "Operation Failed", "The operation could not be completed.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unhandled exception at {Path}", context.Request.Path);
            await HandleExceptionAsync(context, HttpStatusCode.InternalServerError, "Internal Server Error", "Something went wrong. Please try again later.");
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, HttpStatusCode statusCode, string title, string detail)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;
        var errorResponse = new
        {
            type = $"https://httpstatuses.com/{(int)statusCode}",
            title,
            status = (int)statusCode,
            detail,
            instance = context.Request.Path
        };
        await context.Response.WriteAsJsonAsync(errorResponse);
    }
}
