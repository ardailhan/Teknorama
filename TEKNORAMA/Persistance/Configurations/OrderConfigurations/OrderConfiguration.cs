using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeknoramaBackOffice.Core.Domain;

namespace TeknoramaBackOffice.Persistance.Configurations.OrderConfigurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Shipper).WithMany(x => x.Orders).HasForeignKey(x => x.ShipperId);
            builder.HasOne(x => x.Employee).WithMany(x => x.Orders).HasForeignKey(x => x.EmployeeId).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasOne(x => x.CompletedOrder).WithOne(y => y.Order).HasForeignKey<CompletedOrder>(f => f.OrderId);
        }
    }
}
