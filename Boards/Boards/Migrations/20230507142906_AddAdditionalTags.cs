using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Boards.Migrations
{
    /// <inheritdoc />
    public partial class AddAdditionalTags : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tags",
                column: "Value",
                value: "Desktop");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Value",
                keyValue: "Desktop");
        }
    }
}
