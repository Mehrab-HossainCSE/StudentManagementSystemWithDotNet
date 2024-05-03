using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace SMS.BAL.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine($"An error occurred: {ex}");

                // Return a 500 Internal Server Error response
              //  context.Response.StatusCode = 500;
               // await context.Response.WriteAsync("An internal server error occurred.");
            }
        }
    }
}
