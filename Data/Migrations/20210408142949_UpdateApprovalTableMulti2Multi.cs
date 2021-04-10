using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class UpdateApprovalTableMulti2Multi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApprovalTableEntityInfoClassEntity");

            migrationBuilder.DropTable(
                name: "ApprovalTableEntityOrganizeEntity");

            migrationBuilder.CreateTable(
                name: "ApprovalTableInfoClassEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ApprovalTableId = table.Column<int>(type: "int", nullable: false),
                    InfoClassId = table.Column<int>(type: "int", nullable: false),
                    CreatorUserId = table.Column<int>(type: "int", nullable: true),
                    CreatorTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeleteUserId = table.Column<int>(type: "int", nullable: true),
                    DeleteTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifyUserId = table.Column<int>(type: "int", nullable: true),
                    LastModifyTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApprovalTableInfoClassEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApprovalTableInfoClassEntity_ApprovalTableEntity_ApprovalTab~",
                        column: x => x.ApprovalTableId,
                        principalTable: "ApprovalTableEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApprovalTableInfoClassEntity_InfoClassEntity_InfoClassId",
                        column: x => x.InfoClassId,
                        principalTable: "InfoClassEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApprovalTableInfoClassEntity_UserEntity_CreatorUserId",
                        column: x => x.CreatorUserId,
                        principalTable: "UserEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApprovalTableInfoClassEntity_UserEntity_DeleteUserId",
                        column: x => x.DeleteUserId,
                        principalTable: "UserEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApprovalTableInfoClassEntity_UserEntity_LastModifyUserId",
                        column: x => x.LastModifyUserId,
                        principalTable: "UserEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ApprovalTableOrganizeEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ApprovalTableId = table.Column<int>(type: "int", nullable: false),
                    OrganizeId = table.Column<int>(type: "int", nullable: false),
                    CreatorUserId = table.Column<int>(type: "int", nullable: true),
                    CreatorTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeleteUserId = table.Column<int>(type: "int", nullable: true),
                    DeleteTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifyUserId = table.Column<int>(type: "int", nullable: true),
                    LastModifyTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApprovalTableOrganizeEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApprovalTableOrganizeEntity_ApprovalTableEntity_ApprovalTabl~",
                        column: x => x.ApprovalTableId,
                        principalTable: "ApprovalTableEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApprovalTableOrganizeEntity_OrganizeEntity_OrganizeId",
                        column: x => x.OrganizeId,
                        principalTable: "OrganizeEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApprovalTableOrganizeEntity_UserEntity_CreatorUserId",
                        column: x => x.CreatorUserId,
                        principalTable: "UserEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApprovalTableOrganizeEntity_UserEntity_DeleteUserId",
                        column: x => x.DeleteUserId,
                        principalTable: "UserEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApprovalTableOrganizeEntity_UserEntity_LastModifyUserId",
                        column: x => x.LastModifyUserId,
                        principalTable: "UserEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalTableInfoClassEntity_ApprovalTableId",
                table: "ApprovalTableInfoClassEntity",
                column: "ApprovalTableId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalTableInfoClassEntity_CreatorUserId",
                table: "ApprovalTableInfoClassEntity",
                column: "CreatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalTableInfoClassEntity_DeleteUserId",
                table: "ApprovalTableInfoClassEntity",
                column: "DeleteUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalTableInfoClassEntity_InfoClassId",
                table: "ApprovalTableInfoClassEntity",
                column: "InfoClassId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalTableInfoClassEntity_LastModifyUserId",
                table: "ApprovalTableInfoClassEntity",
                column: "LastModifyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalTableOrganizeEntity_ApprovalTableId",
                table: "ApprovalTableOrganizeEntity",
                column: "ApprovalTableId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalTableOrganizeEntity_CreatorUserId",
                table: "ApprovalTableOrganizeEntity",
                column: "CreatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalTableOrganizeEntity_DeleteUserId",
                table: "ApprovalTableOrganizeEntity",
                column: "DeleteUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalTableOrganizeEntity_LastModifyUserId",
                table: "ApprovalTableOrganizeEntity",
                column: "LastModifyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalTableOrganizeEntity_OrganizeId",
                table: "ApprovalTableOrganizeEntity",
                column: "OrganizeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApprovalTableInfoClassEntity");

            migrationBuilder.DropTable(
                name: "ApprovalTableOrganizeEntity");

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

            migrationBuilder.CreateTable(
                name: "ApprovalTableEntityOrganizeEntity",
                columns: table => new
                {
                    ApprovalTablesId = table.Column<int>(type: "int", nullable: false),
                    OwnerOrganizesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApprovalTableEntityOrganizeEntity", x => new { x.ApprovalTablesId, x.OwnerOrganizesId });
                    table.ForeignKey(
                        name: "FK_ApprovalTableEntityOrganizeEntity_ApprovalTableEntity_Approv~",
                        column: x => x.ApprovalTablesId,
                        principalTable: "ApprovalTableEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApprovalTableEntityOrganizeEntity_OrganizeEntity_OwnerOrgani~",
                        column: x => x.OwnerOrganizesId,
                        principalTable: "OrganizeEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalTableEntityInfoClassEntity_InfoClassesId",
                table: "ApprovalTableEntityInfoClassEntity",
                column: "InfoClassesId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalTableEntityOrganizeEntity_OwnerOrganizesId",
                table: "ApprovalTableEntityOrganizeEntity",
                column: "OwnerOrganizesId");
        }
    }
}
