using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Boards.Migrations
{
    /// <inheritdoc />
    public partial class AdditionalTagsSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tags",
                column: "Value",
                value: "API");

            migrationBuilder.InsertData(
                table: "Tags",
                column: "Value",
                value: "Service");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
             table: "Tags",
             keyColumn: "Value",
             keyValue: "API");

            migrationBuilder.DeleteData(
             table: "Tags",
             keyColumn: "Value",
             keyValue: "Service");
        }
    }
}
