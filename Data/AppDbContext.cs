using DockerComposeDemoApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DockerComposeDemoApp.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<TodoItem> TodoItems { get; set; }
};