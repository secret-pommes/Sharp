using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharp.Routes
{
    internal static class Rdatarouter
    {
        public static void Mapdatarouter (this WebApplication web)
        {
            var app = web.MapGroup("/datarouter");

            app.MapGet("/api/v1/public/data", (HttpContext c) =>
            {
                c.Response.StatusCode = 204;
                return "";
            });
        }
    }
}
