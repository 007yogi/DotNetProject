using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Services.Migrations
{
    /// <inheritdoc />
    public partial class addnewdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "schools",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Amit");

            migrationBuilder.UpdateData(
                table: "schools",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Sumit");

            migrationBuilder.UpdateData(
                table: "schools",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Mohan");

            migrationBuilder.InsertData(
                table: "schools",
                columns: new[] { "Id", "Address", "Name" },
                values: new object[,]
                {
                    { 4, "Gurgaon", "Ram" },
                    { 5, "Delhi", "Shyam" },
                    { 6, "Delhi", "Monika" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "schools",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "schools",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "schools",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "schools",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "ABC");

            migrationBuilder.UpdateData(
                table: "schools",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "XYZ");

            migrationBuilder.UpdateData(
                table: "schools",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "PQR");
        }
    }
}
