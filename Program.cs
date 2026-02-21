using DockerComposeDemoApp.Data;
using DockerComposeDemoApp.Models;
using DockerComposeDemoApp.Services.Abstractions;
using DockerComposeDemoApp.Services.Implementations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddScoped(_ => new AppDbContext(
    new DbContextOptionsBuilder<AppDbContext>()
        .UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
        .Options
));
builder.Services.AddScoped<ITodoItemRepository, TodoItemRepository>();

var app = builder.Build();

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
