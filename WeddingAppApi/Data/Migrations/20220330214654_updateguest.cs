using Microsoft.EntityFrameworkCore.Migrations;

namespace WeddingAppApi.Data.Migrations
{
    public partial class updateguest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Seatid",
                table: "Guests",
                type: "INTEGER",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Seatid",
                table: "Guests");
        }
    }
}
