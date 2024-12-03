using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Hosting;
using Sharp.Routes;
using Sharp.Utils;

var builder = WebApplication.CreateBuilder(args);   
var app = builder.Build();

app.MapWaitingroom();
app.MapAccount();
app.MapDatarouter();
app.MapContent();

app.MapGet("/{*url}", (HttpContext c) => Error.NotFound(c));

app.Run();
