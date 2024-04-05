using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AWWW_lab1_gr2.Migrations
{
    /// <inheritdoc />
    public partial class Mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Author_AuthorId",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Matches_MatchId",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Tag_Articles_ArticleId",
                table: "Tag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Articles",
                table: "Articles");

            migrationBuilder.RenameTable(
                name: "Articles",
                newName: "Article");

            migrationBuilder.RenameIndex(
                name: "IX_Articles_MatchId",
                table: "Article",
                newName: "IX_Article_MatchId");

            migrationBuilder.RenameIndex(
                name: "IX_Articles_AuthorId",
                table: "Article",
                newName: "IX_Article_AuthorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Article",
                table: "Article",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Article_Author_AuthorId",
                table: "Article",
                column: "AuthorId",
                principalTable: "Author",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Article_Matches_MatchId",
                table: "Article",
                column: "MatchId",
                principalTable: "Matches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tag_Article_ArticleId",
                table: "Tag",
                column: "ArticleId",
                principalTable: "Article",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Article_Author_AuthorId",
                table: "Article");

            migrationBuilder.DropForeignKey(
                name: "FK_Article_Matches_MatchId",
                table: "Article");

            migrationBuilder.DropForeignKey(
                name: "FK_Tag_Article_ArticleId",
                table: "Tag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Article",
                table: "Article");

            migrationBuilder.RenameTable(
                name: "Article",
                newName: "Articles");

            migrationBuilder.RenameIndex(
                name: "IX_Article_MatchId",
                table: "Articles",
                newName: "IX_Articles_MatchId");

            migrationBuilder.RenameIndex(
                name: "IX_Article_AuthorId",
                table: "Articles",
                newName: "IX_Articles_AuthorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Articles",
                table: "Articles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Author_AuthorId",
                table: "Articles",
                column: "AuthorId",
                principalTable: "Author",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Matches_MatchId",
                table: "Articles",
                column: "MatchId",
                principalTable: "Matches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tag_Articles_ArticleId",
                table: "Tag",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id");
        }
    }
}
