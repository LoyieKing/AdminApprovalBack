using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class UpdateInfoClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ExpiredMinutes",
                table: "InfoClassEntity",
                newName: "ExpiredDays");

            migrationBuilder.AddColumn<string>(
                name: "InputType",
                table: "InfoClassEntity",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InputType",
                table: "InfoClassEntity");

            migrationBuilder.RenameColumn(
                name: "ExpiredDays",
                table: "InfoClassEntity",
                newName: "ExpiredMinutes");
        }
    }
}
