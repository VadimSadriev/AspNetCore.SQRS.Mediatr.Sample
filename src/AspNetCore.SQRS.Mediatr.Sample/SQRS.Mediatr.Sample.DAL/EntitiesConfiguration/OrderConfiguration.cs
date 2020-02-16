using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SQRS.Mediatr.Sample.DAL.Entities;

namespace SQRS.Mediatr.Sample.DAL.EntitiesConfiguration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");

            builder.Property(x => x.Name)
                .HasColumnName("name");

            builder.Property(x => x.CustomerId)
                .IsRequired()
                .HasColumnName("customer_id");

            builder.HasOne(x => x.Customer)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.CustomerId);

            builder.ToTable("orders");
        }
    }
}
