using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class ShoppingCartAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5436fb27-cf9a-46da-9b62-264d2b1983b9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9efe0f00-6f14-46fb-935a-23ea9adf3bed");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f43fe8fd-147e-482b-8153-f4069ccfaf9b");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "5436fb27-cf9a-46da-9b62-264d2b1983b9", null, "manager", "MANAGER" },
                    { "9efe0f00-6f14-46fb-935a-23ea9adf3bed", null, "employee", "EMPLOYEE" },
                    { "f43fe8fd-147e-482b-8153-f4069ccfaf9b", null, "user", "USER" }
                });
        }
    }
}
