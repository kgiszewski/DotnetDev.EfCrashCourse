using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotnetDev.EfCrashCourse.Entities;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        //our schema/table
        builder.ToTable("orders", "billing");
        builder.HasKey(x => x.Id);
    }
}