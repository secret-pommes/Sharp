using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sharp.Utils;

public class TimelineResponse
{
    public Channels Channels { get; set; }
    public int EventsTimeOffsetHrs { get; set; }
    public int CacheIntervalMins { get; set; }
    public string CurrentTime { get; set; }
}

public class Channels
{
    [JsonPropertyName("client-events")]
    public ClientEvents ClientEvents { get; set; }

    [JsonPropertyName("client-matchmaking")]
    public ClientMatchmaking ClientMatchmaking { get; set; }
}

public class ClientEvents
{
    public object[] States { get; set; }
    public string CacheExpire { get; set; }
}

public class ClientMatchmaking
{
    public object[] States { get; set; }
    public string CacheExpire { get; set; }
}


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

            // todo actually do hotfix.
            app.MapGet("/api/cloudstorage/system", async (HttpContext c) =>
            {
                var json = Array.Empty<string>();
                c.Response.ContentType = "application/json";
                await c.Response.WriteAsJsonAsync(json);
            });

            app.MapGet("/api/cloudstorage/system/{file}", async (HttpContext c) =>
            {
                c.Response.StatusCode = 204;
                return "";
            });

            app.MapGet("/api/calendar/v1/timeline", async (HttpContext c) =>
            {
                var season = 7;

                var response = new TimelineResponse
                {
                    Channels = new Channels
                    {
                        ClientMatchmaking = new ClientMatchmaking
                        {
                            States = Array.Empty<object>(),
                            CacheExpire = "9999-01-01T22:28:47.830Z"
                        },
                        ClientEvents = new ClientEvents
                        {
                            States = new[]
                            {
                                new
                                {
                                    ValidFrom = "1337-01-01T00:00:00.000Z",
                                    ActiveEvents = new[]
                                    {
                                        new
                                        {
                                            EventType = $"EventFlag.Season{season}",
                                            ActiveUntil = "2025-12-31T00:00:00.000Z",
                                            ActiveSince = "1337-01-01T20:28:47.830Z"
                                        },
                                        new
                                        {
                                            EventType = $"EventFlag.LobbySeason{season}",
                                            ActiveUntil = "2025-12-31T00:00:00.000Z",
                                            ActiveSince = "1337-01-01T20:28:47.830Z"
                                        }
                                    }
                                }
                            },
                            CacheExpire = "9999-01-01T22:28:47.830Z"
                        }
                    },
                    EventsTimeOffsetHrs = 0,
                    CacheIntervalMins = 10,
                    CurrentTime = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffZ")
                };

                await c.Response.WriteAsJsonAsync(response);
            });


        }
    }
}
