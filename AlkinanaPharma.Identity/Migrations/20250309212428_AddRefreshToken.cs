using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlkinanaPharma.Identity.Migrations
{
    /// <inheritdoc />
    public partial class AddRefreshToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JwtId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false),
                    IsRevoked = table.Column<bool>(type: "bit", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6a1508f2-95ea-4496-ab0a-06291adc542f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bb03ef56-63c2-4321-ab16-7b6ab7aef1e3", "AQAAAAIAAYagAAAAEEcKN/0v28ePtLIuAtikPH7/PWOEoE6rrwllSHpXHojlK/zWHuMi38DuHhd+I4lckA==", "0bfb5a12-2539-4bf4-89b5-9e5f84b80c94" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f2d89605-cf8a-4aaa-a1fc-4d454ea568ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aeb6b633-fb53-46f1-bada-40065a494d78", "AQAAAAIAAYagAAAAEKMAhO5/Iz00GXo/gDxmiSr2Uio262KK06DTixpDbSQD9P8qxfA4v0ljqATw714Q5Q==", "38a38a54-a72c-4ff8-a427-0a6d3c2711d0" });

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokens",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6a1508f2-95ea-4496-ab0a-06291adc542f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c359bd99-d8b4-4ed4-8d79-8e58ea2b49bf", "AQAAAAIAAYagAAAAEOtBisNMpdbv4tyuaZwO7djV2JxXbOPWnmn4dKgeaskziRQxfuggEIkgpfIljzCcYw==", "64e7f865-0621-44fc-9d8b-ac095f963105" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f2d89605-cf8a-4aaa-a1fc-4d454ea568ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "18921708-6f7c-4fed-8b74-92539e41973b", "AQAAAAIAAYagAAAAEF7EKh3hqPMuFgK/UGyJX8CRSp5Dmwj+WnU8YTdFstmDw6YNk82lgAFHPZkyrm8QtA==", "0eaa944d-a20c-44db-9091-ce94826b3d3f" });
        }
    }
}
