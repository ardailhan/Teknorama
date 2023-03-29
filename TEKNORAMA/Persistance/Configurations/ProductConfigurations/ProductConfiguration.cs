using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeknoramaBackOffice.Core.Domain;

namespace TeknoramaBackOffice.Persistance.Configurations.ProductConfigurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasOne(x=>x.Category).WithMany(x => x.Products).HasForeignKey(x => x.CategoryId);
            builder.HasOne(x=>x.Supplier).WithMany(x => x.Products).HasForeignKey(x => x.SupplierId);
            builder.HasMany(x=>x.OrderDetails).WithOne(x=>x.Product).HasForeignKey(x => x.ProductId);
        }
    }
}