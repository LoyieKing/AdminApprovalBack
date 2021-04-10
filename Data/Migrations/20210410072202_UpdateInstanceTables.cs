using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class UpdateInstanceTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InfoInstanceEntity_ApprovalInstanceEntity_ApprovalInstanceEn~",
                table: "InfoInstanceEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_InfoInstanceEntity_InfoClassEntity_InfoClassId",
                table: "InfoInstanceEntity");

            migrationBuilder.DropIndex(
                name: "IX_InfoInstanceEntity_ApprovalInstanceEntityId",
                table: "InfoInstanceEntity");

            migrationBuilder.DropIndex(
                name: "IX_InfoInstanceEntity_InfoClassId",
                table: "InfoInstanceEntity");

            migrationBuilder.DropColumn(
                name: "ApprovalInstanceEntityId",
                table: "InfoInstanceEntity");

            migrationBuilder.DropColumn(
                name: "InfoClassId",
                table: "InfoInstanceEntity");

            migrationBuilder.AddColumn<int>(
                name: "PrototypeId",
                table: "InfoInstanceEntity",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "InfoInstances",
                table: "ApprovalInstanceEntity",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrototypeId",
                table: "InfoInstanceEntity");

            migrationBuilder.DropColumn(
                name: "InfoInstances",
                table: "ApprovalInstanceEntity");

            migrationBuilder.AddColumn<int>(
                name: "ApprovalInstanceEntityId",
                table: "InfoInstanceEntity",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InfoClassId",
                table: "InfoInstanceEntity",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InfoInstanceEntity_ApprovalInstanceEntityId",
                table: "InfoInstanceEntity",
                column: "ApprovalInstanceEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_InfoInstanceEntity_InfoClassId",
                table: "InfoInstanceEntity",
                column: "InfoClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_InfoInstanceEntity_ApprovalInstanceEntity_ApprovalInstanceEn~",
                table: "InfoInstanceEntity",
                column: "ApprovalInstanceEntityId",
                principalTable: "ApprovalInstanceEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InfoInstanceEntity_InfoClassEntity_InfoClassId",
                table: "InfoInstanceEntity",
                column: "InfoClassId",
                principalTable: "InfoClassEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
