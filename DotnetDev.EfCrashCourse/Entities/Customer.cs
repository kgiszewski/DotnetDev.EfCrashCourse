using Microsoft.EntityFrameworkCore;

namespace DotnetDev.EfCrashCourse.Entities;

[PrimaryKey("Id")]
public class Customer
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}