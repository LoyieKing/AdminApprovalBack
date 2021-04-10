using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class UpdateApprovalTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApprovalTableEntity_OrganizeEntity_OwnerOrganizeId",
                table: "ApprovalTableEntity");

            migrationBuilder.DropTable(
                name: "InfoGroupItemEntity");

            migrationBuilder.DropTable(
                name: "InfoGroupEntity");

            migrationBuilder.DropIndex(
                name: "IX_ApprovalTableEntity_OwnerOrganizeId",
                table: "ApprovalTableEntity");

            migrationBuilder.DropColumn(
                name: "OwnerOrganizeId",
                table: "ApprovalTableEntity");

            migrationBuilder.AddColumn<int>(
                name: "ApprovalTableEntityId",
                table: "InfoClassEntity",
                type: "int",
                nullable: true);

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
                name: "IX_InfoClassEntity_ApprovalTableEntityId",
                table: "InfoClassEntity",
                column: "ApprovalTableEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalTableEntityOrganizeEntity_OwnerOrganizesId",
                table: "ApprovalTableEntityOrganizeEntity",
                column: "OwnerOrganizesId");

            migrationBuilder.AddForeignKey(
                name: "FK_InfoClassEntity_ApprovalTableEntity_ApprovalTableEntityId",
                table: "InfoClassEntity",
                column: "ApprovalTableEntityId",
                principalTable: "ApprovalTableEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InfoClassEntity_ApprovalTableEntity_ApprovalTableEntityId",
                table: "InfoClassEntity");

            migrationBuilder.DropTable(
                name: "ApprovalTableEntityOrganizeEntity");

            migrationBuilder.DropIndex(
                name: "IX_InfoClassEntity_ApprovalTableEntityId",
                table: "InfoClassEntity");

            migrationBuilder.DropColumn(
                name: "ApprovalTableEntityId",
                table: "InfoClassEntity");

            migrationBuilder.AddColumn<int>(
                name: "OwnerOrganizeId",
                table: "ApprovalTableEntity",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "InfoGroupEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ApprovalTableEntityId = table.Column<int>(type: "int", nullable: true),
                    CreatorTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreatorUserId = table.Column<int>(type: "int", nullable: true),
                    DeleteTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeleteUserId = table.Column<int>(type: "int", nullable: true),
                    LastModifyTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifyUserId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InfoGroupEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InfoGroupEntity_ApprovalTableEntity_ApprovalTableEntityId",
                        column: x => x.ApprovalTableEntityId,
                        principalTable: "ApprovalTableEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InfoGroupEntity_UserEntity_CreatorUserId",
                        column: x => x.CreatorUserId,
                        principalTable: "UserEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InfoGroupEntity_UserEntity_DeleteUserId",
                        column: x => x.DeleteUserId,
                        principalTable: "UserEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InfoGroupEntity_UserEntity_LastModifyUserId",
                        column: x => x.LastModifyUserId,
                        principalTable: "UserEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InfoGroupItemEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatorTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreatorUserId = table.Column<int>(type: "int", nullable: true),
                    DeleteTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeleteUserId = table.Column<int>(type: "int", nullable: true),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: true),
                    LastModifyTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifyUserId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InfoGroupItemEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InfoGroupItemEntity_InfoClassEntity_ItemId",
                        column: x => x.ItemId,
                        principalTable: "InfoClassEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InfoGroupItemEntity_InfoGroupEntity_GroupId",
                        column: x => x.GroupId,
                        principalTable: "InfoGroupEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InfoGroupItemEntity_UserEntity_CreatorUserId",
                        column: x => x.CreatorUserId,
                        principalTable: "UserEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InfoGroupItemEntity_UserEntity_DeleteUserId",
                        column: x => x.DeleteUserId,
                        principalTable: "UserEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InfoGroupItemEntity_UserEntity_LastModifyUserId",
                        column: x => x.LastModifyUserId,
                        principalTable: "UserEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalTableEntity_OwnerOrganizeId",
                table: "ApprovalTableEntity",
                column: "OwnerOrganizeId");

            migrationBuilder.CreateIndex(
                name: "IX_InfoGroupEntity_ApprovalTableEntityId",
                table: "InfoGroupEntity",
                column: "ApprovalTableEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_InfoGroupEntity_CreatorUserId",
                table: "InfoGroupEntity",
                column: "CreatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_InfoGroupEntity_DeleteUserId",
                table: "InfoGroupEntity",
                column: "DeleteUserId");

            migrationBuilder.CreateIndex(
                name: "IX_InfoGroupEntity_LastModifyUserId",
                table: "InfoGroupEntity",
                column: "LastModifyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_InfoGroupItemEntity_CreatorUserId",
                table: "InfoGroupItemEntity",
                column: "CreatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_InfoGroupItemEntity_DeleteUserId",
                table: "InfoGroupItemEntity",
                column: "DeleteUserId");

            migrationBuilder.CreateIndex(
                name: "IX_InfoGroupItemEntity_GroupId",
                table: "InfoGroupItemEntity",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_InfoGroupItemEntity_ItemId",
                table: "InfoGroupItemEntity",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_InfoGroupItemEntity_LastModifyUserId",
                table: "InfoGroupItemEntity",
                column: "LastModifyUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApprovalTableEntity_OrganizeEntity_OwnerOrganizeId",
                table: "ApprovalTableEntity",
                column: "OwnerOrganizeId",
                principalTable: "OrganizeEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
