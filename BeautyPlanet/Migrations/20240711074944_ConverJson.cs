using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class ConverJson : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4dd74fbf-dbf0-4b03-9d94-90a9eb39ec6a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6a8ccca5-3ea0-4e37-9fec-adecf06ed856");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a0c2d968-f244-489c-88a7-2ea1b2118b68");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6d230334-5904-44da-970e-70870921c8c5", null, "user", "USER" },
                    { "79d78396-fd5b-43f1-a85d-365e4f16360d", null, "manager", "MANAGER" },
                    { "df35cd1e-42ed-4669-8011-6f4d812e5ee3", null, "employee", "EMPLOYEE" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6d230334-5904-44da-970e-70870921c8c5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "79d78396-fd5b-43f1-a85d-365e4f16360d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df35cd1e-42ed-4669-8011-6f4d812e5ee3");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4dd74fbf-dbf0-4b03-9d94-90a9eb39ec6a", null, "user", "USER" },
                    { "6a8ccca5-3ea0-4e37-9fec-adecf06ed856", null, "manager", "MANAGER" },
                    { "a0c2d968-f244-489c-88a7-2ea1b2118b68", null, "employee", "EMPLOYEE" }
                });
        }
    }
}
