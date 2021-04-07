using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class ModifyRoleMenuTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoleMenuEntity");

            migrationBuilder.DropTable(
                name: "MenuEntity");

            migrationBuilder.AddColumn<string>(
                name: "AvailableMenus",
                table: "RoleEntity",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvailableMenus",
                table: "RoleEntity");

            migrationBuilder.CreateTable(
                name: "MenuEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BasePath = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    CreatorTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreatorUserId = table.Column<int>(type: "int", nullable: true),
                    DeleteTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeleteUserId = table.Column<int>(type: "int", nullable: true),
                    Icon = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    LastModifyTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifyUserId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    Path = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    Target = table.Column<int>(type: "int", nullable: true),
                    Url = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuEntity_MenuEntity_ParentId",
                        column: x => x.ParentId,
                        principalTable: "MenuEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MenuEntity_UserEntity_CreatorUserId",
                        column: x => x.CreatorUserId,
                        principalTable: "UserEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MenuEntity_UserEntity_DeleteUserId",
                        column: x => x.DeleteUserId,
                        principalTable: "UserEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MenuEntity_UserEntity_LastModifyUserId",
                        column: x => x.LastModifyUserId,
                        principalTable: "UserEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoleMenuEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatorTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreatorUserId = table.Column<int>(type: "int", nullable: true),
                    DeleteTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeleteUserId = table.Column<int>(type: "int", nullable: true),
                    LastModifyTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifyUserId = table.Column<int>(type: "int", nullable: true),
                    MenuId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleMenuEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleMenuEntity_MenuEntity_MenuId",
                        column: x => x.MenuId,
                        principalTable: "MenuEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleMenuEntity_RoleEntity_RoleId",
                        column: x => x.RoleId,
                        principalTable: "RoleEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleMenuEntity_UserEntity_CreatorUserId",
                        column: x => x.CreatorUserId,
                        principalTable: "UserEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RoleMenuEntity_UserEntity_DeleteUserId",
                        column: x => x.DeleteUserId,
                        principalTable: "UserEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RoleMenuEntity_UserEntity_LastModifyUserId",
                        column: x => x.LastModifyUserId,
                        principalTable: "UserEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MenuEntity_CreatorUserId",
                table: "MenuEntity",
                column: "CreatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuEntity_DeleteUserId",
                table: "MenuEntity",
                column: "DeleteUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuEntity_LastModifyUserId",
                table: "MenuEntity",
                column: "LastModifyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuEntity_ParentId",
                table: "MenuEntity",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleMenuEntity_CreatorUserId",
                table: "RoleMenuEntity",
                column: "CreatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleMenuEntity_DeleteUserId",
                table: "RoleMenuEntity",
                column: "DeleteUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleMenuEntity_LastModifyUserId",
                table: "RoleMenuEntity",
                column: "LastModifyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleMenuEntity_MenuId",
                table: "RoleMenuEntity",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleMenuEntity_RoleId",
                table: "RoleMenuEntity",
                column: "RoleId");
        }
    }
}
