using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeknoramaBackOffice.Core.Domain;

namespace TeknoramaBackOffice.Persistance.Configurations.BasketConfigurations
{
    public class BasketConfiguration : IEntityTypeConfiguration<Basket>
    {
        public void Configure(EntityTypeBuilder<Basket> builder)
        {
            builder.HasOne(x => x.AppUser).WithMany(x => x.Baskets).HasForeignKey(x => x.AppUserId);
            builder.HasOne(y => y.Order).WithOne(z => z.Basket).HasForeignKey<Order>(x => x.Id).OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
