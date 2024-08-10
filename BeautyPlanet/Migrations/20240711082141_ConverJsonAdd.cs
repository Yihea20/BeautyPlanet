using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class ConverJsonAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "4e01f052-f0bc-402e-a185-a232e020a5f8", null, "employee", "EMPLOYEE" },
                    { "a676da4d-5fa5-4640-8232-39e8bbd68cd7", null, "user", "USER" },
                    { "b8d1e998-235d-4f60-8ce1-bfca5aa8d8ed", null, "manager", "MANAGER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4e01f052-f0bc-402e-a185-a232e020a5f8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a676da4d-5fa5-4640-8232-39e8bbd68cd7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b8d1e998-235d-4f60-8ce1-bfca5aa8d8ed");

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
    }
}
