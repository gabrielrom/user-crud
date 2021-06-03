using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace user_crud.src.Database.EFCore.Migrations
{
  public partial class InitialCreate : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.CreateTable(
          name: "Users",
          columns: table => new
          {
            id = table.Column<string>(type: "text", nullable: false),
            name = table.Column<string>(type: "text", nullable: false),
            email = table.Column<string>(type: "text", nullable: false),
            password = table.Column<string>(type: "text", nullable: false),
            created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Users", x => x.id);
          });
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(
          name: "Users");
    }
  }
}
