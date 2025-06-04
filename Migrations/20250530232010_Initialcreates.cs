using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Final_project.Migrations
{
    /// <inheritdoc />
    public partial class Initialcreates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Customer",
                newName: "Name");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Product",
                type: "decimal(6,2)",
                precision: 6,
                scale: 2,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldPrecision: 6,
                oldScale: 2);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Customer",
                newName: "Username");

            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "Product",
                type: "int",
                precision: 6,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(6,2)",
                oldPrecision: 6,
                oldScale: 2);
        }
    }
}
