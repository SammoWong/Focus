﻿using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Focus.Repository.Migrations
{
    public partial class InitFocusDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 36, nullable: false),
                    Address = table.Column<string>(maxLength: 128, nullable: true),
                    Contact = table.Column<string>(maxLength: 50, nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 36, nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    Creator = table.Column<string>(maxLength: 50, nullable: true),
                    DeletedBy = table.Column<string>(maxLength: 36, nullable: true),
                    DeletedTime = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    Description = table.Column<string>(maxLength: 512, nullable: true),
                    Email = table.Column<string>(maxLength: 50, nullable: true),
                    Enabled = table.Column<bool>(nullable: false),
                    FullName = table.Column<string>(maxLength: 50, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Mobile = table.Column<string>(maxLength: 11, nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 36, nullable: true),
                    ModifiedTime = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    Nature = table.Column<string>(maxLength: 50, nullable: true),
                    Phone = table.Column<string>(maxLength: 20, nullable: true),
                    ShortName = table.Column<string>(maxLength: 50, nullable: true),
                    Website = table.Column<string>(maxLength: 1024, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permission",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 36, nullable: false),
                    AccessId = table.Column<string>(maxLength: 36, nullable: true),
                    AccessType = table.Column<short>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 36, nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    DeletedBy = table.Column<string>(maxLength: 36, nullable: true),
                    DeletedTime = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    Enabled = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    MasterId = table.Column<string>(maxLength: 36, nullable: true),
                    MasterType = table.Column<short>(nullable: false),
                    ModifiedBy = table.Column<string>(maxLength: 36, nullable: true),
                    ModifiedTime = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    SortNumber = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DictionaryType",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 36, nullable: false),
                    CompanyId = table.Column<string>(maxLength: 36, nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 36, nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    DeletedBy = table.Column<string>(maxLength: 36, nullable: true),
                    DeletedTime = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    Enabled = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ModifiedBy = table.Column<string>(maxLength: 36, nullable: true),
                    ModifiedTime = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    ParentId = table.Column<string>(maxLength: 36, nullable: true),
                    Remark = table.Column<string>(maxLength: 512, nullable: true),
                    SortNumber = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DictionaryType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DictionaryType_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Module",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 36, nullable: false),
                    Category = table.Column<byte>(nullable: false),
                    Code = table.Column<string>(maxLength: 50, nullable: true),
                    CompanyId = table.Column<string>(maxLength: 36, nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 36, nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    DeletedBy = table.Column<string>(maxLength: 36, nullable: true),
                    DeletedTime = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    Enabled = table.Column<bool>(nullable: false),
                    Icon = table.Column<string>(maxLength: 50, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsExpanded = table.Column<bool>(nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 36, nullable: true),
                    ModifiedTime = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    ParentId = table.Column<string>(maxLength: 36, nullable: true),
                    Rank = table.Column<short>(nullable: false),
                    Remark = table.Column<string>(maxLength: 512, nullable: true),
                    SortNumber = table.Column<int>(nullable: true),
                    Url = table.Column<string>(maxLength: 1024, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Module", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Module_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Organization",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 36, nullable: false),
                    Category = table.Column<byte>(nullable: false),
                    Code = table.Column<string>(maxLength: 50, nullable: true),
                    CompanyId = table.Column<string>(maxLength: 36, nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 36, nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    DeletedBy = table.Column<string>(maxLength: 36, nullable: true),
                    DeletedTime = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    Enabled = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ModifiedBy = table.Column<string>(maxLength: 36, nullable: true),
                    ModifiedTime = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    ParentId = table.Column<string>(maxLength: 36, nullable: true),
                    SortNumber = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organization", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Organization_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 36, nullable: false),
                    Code = table.Column<string>(maxLength: 36, nullable: true),
                    CompanyId = table.Column<string>(maxLength: 36, nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 36, nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    DeletedBy = table.Column<string>(maxLength: 36, nullable: true),
                    DeletedTime = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    Description = table.Column<string>(maxLength: 512, nullable: true),
                    Enabled = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ModifiedBy = table.Column<string>(maxLength: 36, nullable: true),
                    ModifiedTime = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Role_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DictionaryDetail",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 36, nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 36, nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    DeletedBy = table.Column<string>(maxLength: 36, nullable: true),
                    DeletedTime = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    Enabled = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ModifiedBy = table.Column<string>(maxLength: 36, nullable: true),
                    ModifiedTime = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Remark = table.Column<string>(maxLength: 512, nullable: true),
                    SortNumber = table.Column<int>(nullable: true),
                    TypeId = table.Column<string>(maxLength: 36, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DictionaryDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DictionaryDetail_DictionaryType_TypeId",
                        column: x => x.TypeId,
                        principalTable: "DictionaryType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Button",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 36, nullable: false),
                    Code = table.Column<string>(maxLength: 50, nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 36, nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    DeletedBy = table.Column<string>(maxLength: 36, nullable: true),
                    DeletedTime = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    Enabled = table.Column<bool>(nullable: false),
                    Icon = table.Column<string>(maxLength: 50, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    JsEvent = table.Column<string>(maxLength: 50, nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 36, nullable: true),
                    ModifiedTime = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    ModuleId = table.Column<string>(maxLength: 36, nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Remark = table.Column<string>(maxLength: 512, nullable: true),
                    SortNumber = table.Column<int>(nullable: false),
                    Url = table.Column<string>(maxLength: 1024, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Button", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Button_Module_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Module",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Position",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 36, nullable: false),
                    CompanyId = table.Column<string>(maxLength: 36, nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 36, nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    DeletedBy = table.Column<string>(maxLength: 36, nullable: true),
                    DeletedTime = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    DepartmentId = table.Column<string>(maxLength: 36, nullable: true),
                    Enabled = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ModifiedBy = table.Column<string>(maxLength: 36, nullable: true),
                    ModifiedTime = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Remark = table.Column<string>(maxLength: 512, nullable: true),
                    SortNumber = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Position", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Position_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Position_Organization_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Organization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 36, nullable: false),
                    Account = table.Column<string>(maxLength: 50, nullable: true),
                    Avatar = table.Column<string>(maxLength: 512, nullable: true),
                    Birthday = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    CompanyId = table.Column<string>(maxLength: 36, nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 36, nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    DeletedBy = table.Column<string>(maxLength: 36, nullable: true),
                    DeletedTime = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    DepartmentId = table.Column<string>(maxLength: 36, nullable: true),
                    Email = table.Column<string>(maxLength: 50, nullable: true),
                    Enabled = table.Column<bool>(nullable: false),
                    Gender = table.Column<byte>(nullable: true),
                    IdCard = table.Column<string>(maxLength: 20, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Mobile = table.Column<string>(maxLength: 11, nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 36, nullable: true),
                    ModifiedTime = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    Password = table.Column<string>(maxLength: 64, nullable: true),
                    PositionId = table.Column<string>(maxLength: 36, nullable: true),
                    RealName = table.Column<string>(maxLength: 50, nullable: true),
                    RoleId = table.Column<string>(maxLength: 36, nullable: true),
                    Salt = table.Column<string>(maxLength: 64, nullable: true),
                    WorkgroupId = table.Column<string>(maxLength: 36, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_Position_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Position",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_Organization_WorkgroupId",
                        column: x => x.WorkgroupId,
                        principalTable: "Organization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Button_ModuleId",
                table: "Button",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_DictionaryDetail_TypeId",
                table: "DictionaryDetail",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DictionaryType_CompanyId",
                table: "DictionaryType",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Module_CompanyId",
                table: "Module",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Organization_CompanyId",
                table: "Organization",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Position_CompanyId",
                table: "Position",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Position_DepartmentId",
                table: "Position",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Role_CompanyId",
                table: "Role",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_User_CompanyId",
                table: "User",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_User_PositionId",
                table: "User",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_User_RoleId",
                table: "User",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_User_WorkgroupId",
                table: "User",
                column: "WorkgroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Button");

            migrationBuilder.DropTable(
                name: "DictionaryDetail");

            migrationBuilder.DropTable(
                name: "Permission");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Module");

            migrationBuilder.DropTable(
                name: "DictionaryType");

            migrationBuilder.DropTable(
                name: "Position");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Organization");

            migrationBuilder.DropTable(
                name: "Company");
        }
    }
}
