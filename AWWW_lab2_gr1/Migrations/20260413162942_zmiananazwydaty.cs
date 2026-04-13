using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AWWW_lab2_gr1.Migrations
{
    /// <inheritdoc />
    public partial class zmiananazwydaty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateChanged",
                table: "OrderStatusHistories",
                newName: "ChangedAt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ChangedAt",
                table: "OrderStatusHistories",
                newName: "DateChanged");
        }
    }
}
