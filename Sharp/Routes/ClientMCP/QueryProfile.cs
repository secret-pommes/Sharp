using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharp.Routes.ClientMCP
{
    public static class QueryProfile
    {
        public static void MapQueryProfile(this WebApplication app)
        {
            app.MapPost("/fortnite/api/game/v2/profile/{accountId}/client/QueryProfile", async (HttpContext c) =>
            {
                string accountId = c.Request.RouteValues["accountId"].ToString();
                string profileId = c.Request.Query["profileId"].ToString();
                Console.WriteLine($"Request {profileId} for {accountId}");

                var json = new { };
                await c.Response.WriteAsJsonAsync( json );
            });
        }
    }
}
