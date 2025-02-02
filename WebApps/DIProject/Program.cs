using DIProject;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Adds a singleton service of the type specified in TService (IMyService) with an implementation type specified in TImplementation (MyService).
// Singleton services are created the first time they are requested (or when ConfigureServices is run if you specify an instance there) and then every subsequent request will use the same instance.
builder.Services.AddSingleton<IMyService, MyService>();

// Adds a scoped service of the type specified in TService (IMyService) with an implementation type specified in TImplementation (MyService).
// Scoped services are created once per client request (connection).
// builder.Services.AddScoped<IMyService, MyService>(); 

// Adds a transient service of the type specified in TService (IMyTransientService) with an implementation type specified in TImplementation (MyTransientService).
// Transient services are created each time they are requested. This lifetime works best for lightweight, stateless services.
// builder.Services.AddTransient<IMyService, MyService>();

var app = builder.Build();

app.Use(async (context, next) =>
{
    var myService = context.RequestServices.GetRequiredService<IMyService>();
    myService.LogCreation("First middleware");
    await next.Invoke();
});

app.Use(async (context, next) =>
{
    var myService = context.RequestServices.GetRequiredService<IMyService>();
    myService.LogCreation("Second middleware");
    await next.Invoke();
});

app.MapGet("/", (IMyService myService) =>
{
    myService.LogCreation("Root");
    return Results.Ok("Check the console for service creation logs");
});

app.Run();
