using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharp.Utils
{
    internal class Error
    {
        public static async Task NotFound (HttpContext c)
        {
            c.Response.StatusCode = 404;
            c.Response.ContentType = "application/json";
            c.Response.Headers["X-Epic-Error-Name"] = "errors.org.epicgames.common.not_found";
            c.Response.Headers["X-Epic-Error-Code"] = "1004";

            var json = new
            {
                errorCode = "errors.org.epicgames.common.not_found",
                errorMessage = "Sorry the resource you were trying to find could not be found",
                messageVars = new String[] {},
                numericErrorCode = 1004,
                originatingService = "fortnite",
                intent = "prod-live",
            };

            await c.Response.WriteAsJsonAsync (json);
        }
    }
}
