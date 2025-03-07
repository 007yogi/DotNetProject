﻿namespace ApiCustomFilter
{
    public class SampleMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<SampleMiddleware> _logger;

        public SampleMiddleware(RequestDelegate next, ILogger<SampleMiddleware> logger)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            _logger.LogInformation("Before Sample Middleware");

            await _next(httpContext);

            _logger.LogInformation("After Sample Middleware");
        }
    }
}
