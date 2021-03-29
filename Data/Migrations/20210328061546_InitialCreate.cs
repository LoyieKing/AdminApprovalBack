using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UsernName = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    RealName = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    Avatar = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    Gender = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    Birthday = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Contract = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    IsAdministrator = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    EnabledMark = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    Password = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    CreatorUserId = table.Column<int>(type: "int", nullable: true),
                    CreatorTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeleteUserId = table.Column<int>(type: "int", nullable: true),
                    DeleteTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifyUserId = table.Column<int>(type: "int", nullable: true),
                    LastModifyTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserEntity_UserEntity_CreatorUserId",
                        column: x => x.CreatorUserId,
                        principalTable: "UserEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserEntity_UserEntity_DeleteUserId",
                        column: x => x.DeleteUserId,
                        principalTable: "UserEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserEntity_UserEntity_LastModifyUserId",
                        column: x => x.LastModifyUserId,
                        principalTable: "UserEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DbBackupEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BackupType = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    DbName = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    FileName = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    FileSize = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    FilePath = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    BackupTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Description = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    CreatorUserId = table.Column<int>(type: "int", nullable: true),
                    CreatorTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeleteUserId = table.Column<int>(type: "int", nullable: true),
                    DeleteTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifyUserId = table.Column<int>(type: "int", nullable: true),
                    LastModifyTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbBackupEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbBackupEntity_UserEntity_CreatorUserId",
                        column: x => x.CreatorUserId,
                        principalTable: "UserEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DbBackupEntity_UserEntity_DeleteUserId",
                        column: x => x.DeleteUserId,
                        principalTable: "UserEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DbBackupEntity_UserEntity_LastModifyUserId",
                        column: x => x.LastModifyUserId,
                        principalTable: "UserEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LogEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UserName = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    Type = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    IPAddress = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    Result = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    Description = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    CreatorUserId = table.Column<int>(type: "int", nullable: true),
                    CreatorTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeleteUserId = table.Column<int>(type: "int", nullable: true),
                    DeleteTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifyUserId = table.Column<int>(type: "int", nullable: true),
                    LastModifyTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LogEntity_UserEntity_CreatorUserId",
                        column: x => x.CreatorUserId,
                        principalTable: "UserEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LogEntity_UserEntity_DeleteUserId",
                        column: x => x.DeleteUserId,
                        principalTable: "UserEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LogEntity_UserEntity_LastModifyUserId",
                        column: x => x.LastModifyUserId,
                        principalTable: "UserEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MenuEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    Icon = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    BasePath = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Path = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Url = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Target = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    CreatorUserId = table.Column<int>(type: "int", nullable: true),
                    CreatorTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeleteUserId = table.Column<int>(type: "int", nullable: true),
                    DeleteTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifyUserId = table.Column<int>(type: "int", nullable: true),
                    LastModifyTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
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
                name: "OrganizeCategoryEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false),
                    CreatorUserId = table.Column<int>(type: "int", nullable: true),
                    CreatorTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeleteUserId = table.Column<int>(type: "int", nullable: true),
                    DeleteTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifyUserId = table.Column<int>(type: "int", nullable: true),
                    LastModifyTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizeCategoryEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganizeCategoryEntity_UserEntity_CreatorUserId",
                        column: x => x.CreatorUserId,
                        principalTable: "UserEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrganizeCategoryEntity_UserEntity_DeleteUserId",
                        column: x => x.DeleteUserId,
                        principalTable: "UserEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrganizeCategoryEntity_UserEntity_LastModifyUserId",
                        column: x => x.LastModifyUserId,
                        principalTable: "UserEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrganizeEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatorUserId = table.Column<int>(type: "int", nullable: true),
                    CreatorTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeleteUserId = table.Column<int>(type: "int", nullable: true),
                    DeleteTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifyUserId = table.Column<int>(type: "int", nullable: true),
                    LastModifyTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizeEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganizeEntity_OrganizeCategoryEntity_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "OrganizeCategoryEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrganizeEntity_OrganizeEntity_ParentId",
                        column: x => x.ParentId,
                        principalTable: "OrganizeEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrganizeEntity_UserEntity_CreatorUserId",
                        column: x => x.CreatorUserId,
                        principalTable: "UserEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrganizeEntity_UserEntity_DeleteUserId",
                        column: x => x.DeleteUserId,
                        principalTable: "UserEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrganizeEntity_UserEntity_LastModifyUserId",
                        column: x => x.LastModifyUserId,
                        principalTable: "UserEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoleEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    OrganizeCategoryId = table.Column<int>(type: "int", nullable: false),
                    OrganizeDutyLevel = table.Column<int>(type: "int", nullable: false),
                    CreatorUserId = table.Column<int>(type: "int", nullable: true),
                    CreatorTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeleteUserId = table.Column<int>(type: "int", nullable: true),
                    DeleteTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifyUserId = table.Column<int>(type: "int", nullable: true),
                    LastModifyTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleEntity_OrganizeCategoryEntity_OrganizeCategoryId",
                        column: x => x.OrganizeCategoryId,
                        principalTable: "OrganizeCategoryEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleEntity_UserEntity_CreatorUserId",
                        column: x => x.CreatorUserId,
                        principalTable: "UserEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RoleEntity_UserEntity_DeleteUserId",
                        column: x => x.DeleteUserId,
                        principalTable: "UserEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RoleEntity_UserEntity_LastModifyUserId",
                        column: x => x.LastModifyUserId,
                        principalTable: "UserEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserOrganizeEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    OrganizeId = table.Column<int>(type: "int", nullable: false),
                    DutyLevel = table.Column<int>(type: "int", nullable: false),
                    CreatorUserId = table.Column<int>(type: "int", nullable: true),
                    CreatorTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeleteUserId = table.Column<int>(type: "int", nullable: true),
                    DeleteTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifyUserId = table.Column<int>(type: "int", nullable: true),
                    LastModifyTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOrganizeEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserOrganizeEntity_OrganizeEntity_OrganizeId",
                        column: x => x.OrganizeId,
                        principalTable: "OrganizeEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserOrganizeEntity_UserEntity_CreatorUserId",
                        column: x => x.CreatorUserId,
                        principalTable: "UserEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserOrganizeEntity_UserEntity_DeleteUserId",
                        column: x => x.DeleteUserId,
                        principalTable: "UserEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserOrganizeEntity_UserEntity_LastModifyUserId",
                        column: x => x.LastModifyUserId,
                        principalTable: "UserEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserOrganizeEntity_UserEntity_UserId",
                        column: x => x.UserId,
                        principalTable: "UserEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleMenuEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    MenuId = table.Column<int>(type: "int", nullable: false),
                    CreatorUserId = table.Column<int>(type: "int", nullable: true),
                    CreatorTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeleteUserId = table.Column<int>(type: "int", nullable: true),
                    DeleteTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifyUserId = table.Column<int>(type: "int", nullable: true),
                    LastModifyTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
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
                name: "IX_DbBackupEntity_CreatorUserId",
                table: "DbBackupEntity",
                column: "CreatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DbBackupEntity_DeleteUserId",
                table: "DbBackupEntity",
                column: "DeleteUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DbBackupEntity_LastModifyUserId",
                table: "DbBackupEntity",
                column: "LastModifyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_LogEntity_CreatorUserId",
                table: "LogEntity",
                column: "CreatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_LogEntity_DeleteUserId",
                table: "LogEntity",
                column: "DeleteUserId");

            migrationBuilder.CreateIndex(
                name: "IX_LogEntity_LastModifyUserId",
                table: "LogEntity",
                column: "LastModifyUserId");

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
                name: "IX_OrganizeCategoryEntity_CreatorUserId",
                table: "OrganizeCategoryEntity",
                column: "CreatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizeCategoryEntity_DeleteUserId",
                table: "OrganizeCategoryEntity",
                column: "DeleteUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizeCategoryEntity_LastModifyUserId",
                table: "OrganizeCategoryEntity",
                column: "LastModifyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizeEntity_CategoryId",
                table: "OrganizeEntity",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizeEntity_CreatorUserId",
                table: "OrganizeEntity",
                column: "CreatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizeEntity_DeleteUserId",
                table: "OrganizeEntity",
                column: "DeleteUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizeEntity_LastModifyUserId",
                table: "OrganizeEntity",
                column: "LastModifyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizeEntity_ParentId",
                table: "OrganizeEntity",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleEntity_CreatorUserId",
                table: "RoleEntity",
                column: "CreatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleEntity_DeleteUserId",
                table: "RoleEntity",
                column: "DeleteUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleEntity_LastModifyUserId",
                table: "RoleEntity",
                column: "LastModifyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleEntity_OrganizeCategoryId",
                table: "RoleEntity",
                column: "OrganizeCategoryId");

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

            migrationBuilder.CreateIndex(
                name: "IX_UserEntity_CreatorUserId",
                table: "UserEntity",
                column: "CreatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserEntity_DeleteUserId",
                table: "UserEntity",
                column: "DeleteUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserEntity_LastModifyUserId",
                table: "UserEntity",
                column: "LastModifyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOrganizeEntity_CreatorUserId",
                table: "UserOrganizeEntity",
                column: "CreatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOrganizeEntity_DeleteUserId",
                table: "UserOrganizeEntity",
                column: "DeleteUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOrganizeEntity_LastModifyUserId",
                table: "UserOrganizeEntity",
                column: "LastModifyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOrganizeEntity_OrganizeId",
                table: "UserOrganizeEntity",
                column: "OrganizeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOrganizeEntity_UserId",
                table: "UserOrganizeEntity",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DbBackupEntity");

            migrationBuilder.DropTable(
                name: "LogEntity");

            migrationBuilder.DropTable(
                name: "RoleMenuEntity");

            migrationBuilder.DropTable(
                name: "UserOrganizeEntity");

            migrationBuilder.DropTable(
                name: "MenuEntity");

            migrationBuilder.DropTable(
                name: "RoleEntity");

            migrationBuilder.DropTable(
                name: "OrganizeEntity");

            migrationBuilder.DropTable(
                name: "OrganizeCategoryEntity");

            migrationBuilder.DropTable(
                name: "UserEntity");
        }
    }
}
