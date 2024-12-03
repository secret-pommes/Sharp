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
                var json = new
                {
                    access_token = "access_sharp",
                    expires_in = 28800,
                    expires_at = "9999-12-02T01:12:01.100Z",
                    token_type = "bearer",
                    refresh_token = "refresh_sharp",
                    refresh_expires = 86400,
                    refresh_expires_at = "9999-12-02T01:12:01.100Z",
                    account_id = "Sharp",
                    client_id = "clientId",
                    internal_client = true,
                    client_service = "fortnite",
                    displayName = "Sharp",
                    app = "fortnite",
                    in_app_id = "Sharp",
                    device_id = "deviceId",
                };

                c.Response.ContentType = "application/json";
                await c.Response.WriteAsJsonAsync(json);
            });

            app.MapDelete("/api/oauth/sessions/kill", async (HttpContext c) =>
            {
                c.Response.StatusCode = 204;
                await Task.CompletedTask;
            });

            app.MapDelete("/api/oauth/sessions/kill/{access_token}", async (HttpContext c) => {
                c.Response.StatusCode = 204;
                await Task.CompletedTask;
            });

            app.MapGet("/api/public/account/{accountId}", async (HttpContext c) =>
            {
                var accountId = c.Request.RouteValues["accountId"]?.ToString();
                Console.WriteLine($"User {accountId}");

                var json = new
                {
                    id = accountId,
                    displayName = accountId,
                    name = "Sharp",
                    email = "user@sharp.de",
                    failedLoginAttempts = 0,
                    lastLogin = "1337-12-02T01:12:01.100Z",
                    numberOfDisplayNameChanges = 0,
                    ageGroup = "UNKNOWN",
                    headless = false,
                    country = "DE",
                    lastName = "Server",
                    preferredLanguage = "de",
                    canUpdateDisplayName = false,
                    tfaEnabled = false,
                    emailVerified = true,
                    minorVerified = false,
                    minorExpected = false,
                    minorStatus = "NOT_MINOR",
                    cabinedMode = false,
                    hasHashedEmail = false,
                };

                c.Response.ContentType = "application/json";
                await c.Response.WriteAsJsonAsync(json);
            });

            app.MapGet("/api/public/account/{accountId}/externalAuths", async (HttpContext c) =>
            {
                var json = new { };
                c.Response.ContentType = "application/json";
                await c.Response.WriteAsJsonAsync(json);
            });

            app.MapGet("/api/public/account", async (HttpContext c) => {
                var id = c.Request.Query["accountId"].ToString();
                var json = new[]
                { 
                    new
                    {
                        id,
                        displayName = id,
                        externalAuths = new {},
                    },
                };

                c.Response.ContentType = "application/json";
                await c.Response.WriteAsJsonAsync(json);
            });

            app.MapGet("/api/oauth/verify", async (HttpContext c) => {
                var json = new 
                {
                    token = "access_sharp",
                    session_id = "sessionId",
                    token_type = "bearer",
                    client_id = "clientId",
                    internal_client = true,
                    client_service = "fortnite",
                    account_id = "Sharp",
                    expires_in  = 28800,
                    expires_at = "9999-12-02T01:12:01.100Z",
                    auth_method = "password",
                    display_name = "Sharp",
                    app = "fortnite",
                    in_app_id = "Sharp",
                    device_id = "deviceId",
                };

                c.Response.ContentType = "application/json";
                await c.Response.WriteAsJsonAsync(json);
            });
        }
    }
}
