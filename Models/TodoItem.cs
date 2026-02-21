using System.ComponentModel.DataAnnotations;

namespace DockerComposeDemoApp.Models;

public sealed class TodoItem
{
    [Key]
    public Guid Id { get; init; } = Guid.NewGuid();

    [MaxLength(100)]
    [Required]
    public string Title { get; init; } = string.Empty;
    public bool IsCompleted { get; init; } = false;

    [MaxLength(100)]
    public string Description { get; init; } = string.Empty;
}
