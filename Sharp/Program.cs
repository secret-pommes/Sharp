using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Hosting;
using Sharp.Routes;

var builder = WebApplication.CreateBuilder(args);   
var app = builder.Build();

app.MapDatarouter();
app.MapContent();


app.MapGet("/{*url}", (HttpContext context) =>
{
    Console.WriteLine($"Unmatched route accessed: {context.Request.Path}");

    context.Response.StatusCode = 404;
    context.Response.Headers.Add("Error", "404");

    return "Error 404: Not Found";
});

app.Run();
