using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderStore.Repository.Migrations
{
    /// <inheritdoc />
    public partial class removeprop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "products");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MyProperty",
                table: "products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
