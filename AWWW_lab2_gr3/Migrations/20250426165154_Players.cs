using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AWWW_lab2_gr3.Migrations
{
    /// <inheritdoc />
    public partial class Players : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatchPlayers_Playeres_PlayerId",
                table: "MatchPlayers");

            migrationBuilder.DropForeignKey(
                name: "FK_Playeres_Teams_TeamId",
                table: "Playeres");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerPosition_Playeres_PlayersId",
                table: "PlayerPosition");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Playeres",
                table: "Playeres");

            migrationBuilder.RenameTable(
                name: "Playeres",
                newName: "Players");

            migrationBuilder.RenameIndex(
                name: "IX_Playeres_TeamId",
                table: "Players",
                newName: "IX_Players_TeamId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Players",
                table: "Players",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MatchPlayers_Players_PlayerId",
                table: "MatchPlayers",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerPosition_Players_PlayersId",
                table: "PlayerPosition",
                column: "PlayersId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Teams_TeamId",
                table: "Players",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatchPlayers_Players_PlayerId",
                table: "MatchPlayers");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerPosition_Players_PlayersId",
                table: "PlayerPosition");

            migrationBuilder.DropForeignKey(
                name: "FK_Players_Teams_TeamId",
                table: "Players");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Players",
                table: "Players");

            migrationBuilder.RenameTable(
                name: "Players",
                newName: "Playeres");

            migrationBuilder.RenameIndex(
                name: "IX_Players_TeamId",
                table: "Playeres",
                newName: "IX_Playeres_TeamId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Playeres",
                table: "Playeres",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MatchPlayers_Playeres_PlayerId",
                table: "MatchPlayers",
                column: "PlayerId",
                principalTable: "Playeres",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Playeres_Teams_TeamId",
                table: "Playeres",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerPosition_Playeres_PlayersId",
                table: "PlayerPosition",
                column: "PlayersId",
                principalTable: "Playeres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
