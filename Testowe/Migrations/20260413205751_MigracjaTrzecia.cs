using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kolokwium.Migrations
{
    /// <inheritdoc />
    public partial class MigracjaTrzecia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ksiazki_Biblioteki_BibliotekaId",
                table: "Ksiazki");

            migrationBuilder.DropColumn(
                name: "IdBiblioteka",
                table: "Ksiazki");

            migrationBuilder.AlterColumn<int>(
                name: "BibliotekaId",
                table: "Ksiazki",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Ksiazki_Biblioteki_BibliotekaId",
                table: "Ksiazki",
                column: "BibliotekaId",
                principalTable: "Biblioteki",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ksiazki_Biblioteki_BibliotekaId",
                table: "Ksiazki");

            migrationBuilder.AlterColumn<int>(
                name: "BibliotekaId",
                table: "Ksiazki",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "IdBiblioteka",
                table: "Ksiazki",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Ksiazki_Biblioteki_BibliotekaId",
                table: "Ksiazki",
                column: "BibliotekaId",
                principalTable: "Biblioteki",
                principalColumn: "Id");
        }
    }
}
