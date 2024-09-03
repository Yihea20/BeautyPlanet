using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class ShoppingCartAddToStore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "78390629-6ad9-4cd2-90c9-6c693a7fee79");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a10e500f-ba16-4df9-a5f7-6fb448db5c76");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d4a02924-2a79-4b59-be40-a3c116deb1d2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4668719d-999d-4e7e-8426-23db16072f02", null, "manager", "MANAGER" },
                    { "78c4c684-83fe-4ebf-8974-e6b2d0f5cef7", null, "user", "USER" },
                    { "d90a3359-8cc9-4642-a137-15c8a3f371ce", null, "employee", "EMPLOYEE" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4668719d-999d-4e7e-8426-23db16072f02");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "78c4c684-83fe-4ebf-8974-e6b2d0f5cef7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d90a3359-8cc9-4642-a137-15c8a3f371ce");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "78390629-6ad9-4cd2-90c9-6c693a7fee79", null, "employee", "EMPLOYEE" },
                    { "a10e500f-ba16-4df9-a5f7-6fb448db5c76", null, "manager", "MANAGER" },
                    { "d4a02924-2a79-4b59-be40-a3c116deb1d2", null, "user", "USER" }
                });
        }
    }
}
