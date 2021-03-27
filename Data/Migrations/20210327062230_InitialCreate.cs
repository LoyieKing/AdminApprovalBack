using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sys_Area",
                columns: table => new
                {
                    F_Id = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: false),
                    F_ParentId = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_Layers = table.Column<int>(type: "int", nullable: true),
                    F_EnCode = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_FullName = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_SimpleSpelling = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_SortCode = table.Column<int>(type: "int", nullable: true),
                    F_EnabledMark = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    F_Description = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_CreatorUserId = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_CreatorTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    F_DeleteMark = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    F_DeleteUserId = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_DeleteTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    F_LastModifyUserId = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_LastModifyTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys_Area", x => x.F_Id);
                });

            migrationBuilder.CreateTable(
                name: "Sys_DbBackup",
                columns: table => new
                {
                    F_Id = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: false),
                    F_BackupType = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_DbName = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_FileName = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_FileSize = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_FilePath = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_BackupTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    F_SortCode = table.Column<int>(type: "int", nullable: true),
                    F_EnabledMark = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    F_Description = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_CreatorUserId = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_CreatorTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    F_DeleteMark = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    F_DeleteUserId = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_DeleteTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    F_LastModifyUserId = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_LastModifyTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys_DbBackup", x => x.F_Id);
                });

            migrationBuilder.CreateTable(
                name: "Sys_FilterIP",
                columns: table => new
                {
                    F_Id = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: false),
                    F_Type = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    F_StartIP = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_EndIP = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_SortCode = table.Column<int>(type: "int", nullable: true),
                    F_EnabledMark = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    F_Description = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_CreatorUserId = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_CreatorTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    F_DeleteMark = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    F_DeleteUserId = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_DeleteTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    F_LastModifyUserId = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_LastModifyTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys_FilterIP", x => x.F_Id);
                });

            migrationBuilder.CreateTable(
                name: "Sys_Items",
                columns: table => new
                {
                    F_Id = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: false),
                    F_ParentId = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_EnCode = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_FullName = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_IsTree = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    F_Layers = table.Column<int>(type: "int", nullable: true),
                    F_SortCode = table.Column<int>(type: "int", nullable: true),
                    F_EnabledMark = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    F_Description = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_CreatorUserId = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_CreatorTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    F_DeleteMark = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    F_DeleteUserId = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_DeleteTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    F_LastModifyUserId = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_LastModifyTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys_Items", x => x.F_Id);
                });

            migrationBuilder.CreateTable(
                name: "Sys_Log",
                columns: table => new
                {
                    F_Id = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: false),
                    F_Date = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    F_Account = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_NickName = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_Type = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_IPAddress = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_ModuleId = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_ModuleName = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_Result = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    F_Description = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_CreatorUserId = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_CreatorTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    F_DeleteMark = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    F_DeleteUserId = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_DeleteTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    F_LastModifyUserId = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_LastModifyTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys_Log", x => x.F_Id);
                });

            migrationBuilder.CreateTable(
                name: "Sys_Module",
                columns: table => new
                {
                    F_Id = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: false),
                    F_ParentId = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_Layers = table.Column<int>(type: "int", nullable: true),
                    F_EnCode = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_FullName = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_Icon = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_UrlAddress = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_Target = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_IsMenu = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    F_IsExpand = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    F_IsPublic = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    F_AllowEdit = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    F_AllowDelete = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    F_SortCode = table.Column<int>(type: "int", nullable: true),
                    F_EnabledMark = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    F_Description = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_CreatorUserId = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_CreatorTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    F_DeleteMark = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    F_DeleteUserId = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_DeleteTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    F_LastModifyUserId = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_LastModifyTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys_Module", x => x.F_Id);
                });

            migrationBuilder.CreateTable(
                name: "Sys_ModuleButton",
                columns: table => new
                {
                    F_Id = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: false),
                    F_ModuleId = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_ParentId = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_Layers = table.Column<int>(type: "int", nullable: true),
                    F_EnCode = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_FullName = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_Icon = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_Location = table.Column<int>(type: "int", nullable: true),
                    F_JsEvent = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_UrlAddress = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_Split = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    F_IsPublic = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    F_AllowEdit = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    F_AllowDelete = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    F_SortCode = table.Column<int>(type: "int", nullable: true),
                    F_EnabledMark = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    F_Description = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_CreatorUserId = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_CreatorTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    F_DeleteMark = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    F_DeleteUserId = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_DeleteTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    F_LastModifyUserId = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_LastModifyTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys_ModuleButton", x => x.F_Id);
                });

            migrationBuilder.CreateTable(
                name: "Sys_Organize",
                columns: table => new
                {
                    F_Id = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: false),
                    F_ParentId = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_Layers = table.Column<int>(type: "int", nullable: true),
                    F_EnCode = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_FullName = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_ShortName = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_CategoryId = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_ManagerId = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_TelePhone = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_MobilePhone = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_WeChat = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_Fax = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_Email = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_AreaId = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_Address = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_AllowEdit = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    F_AllowDelete = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    F_SortCode = table.Column<int>(type: "int", nullable: true),
                    F_EnabledMark = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    F_Description = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_CreatorUserId = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_CreatorTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    F_DeleteMark = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    F_DeleteUserId = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_DeleteTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    F_LastModifyUserId = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_LastModifyTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys_Organize", x => x.F_Id);
                });

            migrationBuilder.CreateTable(
                name: "Sys_Role",
                columns: table => new
                {
                    F_Id = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: false),
                    F_OrganizeId = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_Category = table.Column<int>(type: "int", nullable: true),
                    F_EnCode = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_FullName = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_Type = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_AllowEdit = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    F_AllowDelete = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    F_SortCode = table.Column<int>(type: "int", nullable: true),
                    F_EnabledMark = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    F_Description = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_CreatorUserId = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_CreatorTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    F_DeleteMark = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    F_DeleteUserId = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_DeleteTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    F_LastModifyUserId = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_LastModifyTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys_Role", x => x.F_Id);
                });

            migrationBuilder.CreateTable(
                name: "Sys_RoleAuthorize",
                columns: table => new
                {
                    F_Id = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: false),
                    F_ItemType = table.Column<int>(type: "int", nullable: true),
                    F_ItemId = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_ObjectType = table.Column<int>(type: "int", nullable: true),
                    F_ObjectId = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_SortCode = table.Column<int>(type: "int", nullable: true),
                    F_CreatorUserId = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_CreatorTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    F_DeleteMark = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    F_DeleteUserId = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_DeleteTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    F_LastModifyUserId = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_LastModifyTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys_RoleAuthorize", x => x.F_Id);
                });

            migrationBuilder.CreateTable(
                name: "Sys_User",
                columns: table => new
                {
                    F_Id = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: false),
                    F_Account = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_RealName = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_NickName = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_HeadIcon = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_Gender = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    F_Birthday = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    F_MobilePhone = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_Email = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_WeChat = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_ManagerId = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_SecurityLevel = table.Column<int>(type: "int", nullable: true),
                    F_Signature = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_OrganizeId = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_DepartmentId = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_RoleId = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_DutyId = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_IsAdministrator = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    F_SortCode = table.Column<int>(type: "int", nullable: true),
                    F_EnabledMark = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    F_Description = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_CreatorUserId = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_CreatorTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    F_DeleteMark = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    F_DeleteUserId = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_DeleteTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    F_LastModifyUserId = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_LastModifyTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys_User", x => x.F_Id);
                });

            migrationBuilder.CreateTable(
                name: "Sys_UserLogOn",
                columns: table => new
                {
                    F_Id = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: false),
                    F_UserId = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_UserPassword = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_UserSecretkey = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_AllowStartTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    F_AllowEndTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    F_LockStartDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    F_LockEndDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    F_FirstVisitTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    F_PreviousVisitTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    F_LastVisitTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    F_ChangePasswordDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    F_MultiUserLogin = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    F_UserOnLine = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    F_Question = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_AnswerQuestion = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_CheckIPAddress = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    F_Language = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_Theme = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_CreatorUserId = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_CreatorTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    F_DeleteMark = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    F_DeleteUserId = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_DeleteTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    F_LastModifyUserId = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_LastModifyTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys_UserLogOn", x => x.F_Id);
                });

            migrationBuilder.CreateTable(
                name: "Sys_ItemsDetail",
                columns: table => new
                {
                    F_Id = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: false),
                    F_ItemId = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: false),
                    F_ParentId = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_ItemCode = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_ItemName = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_SimpleSpelling = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_IsDefault = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    F_Layers = table.Column<int>(type: "int", nullable: true),
                    F_SortCode = table.Column<int>(type: "int", nullable: true),
                    F_EnabledMark = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    F_Description = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_CreatorUserId = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_CreatorTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    F_DeleteMark = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    F_DeleteUserId = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_DeleteTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    F_LastModifyUserId = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    F_LastModifyTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys_ItemsDetail", x => x.F_Id);
                    table.ForeignKey(
                        name: "FK_Sys_ItemsDetail_Sys_Items_F_ItemId",
                        column: x => x.F_ItemId,
                        principalTable: "Sys_Items",
                        principalColumn: "F_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sys_ItemsDetail_F_ItemId",
                table: "Sys_ItemsDetail",
                column: "F_ItemId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sys_Area");

            migrationBuilder.DropTable(
                name: "Sys_DbBackup");

            migrationBuilder.DropTable(
                name: "Sys_FilterIP");

            migrationBuilder.DropTable(
                name: "Sys_ItemsDetail");

            migrationBuilder.DropTable(
                name: "Sys_Log");

            migrationBuilder.DropTable(
                name: "Sys_Module");

            migrationBuilder.DropTable(
                name: "Sys_ModuleButton");

            migrationBuilder.DropTable(
                name: "Sys_Organize");

            migrationBuilder.DropTable(
                name: "Sys_Role");

            migrationBuilder.DropTable(
                name: "Sys_RoleAuthorize");

            migrationBuilder.DropTable(
                name: "Sys_User");

            migrationBuilder.DropTable(
                name: "Sys_UserLogOn");

            migrationBuilder.DropTable(
                name: "Sys_Items");
        }
    }
}
