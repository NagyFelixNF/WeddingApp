using Microsoft.EntityFrameworkCore.Migrations;

namespace WeddingAppApi.Data.Migrations
{
    public partial class ClearedWed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Weddings");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "Weddings",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
