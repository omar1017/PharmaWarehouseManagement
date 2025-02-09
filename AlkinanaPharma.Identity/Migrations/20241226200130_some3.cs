using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlkinanaPharma.Identity.Migrations
{
    /// <inheritdoc />
    public partial class some3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6a1508f2-95ea-4496-ab0a-06291adc542f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "244bcf37-f62b-411c-8f21-4b37569fad0a", "AQAAAAIAAYagAAAAENppdm5wJXmtm7ozu90qcMS5cwyQgiDXLe0xdnG8yudGB7bIMQzAImK2IZR5QEx7rw==", "b152f559-8d91-4772-99e9-f02354f886df" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f2d89605-cf8a-4aaa-a1fc-4d454ea568ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "733751dd-1ceb-4fcb-97bd-a279ca5608f1", "AQAAAAIAAYagAAAAEPX085Euzwy1NdRiSKm1g7w9CNEU8FW0Zo7P6Cs1l7dPddBAng8KVet1Cy/hqY2hug==", "4d7b7262-b3e9-46eb-a6d5-980775b9a9d8" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6a1508f2-95ea-4496-ab0a-06291adc542f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bfc44e46-a599-496b-aaab-5ca8f3214582", "AQAAAAIAAYagAAAAEACf+byrRwOAhsf93Tr1BDa7mUHkyxaycdILqZ9HSaZRGPASZYw4Ct4+cj0idS0i3Q==", "34d3641d-ce0d-4067-9065-dd14776a5bcb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f2d89605-cf8a-4aaa-a1fc-4d454ea568ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ac589682-f729-4877-b985-a92cb90d760b", "AQAAAAIAAYagAAAAENjbclzuQbeaIXQkQrTePoZyqxSTv4V8utDE4OiZJRyLAqmlZ1tQ9VeFJXwgMR4r1Q==", "ce922714-c17b-4a95-8db6-a4cb90582e60" });
        }
    }
}
