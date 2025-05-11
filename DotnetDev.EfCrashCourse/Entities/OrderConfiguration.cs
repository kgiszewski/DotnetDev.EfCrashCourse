using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotnetDev.EfCrashCourse.Entities;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        //our schema/table
        builder.ToTable("orders", "billing");
        //indicating we have one customer than can have many orders and is keyed with CustomerId
        builder.HasOne<Customer>().WithMany().HasForeignKey(x => x.CustomerId);
    }
}