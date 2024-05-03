using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class AddProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "41e2d776-b657-40d5-a075-6ffe8467814a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d1a1cad-768f-4c30-8a40-0e2671b665ce");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5dc2e9c9-a432-49c4-b77f-096a1668dcce");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "14ce0ab0-87c0-4316-bfe9-709897f2b3d0", null, "manager", "MANAGER" },
                    { "457f8522-5e0a-41d8-868b-8f5947202934", null, "employee", "EMPLOYEE" },
                    { "7d247b05-42f4-41fc-87ca-b33b946bcec1", null, "user", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "14ce0ab0-87c0-4316-bfe9-709897f2b3d0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "457f8522-5e0a-41d8-868b-8f5947202934");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7d247b05-42f4-41fc-87ca-b33b946bcec1");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "41e2d776-b657-40d5-a075-6ffe8467814a", null, "user", "USER" },
                    { "5d1a1cad-768f-4c30-8a40-0e2671b665ce", null, "employee", "EMPLOYEE" },
                    { "5dc2e9c9-a432-49c4-b77f-096a1668dcce", null, "manager", "MANAGER" }
                });
        }
    }
}
