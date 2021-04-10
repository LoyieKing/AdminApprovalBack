using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class InfoClassReusable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Reusable",
                table: "InfoClassEntity",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Reusable",
                table: "InfoClassEntity");
        }
    }
}
