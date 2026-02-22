using DockerComposeDemoApp.Data;
using DockerComposeDemoApp.Extensions;
using DockerComposeDemoApp.Models;
using DockerComposeDemoApp.Services.Abstractions;
using DockerComposeDemoApp.Services.Implementations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);
builder.Services.AddScoped<ITodoItemRepository, TodoItemRepository>();

var app = builder.Build();

if (app.Environment.IsProduction())
{
    try
    {
        await app.UseDatabaseMigrationAsync();
    }
    catch (Exception e)
    {
        Console.WriteLine(e);
        throw;
    }
}
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet(
        "/todos",
        async (ITodoItemRepository repository) =>
        {
            try
            {
                var todos = await repository.GetAllTodoItemsAsync();
                return Results.Ok(todos);
            }
            catch (Exception e)
            {
                return Results.Problem(e.Message);
            }
        }
    )
    .WithName("GetAllTodoItems");

app.MapPost(
        "/todos",
        async (ITodoItemRepository repository, [FromBody] TodoItem item) =>
        {
            try
            {
                await repository.AddTodoItemAsync(item);
                return Results.Ok(item);
            }
            catch (Exception e)
            {
                return Results.Problem(e.Message);
            }
        }
    )
    .WithName("CreateTodoItem");

app.Run();
