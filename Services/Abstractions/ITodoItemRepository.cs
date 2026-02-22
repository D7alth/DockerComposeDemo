using DockerComposeDemoApp.Models;

namespace DockerComposeDemoApp.Services.Abstractions;

public interface ITodoItemRepository
{
    Task AddTodoItemAsync(TodoItem item);
    Task<TodoItem?> GetTodoItemAsync(Guid id);
    Task<IList<TodoItem>> GetAllTodoItemsAsync();
    Task UpdateTodoItemAsync(TodoItem item);
    Task DeleteTodoItemAsync(Guid id);
}
