using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DotnetDev.EfCrashCourse.DependencyInjection;

public static class Register
{
    public static void AddPostgresDatabase(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>((_, options) =>
        {
            options.UseNpgsql($"Host=localhost:5432;Database=postgres;Username=postgres;Password=postgres;")
                .UseSnakeCaseNamingConvention();
        });
    }
}