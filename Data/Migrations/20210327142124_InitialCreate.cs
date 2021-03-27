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
                name: "OrganizeCategoryEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false),
                    CreatorUserId = table.Column<int>(type: "int", nullable: false),
                    CreatorTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeleteUserId = table.Column<int>(type: "int", nullable: false),
                    DeleteTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifyUserId = table.Column<int>(type: "int", nullable: false),
                    LastModifyTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizeCategoryEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sys_DbBackup",
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
                    CreatorUserId = table.Column<int>(type: "int", nullable: false),
                    CreatorTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeleteUserId = table.Column<int>(type: "int", nullable: false),
                    DeleteTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifyUserId = table.Column<int>(type: "int", nullable: false),
                    LastModifyTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys_DbBackup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sys_Log",
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
                    CreatorUserId = table.Column<int>(type: "int", nullable: false),
                    CreatorTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeleteUserId = table.Column<int>(type: "int", nullable: false),
                    DeleteTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifyUserId = table.Column<int>(type: "int", nullable: false),
                    LastModifyTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys_Log", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sys_User",
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
                    CreatorUserId = table.Column<int>(type: "int", nullable: false),
                    CreatorTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeleteUserId = table.Column<int>(type: "int", nullable: false),
                    DeleteTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifyUserId = table.Column<int>(type: "int", nullable: false),
                    LastModifyTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys_User", x => x.Id);
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
                    CreatorUserId = table.Column<int>(type: "int", nullable: false),
                    CreatorTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeleteUserId = table.Column<int>(type: "int", nullable: false),
                    DeleteTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifyUserId = table.Column<int>(type: "int", nullable: false),
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
                    CreatorUserId = table.Column<int>(type: "int", nullable: false),
                    CreatorTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeleteUserId = table.Column<int>(type: "int", nullable: false),
                    DeleteTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifyUserId = table.Column<int>(type: "int", nullable: false),
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
                        name: "FK_UserOrganizeEntity_Sys_User_UserId",
                        column: x => x.UserId,
                        principalTable: "Sys_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrganizeCategoryEntity_Id",
                table: "OrganizeCategoryEntity",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizeEntity_CategoryId",
                table: "OrganizeEntity",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizeEntity_Id",
                table: "OrganizeEntity",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizeEntity_ParentId",
                table: "OrganizeEntity",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Sys_DbBackup_Id",
                table: "Sys_DbBackup",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Sys_Log_Id",
                table: "Sys_Log",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Sys_User_Id",
                table: "Sys_User",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserOrganizeEntity_Id",
                table: "UserOrganizeEntity",
                column: "Id");

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
                name: "Sys_DbBackup");

            migrationBuilder.DropTable(
                name: "Sys_Log");

            migrationBuilder.DropTable(
                name: "UserOrganizeEntity");

            migrationBuilder.DropTable(
                name: "OrganizeEntity");

            migrationBuilder.DropTable(
                name: "Sys_User");

            migrationBuilder.DropTable(
                name: "OrganizeCategoryEntity");
        }
    }
}
