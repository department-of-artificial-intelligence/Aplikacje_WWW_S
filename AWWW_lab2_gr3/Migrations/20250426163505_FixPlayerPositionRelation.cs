using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AWWW_lab2_gr3.Migrations
{
    /// <inheritdoc />
    public partial class FixPlayerPositionRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Playeres_Teams_TeamId",
                table: "Playeres");

            migrationBuilder.AddForeignKey(
                name: "FK_Playeres_Teams_TeamId",
                table: "Playeres",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Playeres_Teams_TeamId",
                table: "Playeres");

            migrationBuilder.AddForeignKey(
                name: "FK_Playeres_Teams_TeamId",
                table: "Playeres",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id");
        }
    }
}
