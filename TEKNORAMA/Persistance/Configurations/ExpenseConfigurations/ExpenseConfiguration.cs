using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeknoramaBackOffice.Core.Domain;

namespace TeknoramaBackOffice.Persistance.Configurations.ExpenseConfigurations
{
    public class ExpenseConfiguration : IEntityTypeConfiguration<Expense>
    {
        public void Configure(EntityTypeBuilder<Expense> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Amount).HasColumnType("decimal(18,2)");
            builder.Property(e => e.Description).HasMaxLength(500);
            builder.Property(e => e.ExpenseType).HasConversion<string>();
        }
    }
}
