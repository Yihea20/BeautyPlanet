using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class KeyProductStore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1da0859c-2d34-4580-b8bf-496f0ac5b1a8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "691b7e9e-ee99-4557-8d90-3e4b66c3e6ec");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ace52dd8-a6bb-4c43-8925-9022ec86d1d8");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "12d4f4c1-d021-42ba-96db-91eb598b4d08", null, "user", "USER" },
                    { "4f70613e-7466-4a64-9bf6-869d0412a72a", null, "employee", "EMPLOYEE" },
                    { "e5d29f9a-2a0b-46eb-9096-e71efdb155c6", null, "manager", "MANAGER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "12d4f4c1-d021-42ba-96db-91eb598b4d08");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4f70613e-7466-4a64-9bf6-869d0412a72a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e5d29f9a-2a0b-46eb-9096-e71efdb155c6");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1da0859c-2d34-4580-b8bf-496f0ac5b1a8", null, "user", "USER" },
                    { "691b7e9e-ee99-4557-8d90-3e4b66c3e6ec", null, "employee", "EMPLOYEE" },
                    { "ace52dd8-a6bb-4c43-8925-9022ec86d1d8", null, "manager", "MANAGER" }
                });
        }
    }
}
