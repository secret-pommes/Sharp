using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Reflection.PortableExecutable;
using System.Text.Json;

namespace Sharp.Routes
{
    internal static class Rcontent
    {
        public static void MapContent(this WebApplication web)
        {
            var app = web.MapGroup("/content");

            app.MapGet("/api/pages/fortnite-game", async (HttpContext c) =>
            {

                var json = JsonSerializer.Serialize(new
                {
                    _activeDate = DateTime.UtcNow.ToString("o")
                });
                c.Response.ContentType = "application/json";
                await c.Response.WriteAsync(json);
            });
        }
    }
}
