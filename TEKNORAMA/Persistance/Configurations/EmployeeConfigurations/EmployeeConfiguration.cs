using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeknoramaBackOffice.Core.Domain;

namespace TeknoramaBackOffice.Persistance.Configurations.EmployeeConfigurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasMany(x => x.EmployeeTerritories).WithOne(x => x.Employee).HasForeignKey(x => x.EmployeeId);
            builder.HasOne(x => x.AppRole).WithMany(x => x.Employees).HasForeignKey(x => x.AppRoleId);
        }
    }
}
