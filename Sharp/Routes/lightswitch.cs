using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharp.Routes
{
    internal static class Rlightswitch
    {
        public static void MapLightswitch(this WebApplication web)
        {
            var app = web.MapGroup("/lightswitch");

            app.MapGet("/api/service/Fortnite/status", async (HttpContext c) =>
            {
                // not the best, but idk how i should do it else :(
                var overrideCatalogIds = new String[]
                {
                    "a7f138b2e51945ffbfdacc1af0541053",
                };

                var json = new
                {
                    serviceInstanceId = "fortnite",
                    status = "UP",
                    message = "Fortnite is online",
                    maintenanceUri = String.Empty,
                    overrideCatalogIds,
                    allowedActions = Array.Empty<string>(),
                    banned = false,
                    launcherInfoDTO = new 
                    {
                        appName = "Fortnite",
                        catalogItemId = "4fe75bbc5a674f4f9b356b5c90567da5",
                        @namespace = "fn",
                    }
                };

                await c.Response.WriteAsJsonAsync(json);
            });

            app.MapGet("/api/service/bulk/status", async (HttpContext c) =>
            {
                // not the best, but idk how i should do it else :(
                var overrideCatalogIds = new String[] 
                {
                    "a7f138b2e51945ffbfdacc1af0541053",
                };

                var allowedActions = new String[] 
                {
                    "PLAY",
                    "DOWNLOAD",
                };

                allowedActions[0] = "PLAY";

                var json = new[]
                {
                    new
                    {
                        serviceInstanceId = "fortnite",
                        status = "UP",
                        message = "fortnite is up",
                        maintenanceUri = string.Empty,
                        overrideCatalogIds,
                        allowedActions,
                        banned = false,
                        launcherInfoDTO = new
                        {
                            appName = "Fortnite",
                            catalogItemId = "4fe75bbc5a674f4f9b356b5c90567da5",
                            @namespace = "fn",
                        },
                    }
                };

                await c.Response.WriteAsJsonAsync(json);
            });
        }
    }
}
