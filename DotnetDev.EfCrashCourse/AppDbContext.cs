using DotnetDev.EfCrashCourse.Entities;
using Microsoft.EntityFrameworkCore;

namespace DotnetDev.EfCrashCourse;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Customer> Customers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}