using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Services.Migrations
{
    /// <inheritdoc />
    public partial class changedata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "schools",
                keyColumn: "Id",
                keyValue: 2,
                column: "Address",
                value: "Delhi");

            migrationBuilder.UpdateData(
                table: "schools",
                keyColumn: "Id",
                keyValue: 3,
                column: "Address",
                value: "Delhi");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "schools",
                keyColumn: "Id",
                keyValue: 2,
                column: "Address",
                value: "Noida");

            migrationBuilder.UpdateData(
                table: "schools",
                keyColumn: "Id",
                keyValue: 3,
                column: "Address",
                value: "Gurgaon");
        }
    }
}
