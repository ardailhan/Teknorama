using Microsoft.EntityFrameworkCore;
using TeknoramaBackOffice.Core.Domain;
using TeknoramaBackOffice.Persistance.Configurations.AppUserConfigurations;
using TeknoramaBackOffice.Persistance.Configurations.BasketConfigurations;
using TeknoramaBackOffice.Persistance.Configurations.EmployeeConfigurations;
using TeknoramaBackOffice.Persistance.Configurations.EmployeeTerritoryConfigurations;
using TeknoramaBackOffice.Persistance.Configurations.ExpenseConfigurations;
using TeknoramaBackOffice.Persistance.Configurations.MessageConfigurations;
using TeknoramaBackOffice.Persistance.Configurations.OrderConfigurations;
using TeknoramaBackOffice.Persistance.Configurations.ProductConfigurations;

namespace TeknoramaBackOffice.Persistance.Context
{
    public class TEKNORAMAContext : DbContext
    {
        public TEKNORAMAContext(DbContextOptions<TEKNORAMAContext> options): base(options) { }
        public DbSet<AppRole> AppRoles => Set<AppRole>();
        public DbSet<AppUser> AppUsers => Set<AppUser>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Issue> Issues => Set<Issue>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<EmployeeTerritory> EmployeeTerritories => Set<EmployeeTerritory>();
        public DbSet<Expense> Expenses => Set<Expense>();
        public DbSet<OrderDetail> OrderDetails => Set<OrderDetail>();
        public DbSet<Message> Messages => Set<Message>();
        public DbSet<Shipper> Shippers => Set<Shipper>();
        public DbSet<Supplier> Suppliers => Set<Supplier>();
        public DbSet<Territory> Territories => Set<Territory>();
        public DbSet<Basket> Baskets => Set<Basket>();
        public DbSet<BasketItem> BasketItems => Set<BasketItem>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeTerritoryConfiguration());
            modelBuilder.ApplyConfiguration(new ExpenseConfiguration());
            modelBuilder.ApplyConfiguration(new MessageConfiguration());
            modelBuilder.ApplyConfiguration(new BasketConfiguration());
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
