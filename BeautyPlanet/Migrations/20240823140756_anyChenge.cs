using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class anyChenge : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "17efe2a9-f7cd-4453-b2fb-9daaaa62a60a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b8fc781-691d-4b33-b189-c0192b248c0d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cd0ceb95-c251-4815-9b1c-f42595a48cb6");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a8cabf71-40d4-4156-9494-e9c2f2f3cfa4", null, "user", "USER" },
                    { "aea74d8f-96c0-415e-a007-077be08532ae", null, "employee", "EMPLOYEE" },
                    { "ea8a27b4-7baa-41cc-a778-1c3023b4c25e", null, "manager", "MANAGER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a8cabf71-40d4-4156-9494-e9c2f2f3cfa4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aea74d8f-96c0-415e-a007-077be08532ae");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ea8a27b4-7baa-41cc-a778-1c3023b4c25e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "17efe2a9-f7cd-4453-b2fb-9daaaa62a60a", null, "employee", "EMPLOYEE" },
                    { "1b8fc781-691d-4b33-b189-c0192b248c0d", null, "user", "USER" },
                    { "cd0ceb95-c251-4815-9b1c-f42595a48cb6", null, "manager", "MANAGER" }
                });
        }
    }
}
