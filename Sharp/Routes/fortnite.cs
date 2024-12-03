using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sharp.Utils;

namespace Sharp.Routes
{
    internal static class Rfortnite
    {
        public static void MapFortnite(this WebApplication web)
        {
            var app = web.MapGroup("/fortnite");

            app.MapPost("/api/game/v2/tryPlayOnPlatform/account/{accountId}", async (HttpContext c) =>
            {
                c.Response.ContentType = "text/plain";
                await c.Response.WriteAsync("true");
            });

            app.MapGet("/api/game/v2/enabled_features", async (HttpContext c) => {
                var json = new String[] { };
                await c.Response.WriteAsJsonAsync(json);
            });

            app.MapGet("/api/cloudstorage/user/{accountId}", (HttpContext c) =>
            {
                c.Response.StatusCode = 204;
                return "";
            });

            app.MapGet("/api/storefront/v2/keychain", async (HttpContext c) =>
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "Resources", "keychain.json");

                Console.WriteLine(path);

                string json = await File.ReadAllTextAsync(path);

                if(!File.Exists(path))
                {
                    await Utils.Error.NotFound(c);
                }

                c.Response.ContentType = "application/json";
                await c.Response.WriteAsync(json);
            });
        }
    }
}
