using Microsoft.EntityFrameworkCore.Migrations;

namespace WeddingAppApi.Data.Migrations
{
    public partial class PrepUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WeddingId",
                table: "Users",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Weddings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AppUserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weddings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Weddings_Users_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Preparations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Completed = table.Column<bool>(type: "INTEGER", nullable: false),
                    WeddingId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Preparations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Preparations_Weddings_WeddingId",
                        column: x => x.WeddingId,
                        principalTable: "Weddings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubPreparations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Completed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PreparationId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubPreparations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubPreparations_Preparations_PreparationId",
                        column: x => x.PreparationId,
                        principalTable: "Preparations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Preparations_WeddingId",
                table: "Preparations",
                column: "WeddingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubPreparations_PreparationId",
                table: "SubPreparations",
                column: "PreparationId");

            migrationBuilder.CreateIndex(
                name: "IX_Weddings_AppUserId",
                table: "Weddings",
                column: "AppUserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubPreparations");

            migrationBuilder.DropTable(
                name: "Preparations");

            migrationBuilder.DropTable(
                name: "Weddings");

            migrationBuilder.DropColumn(
                name: "WeddingId",
                table: "Users");
        }
    }
}
