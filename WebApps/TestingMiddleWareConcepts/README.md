# Middleware in ASP.NET Core

Middleware in ASP.NET Core is software that's assembled into an application pipeline to handle requests and responses. Each component in the pipeline can either handle the request directly or pass it to the next component. Middleware can perform various tasks such as authentication, logging, error handling, and more.

## Why Middleware is Used
1. **Modularity**: Middleware allows you to break down your application into smaller, manageable pieces.
2. **Reusability**: Middleware components can be reused across different applications.
3. **Order of Execution**: Middleware components are executed in the order they are added to the pipeline, giving you control over the request processing flow.
4. **Separation of Concerns**: Middleware helps in separating different aspects of request processing, making the code cleaner and more maintainable.

## Explanation of the Lab
In this lab, you are exploring the concept of middleware by creating custom middleware components and understanding their order of execution. Here is the code from `Program.cs`:

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpLogging((o)=>{});
var app = builder.Build();

// Built-in Middleware logic - not meant to be uncommented just showing the order of middleware
// only change these to change default behavior of .Net
// app.UseRouting()
// app.useAuthentication()
// app.UseAuthorization()
// app.UseExceptionHandler() - only in debugging

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

// Built-in Middleware logic - not meant to be uncommented just showing the order of middleware
// only change these to change default behavior of .Net
// app.UseEndpoints()

app.Run();


## Point of the Lab
Custom Middleware: You are creating custom middleware components using app.Use. Each middleware logs messages before and after calling next.Invoke(), which passes control to the next middleware in the pipeline.
Order of Execution: The order in which middleware components are added is crucial. The lab demonstrates how middleware components are executed in sequence and how the order affects the request processing.
HttpLogging Middleware: The app.UseHttpLogging() middleware is used to log HTTP requests. By placing it at different points in the pipeline, you can observe how the logging behavior changes.
This lab helps you understand the fundamentals of middleware in ASP.NET Core, how to create custom middleware, and the importance of the order in which middleware components are added to the pipeline. ```