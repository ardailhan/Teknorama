using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeknoramaBackOffice.Persistance.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Baskets",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Baskets",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "BasketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "BasketItems",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "BasketItems",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Baskets");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Baskets");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Baskets");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "BasketItems");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "BasketItems");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "BasketItems");
        }
    }
}
