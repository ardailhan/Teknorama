﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TeknoramaBackOffice.Persistance.Context;

#nullable disable

namespace TeknoramaBackOffice.Persistance.Migrations
{
    [DbContext(typeof(TEKNORAMAContext))]
    partial class TEKNORAMAContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TeknoramaBackOffice.Core.Domain.AppRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Definition")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AppRoles");
                });

            modelBuilder.Entity("TeknoramaBackOffice.Core.Domain.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<int>("AppRoleId")
                        .HasColumnType("int");

                    b.Property<string>("ConfirmPassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AppRoleId");

                    b.ToTable("AppUsers");
                });

            modelBuilder.Entity("TeknoramaBackOffice.Core.Domain.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("TeknoramaBackOffice.Core.Domain.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AppRoleId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("MonthlySales")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("PhoneNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("TCNO")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AppRoleId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("TeknoramaBackOffice.Core.Domain.EmployeeTerritory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("TerritoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("TerritoryId");

                    b.ToTable("EmployeeTerritories");
                });

            modelBuilder.Entity("TeknoramaBackOffice.Core.Domain.Expense", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("ExpenseType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Expenses");
                });

            modelBuilder.Entity("TeknoramaBackOffice.Core.Domain.Issue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Answer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("AppUserId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IssueStatus")
                        .HasColumnType("int");

                    b.Property<DateTime>("OpenDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Subject")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.ToTable("Issues");
                });

            modelBuilder.Entity("TeknoramaBackOffice.Core.Domain.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("MessageDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("MessageType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subject")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("TeknoramaBackOffice.Core.Domain.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AppUserId")
                        .HasColumnType("int");

                    b.Property<float?>("Discount")
                        .HasColumnType("real");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrderStatus")
                        .HasColumnType("int");

                    b.Property<string>("ShipAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShipCity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShipCountry")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ShipperId")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("ShipperId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("TeknoramaBackOffice.Core.Domain.OrderDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("TeknoramaBackOffice.Core.Domain.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("SupplierId")
                        .HasColumnType("int");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("UnitsInStock")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("SupplierId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("TeknoramaBackOffice.Core.Domain.Shipper", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Shippers");
                });

            modelBuilder.Entity("TeknoramaBackOffice.Core.Domain.Supplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("TeknoramaBackOffice.Core.Domain.Territory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("TerritoryDescription")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Territories");
                });

            modelBuilder.Entity("TeknoramaBackOffice.Core.Domain.UserProfile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<short?>("Age")
                        .HasColumnType("smallint");

                    b.Property<int>("AppUserId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TCNO")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId")
                        .IsUnique();

                    b.ToTable("UserProfiles");
                });

            modelBuilder.Entity("TeknoramaBackOffice.Core.Domain.AppUser", b =>
                {
                    b.HasOne("TeknoramaBackOffice.Core.Domain.AppRole", "AppRole")
                        .WithMany("AppUsers")
                        .HasForeignKey("AppRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppRole");
                });

            modelBuilder.Entity("TeknoramaBackOffice.Core.Domain.Employee", b =>
                {
                    b.HasOne("TeknoramaBackOffice.Core.Domain.AppRole", "AppRole")
                        .WithMany("Employees")
                        .HasForeignKey("AppRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppRole");
                });

            modelBuilder.Entity("TeknoramaBackOffice.Core.Domain.EmployeeTerritory", b =>
                {
                    b.HasOne("TeknoramaBackOffice.Core.Domain.Employee", "Employee")
                        .WithMany("EmployeeTerritories")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TeknoramaBackOffice.Core.Domain.Territory", "Territory")
                        .WithMany("EmployeeTerritories")
                        .HasForeignKey("TerritoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Territory");
                });

            modelBuilder.Entity("TeknoramaBackOffice.Core.Domain.Issue", b =>
                {
                    b.HasOne("TeknoramaBackOffice.Core.Domain.AppUser", "AppUser")
                        .WithMany("Issues")
                        .HasForeignKey("AppUserId");

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("TeknoramaBackOffice.Core.Domain.Order", b =>
                {
                    b.HasOne("TeknoramaBackOffice.Core.Domain.AppUser", "AppUser")
                        .WithMany("Orders")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TeknoramaBackOffice.Core.Domain.Employee", "Employee")
                        .WithMany("Orders")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TeknoramaBackOffice.Core.Domain.Shipper", "Shipper")
                        .WithMany("Orders")
                        .HasForeignKey("ShipperId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");

                    b.Navigation("Employee");

                    b.Navigation("Shipper");
                });

            modelBuilder.Entity("TeknoramaBackOffice.Core.Domain.OrderDetail", b =>
                {
                    b.HasOne("TeknoramaBackOffice.Core.Domain.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TeknoramaBackOffice.Core.Domain.Product", "Product")
                        .WithMany("OrderDetails")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("TeknoramaBackOffice.Core.Domain.Product", b =>
                {
                    b.HasOne("TeknoramaBackOffice.Core.Domain.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TeknoramaBackOffice.Core.Domain.Supplier", "Supplier")
                        .WithMany("Products")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("TeknoramaBackOffice.Core.Domain.UserProfile", b =>
                {
                    b.HasOne("TeknoramaBackOffice.Core.Domain.AppUser", "AppUser")
                        .WithOne("Profile")
                        .HasForeignKey("TeknoramaBackOffice.Core.Domain.UserProfile", "AppUserId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("TeknoramaBackOffice.Core.Domain.AppRole", b =>
                {
                    b.Navigation("AppUsers");

                    b.Navigation("Employees");
                });

            modelBuilder.Entity("TeknoramaBackOffice.Core.Domain.AppUser", b =>
                {
                    b.Navigation("Issues");

                    b.Navigation("Orders");

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("TeknoramaBackOffice.Core.Domain.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("TeknoramaBackOffice.Core.Domain.Employee", b =>
                {
                    b.Navigation("EmployeeTerritories");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("TeknoramaBackOffice.Core.Domain.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("TeknoramaBackOffice.Core.Domain.Product", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("TeknoramaBackOffice.Core.Domain.Shipper", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("TeknoramaBackOffice.Core.Domain.Supplier", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("TeknoramaBackOffice.Core.Domain.Territory", b =>
                {
                    b.Navigation("EmployeeTerritories");
                });
#pragma warning restore 612, 618
        }
    }
}
