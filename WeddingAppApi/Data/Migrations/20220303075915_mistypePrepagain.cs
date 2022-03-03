using Microsoft.EntityFrameworkCore.Migrations;

namespace WeddingAppApi.Data.Migrations
{
    public partial class mistypePrepagain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Preparations_WeddingId",
                table: "Preparations");

            migrationBuilder.CreateIndex(
                name: "IX_Preparations_WeddingId",
                table: "Preparations",
                column: "WeddingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Preparations_WeddingId",
                table: "Preparations");

            migrationBuilder.CreateIndex(
                name: "IX_Preparations_WeddingId",
                table: "Preparations",
                column: "WeddingId",
                unique: true);
        }
    }
}
