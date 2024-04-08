using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class People : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1bdcab70-5df8-4140-8297-6ab7865c8c29");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2dbe6675-0848-4473-895b-1fbe1386b749");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ec70107c-f946-4786-98a6-b5c319cc3edc");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4d2f4ae7-e927-449a-93d2-a0f488c15959", null, "user", "USER" },
                    { "ee4f7efc-1ffb-4452-ae51-8f20643ca405", null, "employee", "EMPLOYEE" },
                    { "f31a7251-d956-4bee-85da-e3014306dafb", null, "manager", "MANAGER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d2f4ae7-e927-449a-93d2-a0f488c15959");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ee4f7efc-1ffb-4452-ae51-8f20643ca405");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f31a7251-d956-4bee-85da-e3014306dafb");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1bdcab70-5df8-4140-8297-6ab7865c8c29", null, "employee", "EMPLOYEE" },
                    { "2dbe6675-0848-4473-895b-1fbe1386b749", null, "manager", "MANAGER" },
                    { "ec70107c-f946-4786-98a6-b5c319cc3edc", null, "user", "USER" }
                });
        }
    }
}
