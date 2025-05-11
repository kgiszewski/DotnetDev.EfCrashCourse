using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DotnetDev.EfCrashCourse.DependencyInjection;

/// <summary>
/// This class is needed to handle migrations since we don't have a host builder
///
/// https://learn.microsoft.com/en-us/ef/core/cli/dbcontext-creation?tabs=dotnet-core-cli#from-a-design-time-factory
/// </summary>
public class DesignTimeFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        
        optionsBuilder.UseNpgsql($"Host=localhost:5432;Database=postgres;Username=postgres;Password=postgres;")
            .UseSnakeCaseNamingConvention();
        
        return new AppDbContext(optionsBuilder.Options);
    }
}