using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Focus.Domain.Migrations
{
    public partial class AddFile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "MasterType",
                table: "Permission",
                nullable: false,
                oldClrType: typeof(short));

            migrationBuilder.AlterColumn<byte>(
                name: "AccessType",
                table: "Permission",
                nullable: false,
                oldClrType: typeof(short));

            migrationBuilder.CreateTable(
                name: "File",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 36, nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Path = table.Column<string>(maxLength: 512, nullable: true),
                    Type = table.Column<byte>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 36, nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "File");

            migrationBuilder.AlterColumn<short>(
                name: "MasterType",
                table: "Permission",
                nullable: false,
                oldClrType: typeof(byte));

            migrationBuilder.AlterColumn<short>(
                name: "AccessType",
                table: "Permission",
                nullable: false,
                oldClrType: typeof(byte));
        }
    }
}
