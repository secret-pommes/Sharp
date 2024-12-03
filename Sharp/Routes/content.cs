using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Reflection.PortableExecutable;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

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
                    _activeDate = "2000-01-01T00:00:00.0000000Z",
                    lastModified = "2000-01-01T00:00:00.0000000Z",
                    _locale = "en-us",
                    _suggestedPrefetch = new String[] {},
                    _title = "Fortnite Game",
                    emergencynotice = new
                    {
                        _activeDate = "2000-01-01T00:00:00.0000000Z",
                        _locale = "en-us",
                        _noIndex = false,
                        _title = "emergencynotice",
                        alwaysShow = true,
                        lastModified = DateTime.UtcNow.ToString("o"), // Force Update.
                        news = new
                        {
                            _type = "Battle Royale News",
                            messages = new[] 
                            {
                                new 
                                {
                                    _type = "Battle Royale News",
                                    title = "Sharp",
                                    body = "Backend by not_secret1337\nhttps://github.com/secret-pommes/sharp",
                                    hidden = false,
                                    spotlight = true,
                                }
                            }
                        }
                    },
                    loginmessage = new
                    {
                        _title = "LoginMessage",
                        loginmessage = new
                        {
                            _type =  "CommonUI Simple Message Base",
                            title = "Sharp",
                            body = "Sharp is a fortnite backend written in C# using ASP.Net, made for learning C#\n\nSource:\nhttps://github.com/secret-pommes/sharp\nIf you plan on using this public please credit me (secret pommes or just not_secret1337)\n\nThank You :D",
                        },
                        _activeDate = "2000-01-01T00:00:00.0000000Z",
                        lastModified = "2000-01-01T00:00:00.0000000Z",
                        _locale = "en-us",
                    },
                    subgameselectdata = new
                    {
                        _title = "battleroyalenews",
                        header = "",
                        style = "None",
                        _noIndex = false,
                        _activeDate = "2000-01-01T00:00:00.0000000Z",
                        lastModified = "2000-01-01T00:00:00.0000000Z",
                        _locale = "en-us",
                        battleRoyale = new
                        {
                            message = new {
                                image = "",
                                hidden =  false,
                                messagetype = "normal",
                                _type = "CommonUI Simple Message Base",
                                title =  "100 Player PvP",
                                body = "100 Player PvP Battle Royale.\n\nPvE progress does not affect Battle Royale.",
                                spotlight = false,
                            },
                        },
                        saveTheWorldUnowned = new
                        {
                            message = new
                            {
                                image = "",
                                hidden = false,
                                messagetype = "normal",
                                _type = "CommonUI Simple Message Base",
                                title = "Co-op PvE",
                                body = "Cooperative PvE storm-fighting adventure!",
                                spotlight = false,
                            },
                        },
                        creative = new
                        {
                            message = new
                            {
                                image = "",
                                hidden = false,
                                messagetype = "normal",
                                _type = "CommonUI Simple Message Base",
                                title = "New Featured Islands!",
                                body = "Your Island. Your Friends. Your Rules.\n\nDiscover new ways to play Fortnite, play community made games with friends and build your dream island.",
                                spotlight = false,
                            },
                        }
                    },
                    playlistimages = new
                    {
                        _title = "playlistimages",
                        _activeDate = "2000-01-01T00:00:00.0000000Z",
                        lastModified = "2000-01-01T00:00:00.0000000Z",
                        _locale = "en-us",
                        playlistimages = new
                        {
                            _type = "PlaylistImageList",
                            images = new[]
                            {
                                new
                                {
                                    image = "https://cdn.eclipsemp.org/legacy_solo.png",
                                    _type = "PlaylistImageEntry",
                                    playlistname = "Playlist_DefaultSolo",
                                },
                                new
                                {
                                    image = "https://cdn.eclipsemp.org/legacy_solo.png",
                                    _type = "PlaylistImageEntry",
                                    playlistname = "Playlist_DefaultDuo",
                                },
                                new             
                                {
                                    image = "https://cdn.eclipsemp.org/legacy_solo.png",
                                    _type = "PlaylistImageEntry",
                                    playlistname = "Playlist_DefaultSquad",
                                }

                            }
                        }
                    }
                });
                c.Response.ContentType = "application/json";
                await c.Response.WriteAsync(json);
            });
        }
    }
}
