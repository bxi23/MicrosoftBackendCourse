using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


// Instiate used variables
List<Person> persons = new List<Person>();

app.MapGet("/", () =>
{
    return Results.Text("Hello World");
});

app.MapPost("/auto", (Person personFromClient) =>
{
    return TypedResults.Ok(personFromClient);
});


app.MapPost("/json", async (HttpContext context) =>
{
    var person = await context.Request.ReadFromJsonAsync<Person>();
    if (person != null && !string.IsNullOrEmpty(person.UserName) && person.UserAge > 0)
    {
        persons.Add(person);
        return Results.Json(person);
    }
    return Results.BadRequest();
});

app.MapPost("custom-options", async (HttpContext context) =>
{
   var options = new JsonSerializerOptions
   {
       UnmappedMemberHandling = JsonUnmappedMemberHandling.Disallow
   };
   var person = await context.Request.ReadFromJsonAsync<Person>();
   return Results.Json(person, options);
});


app.MapGet("/json", () =>
{
    return Results.Ok(persons);
});

app.Run();

public class Person
{
    public string UserName { get; set; }
    public int UserAge { get; set; }
}