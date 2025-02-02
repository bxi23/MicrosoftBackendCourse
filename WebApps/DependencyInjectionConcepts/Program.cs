var builder = WebApplication.CreateBuilder(args);

// Register IMyService with a singleton lifetime
// Singleton services are created the first time they are requested
// and then every subsequent request will use the same instance.
builder.Services.AddSingleton<IMyService, MyService>();

// Transient services are created each time they are requested.
// builder.Services.AddTransient<IMyService, MyService>();

var app = builder.Build();

app.Use(async (context, next) =>
{
    var myService = context.RequestServices.GetRequiredService<IMyService>();
    myService.LogCreation("First middleware");
    await next();
});

app.Use(async (context, next) =>
{
    var myService = context.RequestServices.GetRequiredService<IMyService>();
    myService.LogCreation("Second middleware");
    await next();
});

app.MapGet("/", (IMyService myService) => {
    myService.LogCreation("Root");
    return Results.Ok("Check the console for service creation logs");
});

app.Run();

public interface IMyService
{
    void LogCreation(string message);
}

public class MyService: IMyService
{
    private readonly int _serviceId;

    public MyService()
    {
        _serviceId = new Random().Next(1, 1000);
    }

    public void LogCreation(string message)
    {
        Console.WriteLine($"Service {_serviceId} created: {message}");
    }
}