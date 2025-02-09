using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlkinanaPharma.Identity.Migrations
{
    /// <inheritdoc />
    public partial class fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6a1508f2-95ea-4496-ab0a-06291adc542f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cf712616-1214-461e-807f-3bdd868b067b", "AQAAAAIAAYagAAAAEPBQyVwbaLSyh5LkqYlvLRnvS9uexjMPpTDtBKQlpYCBvI8aXY4v4VOFEYKSy/1p8A==", "2477e26f-809c-4ab5-847c-d6b1c665da47" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f2d89605-cf8a-4aaa-a1fc-4d454ea568ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "310d2d95-38e4-4792-8b5a-d7280f4f99f4", "AQAAAAIAAYagAAAAEAx78jV94hgU4ICckDt2nX788qSh/I63bZMRrjyRN+zqYotYMsH88NCAKFx+3dTmBA==", "de97831f-126c-4c3c-8443-5308591539cb" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6a1508f2-95ea-4496-ab0a-06291adc542f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a25729bf-f3bc-4d46-858c-1dada9d994d2", "AQAAAAIAAYagAAAAEJ/sMXTOoy8fcw2pdZbs9pc+hiBXcLMBbIAMGYj+oXsLrDmlq/cavn92bq72k3m2zA==", "7c8d521c-4ef6-4625-af2d-3cd0791da134" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f2d89605-cf8a-4aaa-a1fc-4d454ea568ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fa000a6c-0bc3-4b86-9f7e-6057a01d5383", "AQAAAAIAAYagAAAAEGFvC3mUdJsOSjD3MyDmBZejIbt0kCWJojVYeZBk+k3A8/tetXRi8+EbDxcCZ0JpMw==", "57635eae-202e-4470-b9c1-af32babf7cdd" });
        }
    }
}
