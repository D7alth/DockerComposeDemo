using DockerComposeDemoApp.Data;
using DockerComposeDemoApp.Models;
using DockerComposeDemoApp.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace DockerComposeDemoApp.Services.Implementations;

public class TodoItemRepository(AppDbContext dbContext) : ITodoItemRepository
{
    public Task AddTodoItemAsync(TodoItem item)
    {
        dbContext.TodoItems.Add(item);
        return dbContext.SaveChangesAsync();
    }

    public Task<TodoItem?> GetTodoItemAsync(Guid id) => dbContext.TodoItems.FindAsync(id).AsTask();

    public async Task<IList<TodoItem>> GetAllTodoItemsAsync()
    {
        var todoItems = await dbContext.TodoItems.ToListAsync();
        return todoItems;
    }

    public Task UpdateTodoItemAsync(TodoItem item)
    {
        dbContext.TodoItems.Update(item);
        return dbContext.SaveChangesAsync();
    }

    public async Task DeleteTodoItemAsync(Guid id)
    {
        var todoItem = await dbContext.TodoItems.FindAsync(id);
        if (todoItem is null)
            return;
        dbContext.TodoItems.Remove(todoItem);
        await dbContext.SaveChangesAsync();
    }
}
