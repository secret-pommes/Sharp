using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Sharp.Routes
{
    internal static class Rdatarouter
    {
        public static void MapDatarouter (this WebApplication web)
        {
            var app = web.MapGroup("/datarouter");

            app.MapPost("/api/v1/public/data", (HttpContext c) =>
            {
                c.Response.StatusCode = 204;
                return "";
            });
        }
    }
}
