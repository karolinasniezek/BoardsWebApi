using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Boards.Migrations
{
    /// <inheritdoc />
    public partial class AddAdditionStateSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "States",
                column: "Value",
                value: "On Hold");

            migrationBuilder.InsertData(
                table: "States",
                column: "Value",
                value: "Rejected");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Value",
                keyValue: "On Hold");

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Value",
                keyValue: "Rejected");
        }
    }
}
