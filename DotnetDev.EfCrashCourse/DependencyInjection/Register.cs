using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DotnetDev.EfCrashCourse.DependencyInjection;

public static class Register
{
    public static void AddPostgresDatabase(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>((serviceProvider, options) =>
        {
            options.UseNpgsql("");
        });
    }
}