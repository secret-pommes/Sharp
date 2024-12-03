using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharp.Routes
{
    internal static class Rwaitingroom
    {
        public static void MapWaitingroom(this WebApplication web)
        {
            var app = web.MapGroup("/waitingroom");

            app.MapGet("/api/waitingroom", (HttpContext c) =>
            {
                c.Response.StatusCode = 204;
                return "";
            });
        }
    }
}
