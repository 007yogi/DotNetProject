using System.Net.Quic;

namespace MiddlewareApp
{
    public class CustomMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CustomMiddleware> _logger;

        public CustomMiddleware(RequestDelegate next, ILogger<CustomMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            //await context.Response.WriteAsync("Excecute custom middleware.\n");
            await _next(context);
        }
    }
    public static class CustomMiddlewareExtension
    {    
        public static IApplicationBuilder UseMyMiddleware(this WebApplication app)
        {
            return app.UseMiddleware<CustomMiddleware>();
        }
    }
}
