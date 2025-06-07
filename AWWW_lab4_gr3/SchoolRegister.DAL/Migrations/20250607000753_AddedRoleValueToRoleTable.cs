using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolRegister.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddedRoleValueToRoleTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IssuedByTeacherId",
                table: "Grades",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RoleValue",
                table: "AspNetRoles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Grades_IssuedByTeacherId",
                table: "Grades",
                column: "IssuedByTeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_AspNetUsers_IssuedByTeacherId",
                table: "Grades",
                column: "IssuedByTeacherId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grades_AspNetUsers_IssuedByTeacherId",
                table: "Grades");

            migrationBuilder.DropIndex(
                name: "IX_Grades_IssuedByTeacherId",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "IssuedByTeacherId",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "RoleValue",
                table: "AspNetRoles");
        }
    }
}
