using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class ServicePoint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3039d7a8-bfb9-4559-85a5-1b1ee0b03631");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3a574527-990d-424f-a746-da8c3c2a6dc0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cd6b2fe5-fcb8-4e70-bb4c-aff0e78eef87");

            migrationBuilder.AddColumn<int>(
                name: "Point",
                table: "Services",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1774e183-746a-4d91-9cf8-ac1aab86a8cb", null, "employee", "EMPLOYEE" },
                    { "3c48bb6e-612b-4b24-9e64-2d18ac85addb", null, "user", "USER" },
                    { "ab029d9d-6204-4d74-a93b-19d7adef5ea3", null, "manager", "MANAGER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1774e183-746a-4d91-9cf8-ac1aab86a8cb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3c48bb6e-612b-4b24-9e64-2d18ac85addb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ab029d9d-6204-4d74-a93b-19d7adef5ea3");

            migrationBuilder.DropColumn(
                name: "Point",
                table: "Services");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3039d7a8-bfb9-4559-85a5-1b1ee0b03631", null, "employee", "EMPLOYEE" },
                    { "3a574527-990d-424f-a746-da8c3c2a6dc0", null, "manager", "MANAGER" },
                    { "cd6b2fe5-fcb8-4e70-bb4c-aff0e78eef87", null, "user", "USER" }
                });
        }
    }
}
