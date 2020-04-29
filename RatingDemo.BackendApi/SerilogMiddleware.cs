using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace RatingDemo.BackendApi
{
    public class SerilogMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<SerilogMiddleware> logger;

        public SerilogMiddleware(
            RequestDelegate next,
            ILogger<SerilogMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await next(httpContext);
            }
            catch (Exception exception)
            {
                logger.LogError(exception, exception.Message);
                throw exception;
            }
        }
    }
}