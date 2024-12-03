using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Hosting;
using Sharp.Routes;
using Sharp.Utils;
using Sharp.Routes.ClientMCP;

var builder = WebApplication.CreateBuilder(args);   
var app = builder.Build();

// MCP
app.MapQueryProfile();
app.MapSetMtxPlatform();
app.MapClientQuestLogin();

// Routes
app.MapFortnite();
app.MapLightswitch();
app.MapWaitingroom();
app.MapAccount();
app.MapDatarouter();
app.MapContent();

// 404 common methods fn uses.
app.MapGet("/{*url}", (HttpContext c) => Error.NotFound(c));
app.MapDelete("/{*url}", (HttpContext c) => Error.NotFound(c));
app.MapPost("/{*url}", (HttpContext c) => Error.NotFound(c));
app.MapPatch("/{*url}", (HttpContext c) => Error.NotFound(c));
app.MapPut("/{*url}", (HttpContext c) => Error.NotFound(c));

app.Run();
