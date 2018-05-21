using Microsoft.EntityFrameworkCore.Migrations;
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
                    Id = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    Contact = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedTime = table.Column<DateTime>(nullable: true),
                    Creator = table.Column<string>(nullable: true),
                    DeletedBy = table.Column<string>(nullable: true),
                    DeletedTime = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Enabled = table.Column<bool>(nullable: false),
                    FullName = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Mobile = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedTime = table.Column<DateTime>(nullable: true),
                    Nature = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    ShortName = table.Column<string>(nullable: true),
                    Website = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permission",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AccessId = table.Column<string>(nullable: true),
                    AccessType = table.Column<short>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedTime = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<string>(nullable: true),
                    DeletedTime = table.Column<DateTime>(nullable: true),
                    Enabled = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    MasterId = table.Column<string>(nullable: true),
                    MasterType = table.Column<short>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedTime = table.Column<DateTime>(nullable: true),
                    SortNumber = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Module",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Category = table.Column<byte>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    CompanyId = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedTime = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<string>(nullable: true),
                    DeletedTime = table.Column<DateTime>(nullable: true),
                    Enabled = table.Column<bool>(nullable: false),
                    Icon = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsExpanded = table.Column<bool>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    ParentId = table.Column<string>(nullable: true),
                    Rank = table.Column<short>(nullable: false),
                    Remark = table.Column<string>(nullable: true),
                    SortNumber = table.Column<int>(nullable: true),
                    Url = table.Column<string>(nullable: true)
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
                    Id = table.Column<string>(nullable: false),
                    Category = table.Column<byte>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    CompanyId = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedTime = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<string>(nullable: true),
                    DeletedTime = table.Column<DateTime>(nullable: true),
                    Enabled = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    ParentId = table.Column<string>(nullable: true),
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
                    Id = table.Column<string>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    CompanyId = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedTime = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<string>(nullable: true),
                    DeletedTime = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Enabled = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true)
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
                name: "Button",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedTime = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<string>(nullable: true),
                    DeletedTime = table.Column<DateTime>(nullable: true),
                    Enabled = table.Column<bool>(nullable: false),
                    Icon = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    JsEvent = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedTime = table.Column<DateTime>(nullable: true),
                    ModuleId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    SortNumber = table.Column<int>(nullable: false),
                    Url = table.Column<string>(nullable: true)
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
                    Id = table.Column<string>(nullable: false),
                    CompanyId = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedTime = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<string>(nullable: true),
                    DeletedTime = table.Column<DateTime>(nullable: true),
                    DepartmentId = table.Column<string>(nullable: true),
                    Enabled = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    OrganizationId = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
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
                        name: "FK_Position_Organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Account = table.Column<string>(nullable: true),
                    Avatar = table.Column<string>(nullable: true),
                    Birthday = table.Column<DateTime>(nullable: true),
                    CompanyId = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedTime = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<string>(nullable: true),
                    DeletedTime = table.Column<DateTime>(nullable: true),
                    DepartmentId = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Enabled = table.Column<bool>(nullable: false),
                    Gender = table.Column<byte>(nullable: true),
                    IdCard = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Mobile = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedTime = table.Column<DateTime>(nullable: true),
                    OrganizationId = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    PositionId = table.Column<string>(nullable: true),
                    RealName = table.Column<string>(nullable: true),
                    RoleId = table.Column<string>(nullable: true),
                    Salt = table.Column<string>(nullable: true),
                    WorkgroupId = table.Column<string>(nullable: true)
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
                        name: "FK_User_Organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organization",
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
                });

            migrationBuilder.CreateIndex(
                name: "IX_Button_ModuleId",
                table: "Button",
                column: "ModuleId");

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
                name: "IX_Position_OrganizationId",
                table: "Position",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Role_CompanyId",
                table: "Role",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_User_CompanyId",
                table: "User",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_User_OrganizationId",
                table: "User",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_User_PositionId",
                table: "User",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_User_RoleId",
                table: "User",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Button");

            migrationBuilder.DropTable(
                name: "Permission");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Module");

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
