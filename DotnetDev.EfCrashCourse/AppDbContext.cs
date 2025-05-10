using DotnetDev.EfCrashCourse.Entities;
using Microsoft.EntityFrameworkCore;

namespace DotnetDev.EfCrashCourse;

public class AppDbContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}