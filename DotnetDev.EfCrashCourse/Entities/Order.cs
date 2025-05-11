using Microsoft.EntityFrameworkCore;

namespace DotnetDev.EfCrashCourse.Entities;

public class Order
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; }
    public int Quantity{ get; set; }
    public decimal Amount { get; set; }
}