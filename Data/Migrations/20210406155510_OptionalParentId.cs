using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class OptionalParentId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrganizeEntity_OrganizeEntity_ParentId",
                table: "OrganizeEntity");

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizeEntity_OrganizeEntity_ParentId",
                table: "OrganizeEntity",
                column: "ParentId",
                principalTable: "OrganizeEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrganizeEntity_OrganizeEntity_ParentId",
                table: "OrganizeEntity");

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizeEntity_OrganizeEntity_ParentId",
                table: "OrganizeEntity",
                column: "ParentId",
                principalTable: "OrganizeEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
