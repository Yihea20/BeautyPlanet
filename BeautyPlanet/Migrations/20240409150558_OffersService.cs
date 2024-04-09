using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class OffersService : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "37d655b5-92c2-4160-b659-5d8ef416f7da");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3f8e8c6b-3553-4f62-b366-8a15ca8a47a9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "42c6e8db-d510-45a6-a0d0-a5f4e96563d4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0f60cf6a-0a3e-47af-be36-eb3c352d5ba5", null, "manager", "MANAGER" },
                    { "bac568cc-f840-417e-b2ca-54b146d5f273", null, "employee", "EMPLOYEE" },
                    { "e654d871-28d4-4eaf-b45c-fa98fa2a26ab", null, "user", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f60cf6a-0a3e-47af-be36-eb3c352d5ba5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bac568cc-f840-417e-b2ca-54b146d5f273");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e654d871-28d4-4eaf-b45c-fa98fa2a26ab");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "37d655b5-92c2-4160-b659-5d8ef416f7da", null, "manager", "MANAGER" },
                    { "3f8e8c6b-3553-4f62-b366-8a15ca8a47a9", null, "employee", "EMPLOYEE" },
                    { "42c6e8db-d510-45a6-a0d0-a5f4e96563d4", null, "user", "USER" }
                });
        }
    }
}
