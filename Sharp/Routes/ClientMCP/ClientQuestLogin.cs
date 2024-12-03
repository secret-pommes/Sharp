using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharp.Routes.ClientMCP
{
    public static class ClientQuestLogin
    {
        public static void MapClientQuestLogin(this WebApplication app)
        {
            app.MapPost("/fortnite/api/game/v2/profile/{accountId}/client/ClientQuestLogin", async (HttpContext c) =>
            {
                int.TryParse(c.Request.RouteValues["rvn"]?.ToString(), out int revision);
                string accountId = c.Request.RouteValues["accountId"].ToString();
                string profileId = c.Request.Query["profileId"].ToString();
                Console.WriteLine($"[ClientQuestLogin] Request {profileId} for {accountId}");

                var server_time = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");

                var json = new
                {
                    profileRevision = revision,
                    profileId,
                    profileChangesBaseRevision = revision,
                    profileChanges = Array.Empty<string>(),
                    profileCommandRevision = 0,
                    serverTime = server_time,
                    responseVersion = 1,
                };
                await c.Response.WriteAsJsonAsync(json);
            });
        }
    }
}
