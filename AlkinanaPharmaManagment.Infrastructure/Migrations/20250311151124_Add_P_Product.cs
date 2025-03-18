using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlkinanaPharmaManagment.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Add_P_Product : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "PublicPrice",
                table: "Products",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Quantity",
                table: "Products",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SName",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PublicPrice",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SName",
                table: "Products");
        }
    }
}
