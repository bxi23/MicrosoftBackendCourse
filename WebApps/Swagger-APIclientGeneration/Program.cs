using System.Collections.Concurrent;
using System.Net.Http;
using System.Threading.Tasks;
using BlogApi; // Add this line to import the namespace
//add swagger - swashbuckle
using  Swashbuckle.AspNetCore;
using  Microsoft.AspNetCore.OpenApi;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        var app = builder.Build();

        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"));
        app.MapControllers();

        // await new SwaggerClientGenerator().GenerateClient();

        app.MapGet("/", () => "Hello World!");

        app.Run();
    }
}

// Define the Blog class
public class Blog
{
    public required string Title { get; set; }
    public required string Body { get; set; }
}