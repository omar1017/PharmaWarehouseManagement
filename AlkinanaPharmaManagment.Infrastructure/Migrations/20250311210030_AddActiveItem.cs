using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlkinanaPharmaManagment.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddActiveItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isFulfilled",
                table: "LineItem",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isFulfilled",
                table: "LineItem");
        }
    }
}
