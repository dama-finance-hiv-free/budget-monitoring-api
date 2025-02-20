using System;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

namespace Dama.Fin.API.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IHostEnvironment _env;
    public ExceptionMiddleware(RequestDelegate next, 
        IHostEnvironment env)
    {
        _env = env;
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = 500;

            var innerExMessage = GetInnermostExceptionMessage(ex);

            var response = new ApiError
            {
                Status = 500,
                Detail = _env.IsDevelopment() ? ex.StackTrace : null,
                Title =  _env.IsDevelopment() ? innerExMessage : "Some kind of error occurred in the API. Please use the id and contact our " +
                                                                "support team if the problem persists.",
                Id = Guid.NewGuid().ToString(),
            };

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            var json = JsonSerializer.Serialize(response, options);

            await context.Response.WriteAsync(json);
        }
    }

    private static string GetInnermostExceptionMessage(Exception exception)
    {
        if (exception.InnerException != null)
            return GetInnermostExceptionMessage(exception.InnerException);

        return exception.Message;
    }
}