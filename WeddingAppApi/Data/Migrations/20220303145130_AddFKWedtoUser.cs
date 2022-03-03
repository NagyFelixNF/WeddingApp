using Microsoft.EntityFrameworkCore.Migrations;

namespace WeddingAppApi.Data.Migrations
{
    public partial class AddFKWedtoUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Weddings_Users_AppUserId",
                table: "Weddings");

            migrationBuilder.DropIndex(
                name: "IX_Weddings_AppUserId",
                table: "Weddings");

            migrationBuilder.CreateIndex(
                name: "IX_Users_WeddingId",
                table: "Users",
                column: "WeddingId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Weddings_WeddingId",
                table: "Users",
                column: "WeddingId",
                principalTable: "Weddings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Weddings_WeddingId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_WeddingId",
                table: "Users");

            migrationBuilder.CreateIndex(
                name: "IX_Weddings_AppUserId",
                table: "Weddings",
                column: "AppUserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Weddings_Users_AppUserId",
                table: "Weddings",
                column: "AppUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
