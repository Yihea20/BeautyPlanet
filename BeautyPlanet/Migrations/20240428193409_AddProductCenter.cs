using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class AddProductCenter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a35a2fb-6321-4d30-8eb2-5733d5bb6cb7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b3a7b6e5-0507-4769-a114-f016fa7a16b4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fc14d910-6754-4f2a-b712-fd5ff0d6973f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0a628bdf-699a-49d8-9485-f255cb334755", null, "employee", "EMPLOYEE" },
                    { "1bffd8d6-7893-4aff-802b-e353ba9c101d", null, "user", "USER" },
                    { "c4a23874-b1f6-42e1-9446-b5da739d809b", null, "manager", "MANAGER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0a628bdf-699a-49d8-9485-f255cb334755");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1bffd8d6-7893-4aff-802b-e353ba9c101d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c4a23874-b1f6-42e1-9446-b5da739d809b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9a35a2fb-6321-4d30-8eb2-5733d5bb6cb7", null, "employee", "EMPLOYEE" },
                    { "b3a7b6e5-0507-4769-a114-f016fa7a16b4", null, "user", "USER" },
                    { "fc14d910-6754-4f2a-b712-fd5ff0d6973f", null, "manager", "MANAGER" }
                });
        }
    }
}
