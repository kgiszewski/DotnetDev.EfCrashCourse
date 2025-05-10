using DotnetDev.EfCrashCourse;
using DotnetDev.EfCrashCourse.DependencyInjection;
using DotnetDev.EfCrashCourse.Entities;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

services.AddPostgresDatabase();

var provider = services.BuildServiceProvider();

var dbContext = provider.GetRequiredService<AppDbContext>();

dbContext.Customers.Add(new Customer
{
    Id = Guid.NewGuid(),
    FirstName = "Homer",
    LastName = "Simpson"
});

await dbContext.SaveChangesAsync();