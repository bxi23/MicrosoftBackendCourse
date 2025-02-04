using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);


// ========================================
// Build Section
// ========================================

// Add services for loggin, authentication , and authorization
// This service adds HTTP logging to your application. It logs HTTP request and response information.
builder.Services.AddHttpLogging(logging =>
{
    logging.LoggingFields = Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.All;
    logging.ResponseBodyLogLimit = 4096;
    logging.ResponseBodyLogLimit = 4096;
});

//This service adds authentication capabilities to your application. It allows you to configure authentication schemes and handle user authentication.
builder.Services.AddAuthentication();
// This service adds authorization capabilities to your application. It allows you to define policies and handle user authorization.
builder.Services.AddAuthorization();


var app = builder.Build();

// ========================================
// Configure Section
// ========================================


// Configure execption handling middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error"); // Blank 1: Use production exception handler.
}
else
{
    app.UseDeveloperExceptionPage(); // Blank 2: Use detailed error pages in development.
}

// 2
app.UseAuthentication(); // Authentication middleware
app.UseAuthorization(); // Authorization middleware

app.UseHttpLogging(); // HTTP logging middleware


// ========================================
// Custom Middleware
// ========================================
app.Use(async (context, next) =>
{
    Console.WriteLine($"Request Path: {context.Request.Path}");
    await next.Invoke();
    Console.WriteLine($"Response Status Code: {context.Response.StatusCode}");
});

app.Use(async (context, next) =>
{
    var startTime = DateTime.UtcNow;
    Console.WriteLine($"Start Time: {startTime}");
    await next.Invoke();
    var duration = DateTime.UtcNow - startTime;
    Console.WriteLine($"Response Time: {duration.TotalMilliseconds} ms");
});

// ========================================
// Endpoints
// ========================================
app.MapGet("/", () => "Hello World!");

app.MapGet("/Home/error", () => "Error Page");



app.Run();
