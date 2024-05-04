using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class ProdList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "35e29199-2da9-45dd-97c6-0793c58fb624");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3b63d87e-8618-480d-8d63-f9e905baa9e7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8292e75f-f396-437e-9042-2ef1c9bbc742");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "798b40d0-b2e5-4be6-8671-0711708855b6", null, "employee", "EMPLOYEE" },
                    { "9901efce-c318-4dfe-a95c-8a58f14ccec6", null, "manager", "MANAGER" },
                    { "d0c4cd8a-223c-4ffb-b71a-7193392a9080", null, "user", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "798b40d0-b2e5-4be6-8671-0711708855b6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9901efce-c318-4dfe-a95c-8a58f14ccec6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d0c4cd8a-223c-4ffb-b71a-7193392a9080");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "35e29199-2da9-45dd-97c6-0793c58fb624", null, "employee", "EMPLOYEE" },
                    { "3b63d87e-8618-480d-8d63-f9e905baa9e7", null, "manager", "MANAGER" },
                    { "8292e75f-f396-437e-9042-2ef1c9bbc742", null, "user", "USER" }
                });
        }
    }
}
