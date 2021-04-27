using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Middleware
{
    public class BrowserCheck
    {
        private RequestDelegate _next;
        public BrowserCheck(RequestDelegate next)
        {
            _next = next;
        }
        public Task Invoke(HttpContext context)
        {
            var browserInfo = context.Request.Headers["User-Agent"].ToString();
            Debug.WriteLine("Browser: " + browserInfo);
            /*if (context.Request.Path == "/")
                context.Request.Path = "/Privacy";*/
            return _next(context);
        }
    }

    public static class BrowserCheckExtensions
    {
        public static IApplicationBuilder BrowserCheck(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<BrowserCheck>();
        }
    }
}
