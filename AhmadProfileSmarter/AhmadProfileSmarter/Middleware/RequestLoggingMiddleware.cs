using System.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace AhmadProfileSmarter.Middleware
{

    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;

        public RequestLoggingMiddleware(RequestDelegate next,
            ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var stopwatch = Stopwatch.StartNew();

            var request = context.Request;

            // Log request start
            _logger.LogInformation(
                "Incoming Request: {Method} {Path} at {Time}",
                request.Method,
                request.Path,
                DateTime.UtcNow
            );

            await _next(context); // Move to next middleware

            stopwatch.Stop();

            // Log response
            _logger.LogInformation(
                "Response: {StatusCode} completed in {ElapsedMilliseconds} ms",
                context.Response.StatusCode,
                stopwatch.ElapsedMilliseconds
            );
        }
    }
}