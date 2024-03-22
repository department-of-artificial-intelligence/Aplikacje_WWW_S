using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AWWW_lab1_gr1.Migrations
{
    /// <inheritdoc />
    public partial class SeeedDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[] { 1, "Mateusz", "Janik" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
