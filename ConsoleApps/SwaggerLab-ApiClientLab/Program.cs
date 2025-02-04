using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using System.Threading.Tasks;
using SwaggerLab_ApiClientLab;



class Program
{
    public static async Task Main(string[] args)
    {
        //Web application Create Builder
        var builder = WebApplication.CreateBuilder(args);

        //Add builder services - addControllers, addEndpointsApiExplorer, addSwaggerGen
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        //build app
        var app = builder.Build();

        //Utlize swagger on app
        app.UseSwagger();
        //configure swagger endpoint /swagger/v1/swagger.json
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SwaggerLab_ApiClientLab v1"));

        //map contollers
        app.MapControllers();


        Task.Run(() => app.RunAsync());

        //Below the code that starts the server, add an awaited delay of 3 seconds or more. This will let the server start up before you generate the client code.
        await Task.Delay(3000);

        //Below the delay, add an awaited call to the GenerateClient method in the ClientGenerator class.
        // Console.WriteLine("Generating client...");

        // try {
        //     await new ClientGenerator().GenerateClient();
        // }
        // catch (Exception ex) {
        //     Console.WriteLine($"Error generating client: {ex.Message}");
        // }
        //After the client code is generated, add a call to the Main method in the Program class.
        var httpClient = new HttpClient();
        var client = new CustomApiClient("http://localhost:5000", httpClient);

        var user = await client.UserAsync(1);
        Console.WriteLine($"User: {user.Name}");

    }
}