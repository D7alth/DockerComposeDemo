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

    public Task<IEnumerable<TodoItem>> GetAllTodoItemsAsync() =>
        dbContext.TodoItems.ToListAsync().ContinueWith(t => t.Result.AsEnumerable());

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
