using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace SMS.BAL.Middleware
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;
        public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
       
        public async Task Invoke(HttpContext context)
        {
            // Log request details
            Console.WriteLine($"Request: {context.Request.Method} {context.Request.Path}{context.Request.QueryString}");
            _logger.LogInformation("About page visited at {DT}", DateTime.UtcNow.ToLongTimeString());

            // Log request details
            //Console.WriteLine($"Request: {context.Request.Method} {context.Request.Path}{context.Request.QueryString}");
            // Continue processing the request
            await _next(context);
        }
    }
}
