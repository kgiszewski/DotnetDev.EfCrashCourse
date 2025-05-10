using Microsoft.EntityFrameworkCore;

namespace DotnetDev.EfCrashCourse.Entities;

[PrimaryKey("FirstName")]
public class Customer
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}