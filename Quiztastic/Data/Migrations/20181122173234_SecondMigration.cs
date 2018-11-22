using Microsoft.EntityFrameworkCore.Migrations;

namespace Quiztastic.Data.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppTokens",
                columns: table => new
                {
                    AppId = table.Column<string>(nullable: false),
                    AppName = table.Column<string>(nullable: true),
                    Token = table.Column<string>(nullable: true),
                    Permission = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppTokens", x => x.AppId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppTokens");
        }
    }
}
