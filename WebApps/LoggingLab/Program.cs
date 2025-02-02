using LoggingLab.Controllers;
using Microsoft.Extensions.Logging;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Configure Serilog
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

builder.Host.UseSerilog();

var app = builder.Build();

var controller = new ErrorHandlingController();

// Middleware
app.Use(async (context, next) =>
{
    var logger = app.Services.GetRequiredService<ILogger<Program>>();
    try
    {
        int result = controller.GetDivisionResult(10, 0); // Example values
        await context.Response.WriteAsync($"Result: {result}");
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "An error occurred while processing the request.");
        context.Response.StatusCode = 500;
        await context.Response.WriteAsync($"An error occurred: {ex.Message} \n An unexpected error occurred. Please try again later.");
    }
    await next();
});

app.MapGet("/", () => "Hello World!");

app.Run();
