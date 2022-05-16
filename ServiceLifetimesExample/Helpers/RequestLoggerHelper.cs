using Microsoft.AspNetCore.Http.Abstractions;

namespace SimpleServiceLifetimesExampleApi.Helpers;

public class RequestLoggerHelper
{
    private readonly RequestDelegate _next;

    public RequestLoggerHelper(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext httpContext)
    {
        ConsoleHelper.PrintInstructions($"You called {httpContext.Request.Path}.");

        await _next.Invoke(httpContext);
    }
}