using DotnetDev.EfCrashCourse;
using DotnetDev.EfCrashCourse.DependencyInjection;
using DotnetDev.EfCrashCourse.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

//setup DI
var services = new ServiceCollection();

services.AddPostgresDatabase();

var provider = services.BuildServiceProvider();

//get a reference to the DB, keep in mind EF is not thread-safe
var dbContext = provider.GetRequiredService<AppDbContext>();

//add a customer
var customerId = Guid.NewGuid();

dbContext.Customers.Add(new Customer
{
    Id = customerId,
    FirstName = "Homer",
    LastName = "Simpson"
});

//complete a unit of work
await dbContext.SaveChangesAsync();

//get and track changes
var customer = await dbContext.Customers.SingleAsync(x => x.Id == customerId);

//update first name
customer.FirstName = "Bart";

//save a unit of work
await dbContext.SaveChangesAsync();

//get without tracking, by default it won't be writable since it's not tracked
customer = await dbContext.Customers.AsNoTracking().SingleAsync(x => x.Id == customerId);

customer.FirstName = "Marge";

await dbContext.SaveChangesAsync(); // won't save Marge b/c the entity isn't being tracked

var customProjection = await dbContext
    .Customers
    //queryable
    .Where(x => x.Id == customerId)
    //custom SELECT
    .Select(x => new { x.Id, x.FirstName })
    //materialize it
    .SingleAsync(); //Anonymous object Id: <guid>, FirstName: Bart

//add an order
dbContext.Add(new Order
{
    CustomerId = customerId,
    Quantity = 1,
    Amount = 1.23m
});

await dbContext.SaveChangesAsync();

//works, but not ideal
var includedListOfOrdersFromPeopleNamedBart = await dbContext
                       .Orders
                       .Include(x => x.Customer)
                       .Where(x => x.Customer.FirstName == "Bart")
                       .ToListAsync();

//inner join
var joinedListOfOrdersFromPeopleNamedBart = await dbContext
    .Orders
    .Join<Order, Customer, Guid, object>(
        dbContext.Customers,
        x => x.CustomerId,
        x => x.Id,
        (orderTable, customerTable) => new
        {
            //things to select
            orderTable.CustomerId,
            customerTable.FirstName
        }
    //anon list
    ).ToListAsync();

Console.ReadKey();