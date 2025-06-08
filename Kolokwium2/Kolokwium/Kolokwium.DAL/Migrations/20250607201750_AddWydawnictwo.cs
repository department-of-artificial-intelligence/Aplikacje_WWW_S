using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kolokwium.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddWydawnictwo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Wydawnictwo",
                table: "Ksiazki");

            migrationBuilder.AddColumn<int>(
                name: "WydawnictwoId",
                table: "Ksiazki",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Wydawnictwo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wydawnictwo", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ksiazki_WydawnictwoId",
                table: "Ksiazki",
                column: "WydawnictwoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ksiazki_Wydawnictwo_WydawnictwoId",
                table: "Ksiazki",
                column: "WydawnictwoId",
                principalTable: "Wydawnictwo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ksiazki_Wydawnictwo_WydawnictwoId",
                table: "Ksiazki");

            migrationBuilder.DropTable(
                name: "Wydawnictwo");

            migrationBuilder.DropIndex(
                name: "IX_Ksiazki_WydawnictwoId",
                table: "Ksiazki");

            migrationBuilder.DropColumn(
                name: "WydawnictwoId",
                table: "Ksiazki");

            migrationBuilder.AddColumn<string>(
                name: "Wydawnictwo",
                table: "Ksiazki",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
