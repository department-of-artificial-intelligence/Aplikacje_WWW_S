using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AWWW_lab2_gr3.Migrations
{
    /// <inheritdoc />
    public partial class wstepna : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Author_AuthorId",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Category_CategoryId",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Matches_ArticleId",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Articles_ArticleId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_MatchEvent_EventType_EventTypeId",
                table: "MatchEvent");

            migrationBuilder.DropForeignKey(
                name: "FK_MatchEvent_MatchPlayer_MatchPlayerId",
                table: "MatchEvent");

            migrationBuilder.DropForeignKey(
                name: "FK_MatchEvent_Matches_MatchId",
                table: "MatchEvent");

            migrationBuilder.DropForeignKey(
                name: "FK_MatchPlayer_Matches_MatchId",
                table: "MatchPlayer");

            migrationBuilder.DropForeignKey(
                name: "FK_MatchPlayer_Player_PlayerId",
                table: "MatchPlayer");

            migrationBuilder.DropForeignKey(
                name: "FK_MatchPlayer_Position_PositionId",
                table: "MatchPlayer");

            migrationBuilder.DropForeignKey(
                name: "FK_Player_Teams_TeamId",
                table: "Player");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerPosition_Player_PlayersId",
                table: "PlayerPosition");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerPosition_Position_PositionsId",
                table: "PlayerPosition");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_League_LeagueId",
                table: "Teams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Position",
                table: "Position");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Player",
                table: "Player");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MatchPlayer",
                table: "MatchPlayer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MatchEvent",
                table: "MatchEvent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_League",
                table: "League");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventType",
                table: "EventType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comment",
                table: "Comment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Author",
                table: "Author");

            migrationBuilder.RenameTable(
                name: "Position",
                newName: "Positions");

            migrationBuilder.RenameTable(
                name: "Player",
                newName: "Playeres");

            migrationBuilder.RenameTable(
                name: "MatchPlayer",
                newName: "MatchPlayers");

            migrationBuilder.RenameTable(
                name: "MatchEvent",
                newName: "MatchEvents");

            migrationBuilder.RenameTable(
                name: "League",
                newName: "Leagues");

            migrationBuilder.RenameTable(
                name: "EventType",
                newName: "EventTypes");

            migrationBuilder.RenameTable(
                name: "Comment",
                newName: "Comments");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Categories");

            migrationBuilder.RenameTable(
                name: "Author",
                newName: "Authors");

            migrationBuilder.RenameColumn(
                name: "ArticleId",
                table: "Articles",
                newName: "MatchId");

            migrationBuilder.RenameIndex(
                name: "IX_Articles_ArticleId",
                table: "Articles",
                newName: "IX_Articles_MatchId");

            migrationBuilder.RenameIndex(
                name: "IX_Player_TeamId",
                table: "Playeres",
                newName: "IX_Playeres_TeamId");

            migrationBuilder.RenameIndex(
                name: "IX_MatchPlayer_PositionId",
                table: "MatchPlayers",
                newName: "IX_MatchPlayers_PositionId");

            migrationBuilder.RenameIndex(
                name: "IX_MatchPlayer_PlayerId",
                table: "MatchPlayers",
                newName: "IX_MatchPlayers_PlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_MatchPlayer_MatchId",
                table: "MatchPlayers",
                newName: "IX_MatchPlayers_MatchId");

            migrationBuilder.RenameIndex(
                name: "IX_MatchEvent_MatchPlayerId",
                table: "MatchEvents",
                newName: "IX_MatchEvents_MatchPlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_MatchEvent_MatchId",
                table: "MatchEvents",
                newName: "IX_MatchEvents_MatchId");

            migrationBuilder.RenameIndex(
                name: "IX_MatchEvent_EventTypeId",
                table: "MatchEvents",
                newName: "IX_MatchEvents_EventTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_ArticleId",
                table: "Comments",
                newName: "IX_Comments_ArticleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Positions",
                table: "Positions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Playeres",
                table: "Playeres",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MatchPlayers",
                table: "MatchPlayers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MatchEvents",
                table: "MatchEvents",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Leagues",
                table: "Leagues",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventTypes",
                table: "EventTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Authors",
                table: "Authors",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Authors_AuthorId",
                table: "Articles",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Categories_CategoryId",
                table: "Articles",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Matches_MatchId",
                table: "Articles",
                column: "MatchId",
                principalTable: "Matches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Articles_ArticleId",
                table: "Comments",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MatchEvents_EventTypes_EventTypeId",
                table: "MatchEvents",
                column: "EventTypeId",
                principalTable: "EventTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MatchEvents_MatchPlayers_MatchPlayerId",
                table: "MatchEvents",
                column: "MatchPlayerId",
                principalTable: "MatchPlayers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MatchEvents_Matches_MatchId",
                table: "MatchEvents",
                column: "MatchId",
                principalTable: "Matches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MatchPlayers_Matches_MatchId",
                table: "MatchPlayers",
                column: "MatchId",
                principalTable: "Matches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MatchPlayers_Playeres_PlayerId",
                table: "MatchPlayers",
                column: "PlayerId",
                principalTable: "Playeres",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MatchPlayers_Positions_PositionId",
                table: "MatchPlayers",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Playeres_Teams_TeamId",
                table: "Playeres",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerPosition_Playeres_PlayersId",
                table: "PlayerPosition",
                column: "PlayersId",
                principalTable: "Playeres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerPosition_Positions_PositionsId",
                table: "PlayerPosition",
                column: "PositionsId",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Leagues_LeagueId",
                table: "Teams",
                column: "LeagueId",
                principalTable: "Leagues",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Authors_AuthorId",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Categories_CategoryId",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Matches_MatchId",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Articles_ArticleId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_MatchEvents_EventTypes_EventTypeId",
                table: "MatchEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_MatchEvents_MatchPlayers_MatchPlayerId",
                table: "MatchEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_MatchEvents_Matches_MatchId",
                table: "MatchEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_MatchPlayers_Matches_MatchId",
                table: "MatchPlayers");

            migrationBuilder.DropForeignKey(
                name: "FK_MatchPlayers_Playeres_PlayerId",
                table: "MatchPlayers");

            migrationBuilder.DropForeignKey(
                name: "FK_MatchPlayers_Positions_PositionId",
                table: "MatchPlayers");

            migrationBuilder.DropForeignKey(
                name: "FK_Playeres_Teams_TeamId",
                table: "Playeres");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerPosition_Playeres_PlayersId",
                table: "PlayerPosition");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerPosition_Positions_PositionsId",
                table: "PlayerPosition");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Leagues_LeagueId",
                table: "Teams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Positions",
                table: "Positions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Playeres",
                table: "Playeres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MatchPlayers",
                table: "MatchPlayers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MatchEvents",
                table: "MatchEvents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Leagues",
                table: "Leagues");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventTypes",
                table: "EventTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Authors",
                table: "Authors");

            migrationBuilder.RenameTable(
                name: "Positions",
                newName: "Position");

            migrationBuilder.RenameTable(
                name: "Playeres",
                newName: "Player");

            migrationBuilder.RenameTable(
                name: "MatchPlayers",
                newName: "MatchPlayer");

            migrationBuilder.RenameTable(
                name: "MatchEvents",
                newName: "MatchEvent");

            migrationBuilder.RenameTable(
                name: "Leagues",
                newName: "League");

            migrationBuilder.RenameTable(
                name: "EventTypes",
                newName: "EventType");

            migrationBuilder.RenameTable(
                name: "Comments",
                newName: "Comment");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Category");

            migrationBuilder.RenameTable(
                name: "Authors",
                newName: "Author");

            migrationBuilder.RenameColumn(
                name: "MatchId",
                table: "Articles",
                newName: "ArticleId");

            migrationBuilder.RenameIndex(
                name: "IX_Articles_MatchId",
                table: "Articles",
                newName: "IX_Articles_ArticleId");

            migrationBuilder.RenameIndex(
                name: "IX_Playeres_TeamId",
                table: "Player",
                newName: "IX_Player_TeamId");

            migrationBuilder.RenameIndex(
                name: "IX_MatchPlayers_PositionId",
                table: "MatchPlayer",
                newName: "IX_MatchPlayer_PositionId");

            migrationBuilder.RenameIndex(
                name: "IX_MatchPlayers_PlayerId",
                table: "MatchPlayer",
                newName: "IX_MatchPlayer_PlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_MatchPlayers_MatchId",
                table: "MatchPlayer",
                newName: "IX_MatchPlayer_MatchId");

            migrationBuilder.RenameIndex(
                name: "IX_MatchEvents_MatchPlayerId",
                table: "MatchEvent",
                newName: "IX_MatchEvent_MatchPlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_MatchEvents_MatchId",
                table: "MatchEvent",
                newName: "IX_MatchEvent_MatchId");

            migrationBuilder.RenameIndex(
                name: "IX_MatchEvents_EventTypeId",
                table: "MatchEvent",
                newName: "IX_MatchEvent_EventTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_ArticleId",
                table: "Comment",
                newName: "IX_Comment_ArticleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Position",
                table: "Position",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Player",
                table: "Player",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MatchPlayer",
                table: "MatchPlayer",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MatchEvent",
                table: "MatchEvent",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_League",
                table: "League",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventType",
                table: "EventType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comment",
                table: "Comment",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Author",
                table: "Author",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Author_AuthorId",
                table: "Articles",
                column: "AuthorId",
                principalTable: "Author",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Category_CategoryId",
                table: "Articles",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Matches_ArticleId",
                table: "Articles",
                column: "ArticleId",
                principalTable: "Matches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Articles_ArticleId",
                table: "Comment",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MatchEvent_EventType_EventTypeId",
                table: "MatchEvent",
                column: "EventTypeId",
                principalTable: "EventType",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MatchEvent_MatchPlayer_MatchPlayerId",
                table: "MatchEvent",
                column: "MatchPlayerId",
                principalTable: "MatchPlayer",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MatchEvent_Matches_MatchId",
                table: "MatchEvent",
                column: "MatchId",
                principalTable: "Matches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MatchPlayer_Matches_MatchId",
                table: "MatchPlayer",
                column: "MatchId",
                principalTable: "Matches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MatchPlayer_Player_PlayerId",
                table: "MatchPlayer",
                column: "PlayerId",
                principalTable: "Player",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MatchPlayer_Position_PositionId",
                table: "MatchPlayer",
                column: "PositionId",
                principalTable: "Position",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Player_Teams_TeamId",
                table: "Player",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerPosition_Player_PlayersId",
                table: "PlayerPosition",
                column: "PlayersId",
                principalTable: "Player",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerPosition_Position_PositionsId",
                table: "PlayerPosition",
                column: "PositionsId",
                principalTable: "Position",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_League_LeagueId",
                table: "Teams",
                column: "LeagueId",
                principalTable: "League",
                principalColumn: "Id");
        }
    }
}
