using DockerComposeDemoApp.Data;
using Microsoft.EntityFrameworkCore;

namespace DockerComposeDemoApp.Extensions;

public static class DatabaseExtensions
{
    public static async Task<IApplicationBuilder> UseDatabaseMigrationAsync(
        this IApplicationBuilder app
    )
    {
        using var scope = app.ApplicationServices.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        try
        {
            await context.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
        return app;
    }
}
