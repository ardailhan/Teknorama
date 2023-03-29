using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeknoramaBackOffice.Core.Domain;

namespace TeknoramaBackOffice.Persistance.Configurations.OrderConfigurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasOne(x => x.AppUser).WithMany(x => x.Orders).HasForeignKey(x => x.AppUserId);
            builder.HasOne(x => x.Shipper).WithMany(x => x.Orders).HasForeignKey(x => x.ShipperId);
            builder.HasOne(x => x.Employee).WithMany(x => x.Orders).HasForeignKey(x => x.EmployeeId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x => x.OrderDetails).WithOne(x => x.Order).HasForeignKey(x=> x.OrderId);
        }
    }
}
