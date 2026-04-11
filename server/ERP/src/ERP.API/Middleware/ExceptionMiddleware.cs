using System.Net;
using System.Text.Json;
using FluentValidation;

namespace ERP.API.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(
        RequestDelegate next,
        ILogger<ExceptionMiddleware> logger)
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
        catch (ValidationException ex)
        {
            _logger.LogWarning("Validation failed: {Errors}", ex.Message);
            await HandleValidationException(context, ex);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unhandled exception occurred");
            await HandleGenericException(context, ex);
        }
    }

    private static async Task HandleValidationException(
        HttpContext context,
        ValidationException ex)
    {
        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        context.Response.ContentType = "application/json";

        var errors = ex.Errors
            .Select(e => e.ErrorMessage)
            .ToList();

        var response = new
        {
            succeeded = false,
            message = "Validation failed",
            errors
        };

        await context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }

    private static async Task HandleGenericException(
        HttpContext context,
        Exception ex)
    {
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        context.Response.ContentType = "application/json";

        var response = new
        {
            succeeded = false,
            message = "An unexpected error occurred",
            errors = new List<string> { ex.Message }
        };

        await context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }
}