using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class ProductListImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "548e134d-4d6e-4f8b-bd52-da27b0b6819f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94344c28-56c1-4df7-b24d-d0042166d9ae");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d68a6d57-2afe-4913-9615-7c874e46b717");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "548e134d-4d6e-4f8b-bd52-da27b0b6819f", null, "user", "USER" },
                    { "94344c28-56c1-4df7-b24d-d0042166d9ae", null, "manager", "MANAGER" },
                    { "d68a6d57-2afe-4913-9615-7c874e46b717", null, "employee", "EMPLOYEE" }
                });
        }
    }
}
