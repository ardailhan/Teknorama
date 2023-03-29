using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeknoramaBackOffice.Persistance.Migrations
{
    public partial class databazeUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "TCNO",
                table: "AppUsers");

            migrationBuilder.CreateTable(
                name: "UserProfiles",
                columns: table => new
                {
                    AppUserId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TCNO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<short>(type: "smallint", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.AppUserId);
                    table.ForeignKey(
                        name: "FK_UserProfiles_AppUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id");
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserProfiles");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AppUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "Age",
                table: "AppUsers",
                type: "smallint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AppUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "AppUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "AppUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AppUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TCNO",
                table: "AppUsers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
