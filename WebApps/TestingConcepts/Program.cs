var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "I am root!");

var blogs = new List<Blog>
{
    new Blog { Title = "My 1st Post", Body = "This is my 1st post" },
    new Blog { Title = "My 2nd Post", Body = "This is my 2nd post" },
    new Blog { Title = "My 3rd Post", Body = "This is my 3rd post" }
};

app.MapGet("/blogs", () => blogs);

app.MapGet("/blogs/{id}", (int id) =>
{
    if (id < 0 || id >= blogs.Count)
    {
        return Results.NotFound("Blog not found");
    }
    return Results.Ok(blogs[id]);
});

app.MapPost("/blogs", (Blog blog) =>
{
    blogs.Add(blog);
    return Results.Created($"/blogs/{blogs.Count - 1}", blog);
});

app.MapDelete("/blogs/{id}", (int id) =>
{
    if (id < 0 || id >= blogs.Count)
    {
        return Results.NotFound("Blog not found");
    }
    blogs.RemoveAt(id);
    return Results.Ok($"I deleted blog at id {id}");
});

app.MapPut("/blogs/{id}", (int id, Blog updatedBlog) =>
{
    if (id < 0 || id >= blogs.Count)
    {
        return Results.NotFound("Blog not found");
    }
    blogs[id] = updatedBlog;
    return Results.Ok(updatedBlog);
});

app.Run();

public class Blog
{
    public string Title { get; set; }
    public string Body { get; set; }
}