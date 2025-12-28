using Entities;
using Microsoft.AspNetCore.Mvc;
using UseCase;

var builder = WebApplication.CreateBuilder(args);

// Register services (in-memory repo and use-case manager)

builder.Services.AddTransient<TodoListManager>();
builder.Services.AddSingleton<ITodoItemRepository, Infrastructure.InMemoryTodoItemRepository>();
// Swagger/OpenAPI for easy testing
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/todos", ( [FromServices] TodoListManager manager) => Results.Ok(manager.GetAllItems()));

app.MapGet("/todos/{id}", ( [FromServices] TodoListManager manager, [FromRoute] int id) =>
{
    var item = manager.GetItemById(id);
    return item is not null ? Results.Ok(item) : Results.NotFound();
});

app.MapPost("/todos", (TodoListManager manager,[FromBody] TodoItem item) =>
{
    manager.AddItem(item);
    return Results.Created($"/todos/{item.id}", item);
});

app.MapPut("/todos/{id}", ([FromServices] TodoListManager manager, [FromRoute] int id, [FromBody] TodoItem updated) =>
{
    if (id != updated.id) return Results.BadRequest("ID in path and body must match.");
    var success = manager.UpdateItem(updated);
    return success ? Results.NoContent() : Results.NotFound();
});

app.MapDelete("/todos/{id}", ([FromServices] TodoListManager manager, [FromRoute] int id) =>
{
    manager.DeleteItem(id);
    return Results.NoContent();
});

app.MapPost("/todos/{id}/toggle", ([FromServices] TodoListManager manager, [FromRoute] int id) =>
{
    try
    {
        manager.MarkItemComplete(id);
        return Results.NoContent();
    }
    catch (ArgumentException)
    {
        return Results.NotFound();
    }
});

app.Run();