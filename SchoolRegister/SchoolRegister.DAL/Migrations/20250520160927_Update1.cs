using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolRegister.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Update1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Grades",
                table: "Grades");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Grades",
                table: "Grades",
                columns: new[] { "SubjectId", "StudentId", "DateOfIssue" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Grades",
                table: "Grades");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Grades",
                table: "Grades",
                columns: new[] { "SubjectId", "StudentId" });
        }
    }
}
