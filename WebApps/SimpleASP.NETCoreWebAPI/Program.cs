using SimpleASP.NETCoreWebAPI.Models;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

var items = new List<Item>
{
    new Item { Id = 1, Name = "Item 1", Description = "Description for Item 1", Price = 10.0M },
    new Item { Id = 2, Name = "Item 2", Description = "Description for Item 2", Price = 20.0M },
    new Item { Id = 3, Name = "Item 3", Description = "Description for Item 3", Price = 30.0M }
};

// Basic routes

app.MapGet("/", () => "Welcome to the Simple Web API!");

app.MapGet("/items", () => items);

app.MapGet("/items/{id}", (int id) =>
{
    if (id < 0 || id >= items.Count)
    {
        return Results.NotFound("Blog not found");
    }
    return Results.Ok(items[id]);
});

app.MapPost("/items", (Item item) =>
{
    items.Add(item);
    return Results.Created($"/items/{item.Id}", item);
});

app.MapPut("/items/{id}", (int id, Item item) =>
{
    if (id < 0 || id >= items.Count)
    {
        return Results.NotFound("Blog not found");
    }
    items[id] = item;
    return Results.Ok(item);
});

app.MapDelete("/items/{id}", (int id) =>
{
    if (id < 0 || id >= items.Count)
    {
        return Results.NotFound("Blog not found");
    }
    items.RemoveAt(id);
    return Results.NoContent();
});

app.Run();
