using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AWWW_lab1_gr2.Migrations
{
    /// <inheritdoc />
    public partial class Mig4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "PK_Tag",
                table: "Tag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Author",
                table: "Author");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Article",
                table: "Article");

            migrationBuilder.RenameTable(
                name: "Tag",
                newName: "Tags");

            migrationBuilder.RenameTable(
                name: "Author",
                newName: "Authors");

            migrationBuilder.RenameTable(
                name: "Article",
                newName: "Articles");

            migrationBuilder.RenameIndex(
                name: "IX_Tag_ArticleId",
                table: "Tags",
                newName: "IX_Tags_ArticleId");

            migrationBuilder.RenameIndex(
                name: "IX_Article_MatchId",
                table: "Articles",
                newName: "IX_Articles_MatchId");

            migrationBuilder.RenameIndex(
                name: "IX_Article_AuthorId",
                table: "Articles",
                newName: "IX_Articles_AuthorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tags",
                table: "Tags",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Authors",
                table: "Authors",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Articles",
                table: "Articles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Authors_AuthorId",
                table: "Articles",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Matches_MatchId",
                table: "Articles",
                column: "MatchId",
                principalTable: "Matches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Articles_ArticleId",
                table: "Tags",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Authors_AuthorId",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Matches_MatchId",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Articles_ArticleId",
                table: "Tags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tags",
                table: "Tags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Authors",
                table: "Authors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Articles",
                table: "Articles");

            migrationBuilder.RenameTable(
                name: "Tags",
                newName: "Tag");

            migrationBuilder.RenameTable(
                name: "Authors",
                newName: "Author");

            migrationBuilder.RenameTable(
                name: "Articles",
                newName: "Article");

            migrationBuilder.RenameIndex(
                name: "IX_Tags_ArticleId",
                table: "Tag",
                newName: "IX_Tag_ArticleId");

            migrationBuilder.RenameIndex(
                name: "IX_Articles_MatchId",
                table: "Article",
                newName: "IX_Article_MatchId");

            migrationBuilder.RenameIndex(
                name: "IX_Articles_AuthorId",
                table: "Article",
                newName: "IX_Article_AuthorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tag",
                table: "Tag",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Author",
                table: "Author",
                column: "Id");

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
    }
}
