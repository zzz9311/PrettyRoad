using PrettyRoad.Core.Exceptions;

namespace PrettyRoad.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch(InvalidObjectException error)
            {
                httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                var response = new { error = error.Message };
                await httpContext.Response.WriteAsJsonAsync(response);
            }
            catch (Exception error)
            {
                //TODO LOGGER
                httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            }
        }
    }
}
