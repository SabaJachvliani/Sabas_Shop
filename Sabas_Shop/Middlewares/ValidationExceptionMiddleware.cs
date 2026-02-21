using Microsoft.AspNetCore.Mvc;

namespace Sabas_Shop.Middlewares;

public sealed class ValidationExceptionMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (FluentValidation.ValidationException ex)
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.Response.ContentType = "application/problem+json";

            var errors = ex.Errors
                .GroupBy(e => e.PropertyName)
                .ToDictionary(g => g.Key, g => g.Select(x => x.ErrorMessage).ToArray());

            await context.Response.WriteAsJsonAsync(new ValidationProblemDetails(errors)
            {
                Title = "Validation error",
                Status = 400,
                Instance = context.Request.Path
            });
        }
    }
}