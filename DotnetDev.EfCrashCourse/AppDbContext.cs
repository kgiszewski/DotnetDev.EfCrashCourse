using DotnetDev.EfCrashCourse.Entities;
using Microsoft.EntityFrameworkCore;

namespace DotnetDev.EfCrashCourse;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //maps our entity to the schema/table name
        modelBuilder.Entity<Customer>().ToTable("customers", "billing");
        
        //this line enables the orders configuration in another file
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}