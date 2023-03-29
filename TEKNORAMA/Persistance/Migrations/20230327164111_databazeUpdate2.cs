using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeknoramaBackOffice.Persistance.Migrations
{
    public partial class databazeUpdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserProfiles",
                table: "UserProfiles");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UserProfiles",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserProfiles",
                table: "UserProfiles",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_AppUserId",
                table: "UserProfiles",
                column: "AppUserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserProfiles",
                table: "UserProfiles");

            migrationBuilder.DropIndex(
                name: "IX_UserProfiles_AppUserId",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserProfiles");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserProfiles",
                table: "UserProfiles",
                column: "AppUserId");
        }
    }
}
