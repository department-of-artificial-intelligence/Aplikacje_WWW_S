using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AWWW_lab1_gr2.Migrations
{
    /// <inheritdoc />
    public partial class poprawiona1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatchPlayers_Postitions_PositionId",
                table: "MatchPlayers");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerPosition_Postitions_PositionsId",
                table: "PlayerPosition");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Postitions",
                table: "Postitions");

            migrationBuilder.RenameTable(
                name: "Postitions",
                newName: "Positions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Positions",
                table: "Positions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MatchPlayers_Positions_PositionId",
                table: "MatchPlayers",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerPosition_Positions_PositionsId",
                table: "PlayerPosition",
                column: "PositionsId",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatchPlayers_Positions_PositionId",
                table: "MatchPlayers");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerPosition_Positions_PositionsId",
                table: "PlayerPosition");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Positions",
                table: "Positions");

            migrationBuilder.RenameTable(
                name: "Positions",
                newName: "Postitions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Postitions",
                table: "Postitions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MatchPlayers_Postitions_PositionId",
                table: "MatchPlayers",
                column: "PositionId",
                principalTable: "Postitions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerPosition_Postitions_PositionsId",
                table: "PlayerPosition",
                column: "PositionsId",
                principalTable: "Postitions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
