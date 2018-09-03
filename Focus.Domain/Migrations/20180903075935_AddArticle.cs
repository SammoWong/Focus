using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Focus.Domain.Migrations
{
    public partial class AddArticle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Article",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 36, nullable: false),
                    Category = table.Column<byte>(nullable: false),
                    Title = table.Column<string>(maxLength: 50, nullable: true),
                    Content = table.Column<string>(type: "NVARCHAR(MAX)", nullable: true),
                    IsTop = table.Column<bool>(nullable: false),
                    Enabled = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 36, nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 36, nullable: true),
                    ModifiedTime = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Article", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Article");
        }
    }
}
