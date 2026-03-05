using AhmadProfileSmarter.Models;
using AhmadProfileSmarter.Models.ErrorResponse;
using System.Net;
using System.Text.Json;

namespace AhmadProfileSmarter.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next,ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                // Call next middleware
                await _next(context);
            }
            catch (Exception ex)
            {
                // Log error
                _logger.LogError(ex, ex.Message);

                await HandleExceptionAsync(context, ex);
            }
        }

        public async Task HandleExceptionAsync(HttpContext context,Exception exception)
        {

            context.Response.ContentType = "application/json";

            var response = context.Response;

            var errorResponse = new ErrorResponse();

            switch (exception)
            {
                case KeyNotFoundException:
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    errorResponse.Message = "Resource not found";
                    break;

                case UnauthorizedAccessException:
                    response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    errorResponse.Message = "Unauthorized access";
                    break;

                case ArgumentException:
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    errorResponse.Message = exception.Message;
                    break;

                default:
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    errorResponse.Message = "Internal Server Error";
                    break;
            }

            errorResponse.StatusCode = response.StatusCode;

            var result = JsonSerializer.Serialize(errorResponse);

            await context.Response.WriteAsync(result);
        }
    }
}
