using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class UpdateInfoClasses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InfoClassEntity_ApprovalTableEntity_ApprovalTableEntityId",
                table: "InfoClassEntity");

            migrationBuilder.DropIndex(
                name: "IX_InfoClassEntity_ApprovalTableEntityId",
                table: "InfoClassEntity");

            migrationBuilder.DropColumn(
                name: "ApprovalTableEntityId",
                table: "InfoClassEntity");

            migrationBuilder.CreateTable(
                name: "ApprovalTableEntityInfoClassEntity",
                columns: table => new
                {
                    ApprovalTablesId = table.Column<int>(type: "int", nullable: false),
                    InfoClassesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApprovalTableEntityInfoClassEntity", x => new { x.ApprovalTablesId, x.InfoClassesId });
                    table.ForeignKey(
                        name: "FK_ApprovalTableEntityInfoClassEntity_ApprovalTableEntity_Appro~",
                        column: x => x.ApprovalTablesId,
                        principalTable: "ApprovalTableEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApprovalTableEntityInfoClassEntity_InfoClassEntity_InfoClass~",
                        column: x => x.InfoClassesId,
                        principalTable: "InfoClassEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalTableEntityInfoClassEntity_InfoClassesId",
                table: "ApprovalTableEntityInfoClassEntity",
                column: "InfoClassesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApprovalTableEntityInfoClassEntity");

            migrationBuilder.AddColumn<int>(
                name: "ApprovalTableEntityId",
                table: "InfoClassEntity",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InfoClassEntity_ApprovalTableEntityId",
                table: "InfoClassEntity",
                column: "ApprovalTableEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_InfoClassEntity_ApprovalTableEntity_ApprovalTableEntityId",
                table: "InfoClassEntity",
                column: "ApprovalTableEntityId",
                principalTable: "ApprovalTableEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
