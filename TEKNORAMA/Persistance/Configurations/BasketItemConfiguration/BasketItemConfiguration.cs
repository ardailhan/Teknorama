using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeknoramaBackOffice.Core.Domain;

namespace TeknoramaBackOffice.Persistance.Configurations.BasketItemConfiguration
{
    public class BasketItemConfiguration : IEntityTypeConfiguration<BasketItem>
    {
        public void Configure(EntityTypeBuilder<BasketItem> builder)
        {
            builder.HasOne(x=>x.Product).WithMany(x => x.BasketItems).HasForeignKey(x=>x.ProductId);
            builder.HasOne(x => x.Basket).WithMany(x => x.BasketItems).HasForeignKey(x => x.BasketId);
        }
    }
}
