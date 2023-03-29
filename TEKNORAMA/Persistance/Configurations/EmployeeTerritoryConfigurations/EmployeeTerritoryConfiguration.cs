using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeknoramaBackOffice.Core.Domain;

namespace TeknoramaBackOffice.Persistance.Configurations.EmployeeTerritoryConfigurations
{
    public class EmployeeTerritoryConfiguration : IEntityTypeConfiguration<EmployeeTerritory>
    {
        public void Configure(EntityTypeBuilder<EmployeeTerritory> builder)
        {
            builder.HasOne(x => x.Territory).WithMany(x => x.EmployeeTerritories).HasForeignKey(x => x.TerritoryId);
            builder.HasOne(x => x.Employee).WithMany(x => x.EmployeeTerritories).HasForeignKey(x => x.EmployeeId);
        }
    }
}
