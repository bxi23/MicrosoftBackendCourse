var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Root Path");
app.MapGet("/downloads", () => "Downloads");
app.MapPut("/", () => "This is a PUT method");
app.MapPost("/", () => "This is a POST method");
app.MapDelete("/", () => "This is a DELETE method");

app.Run();