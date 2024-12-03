using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

public class oAuthTokenRequest
{
    public string grant_type { get; set; }
    public string password { get; set; }
    public string username { get; set; }
    public string granttype { get; set; }
}

namespace Sharp.Routes
{
    internal static class Raccount
    {
        public static void MapAccount(this WebApplication web)
        {
            var app = web.MapGroup("/account");

            app.MapPost("/api/oauth/token", async (HttpContext c) =>
            {
                c.Request.EnableBuffering();
                using var reader = new StreamReader(c.Request.Body);
                var ReqBody = await reader.ReadToEndAsync();
                c.Request.Body.Position = 0;

                var body = JsonSerializer.Deserialize<oAuthTokenRequest>(ReqBody);

                Console.WriteLine(body);

                // Correct status code and response writing
                c.Response.StatusCode = 400; // Bad Request
                c.Response.ContentType = "application/json";
                var json = JsonSerializer.Serialize(new { error = "Invalid request" });
                await c.Response.WriteAsync(json);
            });

        }
    }
}
