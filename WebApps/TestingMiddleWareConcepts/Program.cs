var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpLogging((o)=>{});
var app = builder.Build();

//Built in Middleware logic - not meant to be uncommented just showing the order of middleware
//only change these to change default behavior of .Net
//app.UseRouting()
//app.useAuthentication()
//app.UseAuthorization()
//app.UseExceptionHandler() - only in debugging


// If UseHttpLogging is placed here, it will log all HTTP requests before any middleware is executed
// app.UseHttpLogging();

// Create Middleware
app.Use(async (context, next) =>
{
    // Logic here
    Console.WriteLine("Logic before 1");
    await next.Invoke();
    Console.WriteLine("Logic after 1");
});
app.Use(async (context, next) =>
{
    // Logic here
    Console.WriteLine("Logic before 2");
    await next.Invoke();
    Console.WriteLine("Logic after 2");
});
app.Use(async (context, next) =>
{
    // Logic here
    Console.WriteLine("Logic before 3");
    await next.Invoke();
    Console.WriteLine("Logic after 3");
});

// UseHttpLogging here will log HTTP requests after the above middleware has been executed
app.UseHttpLogging();

app.MapGet("/", () => "Hello World!");
app.MapGet("/hello", () => "This is the hello route");


//Built in Middleware logic - not meant to be uncommented just showing the order of middleware
//only change these to change default behavior of .Net
//app.UseEndpoints()

app.Run();