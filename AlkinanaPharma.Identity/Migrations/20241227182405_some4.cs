using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AlkinanaPharma.Identity.Migrations
{
    /// <inheritdoc />
    public partial class some4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "16ddca1c-6b97-423d-89e0-6027bf06a8f7", "6a1508f2-95ea-4496-ab0a-06291adc542f" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c0129f08-509b-4731-ac4a-507b6a092aa7", "f2d89605-cf8a-4aaa-a1fc-4d454ea568ff" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "c0129f08-509b-4731-ac4a-507b6a092aa7", "6a1508f2-95ea-4496-ab0a-06291adc542f" },
                    { "16ddca1c-6b97-423d-89e0-6027bf06a8f7", "f2d89605-cf8a-4aaa-a1fc-4d454ea568ff" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6a1508f2-95ea-4496-ab0a-06291adc542f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b1584842-bda5-436c-a5e6-12fec221862f", "AQAAAAIAAYagAAAAENLfaTdrSazYFmVNDKN0ohs0laeDwX9AEpUnF0rt2kvnE2xdbetmmOHsGb4nicb7dg==", "d36d3083-bddc-4460-9db0-6334a56da991" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f2d89605-cf8a-4aaa-a1fc-4d454ea568ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f814fb88-284c-484a-ae99-3b85a468c39d", "AQAAAAIAAYagAAAAEPF+TZdvxfMashT3hn8MtvpudcAO6p8JodZZFUvdA/RECZk/cCLP1GjaI22OJMhjAA==", "e05c69e8-ef11-4d64-bb73-f3e49a3d8b05" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c0129f08-509b-4731-ac4a-507b6a092aa7", "6a1508f2-95ea-4496-ab0a-06291adc542f" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "16ddca1c-6b97-423d-89e0-6027bf06a8f7", "f2d89605-cf8a-4aaa-a1fc-4d454ea568ff" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "16ddca1c-6b97-423d-89e0-6027bf06a8f7", "6a1508f2-95ea-4496-ab0a-06291adc542f" },
                    { "c0129f08-509b-4731-ac4a-507b6a092aa7", "f2d89605-cf8a-4aaa-a1fc-4d454ea568ff" }
                });

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
    }
}
