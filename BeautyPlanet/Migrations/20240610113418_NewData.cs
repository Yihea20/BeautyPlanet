using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class NewData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "31067028-a50d-4be7-9cfd-81a1276bf5f1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4b19d009-24d0-471b-a9db-318dafd87487");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d458a1a-66a0-48df-9859-3ca3c74fdff8");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1240d703-2454-4529-acfd-0bc262f4480e", null, "manager", "MANAGER" },
                    { "a38b1e21-c625-4766-b46a-19321c221902", null, "user", "USER" },
                    { "d295ab97-f49d-466d-bd1e-b91f524a4a73", null, "employee", "EMPLOYEE" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1240d703-2454-4529-acfd-0bc262f4480e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a38b1e21-c625-4766-b46a-19321c221902");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d295ab97-f49d-466d-bd1e-b91f524a4a73");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "31067028-a50d-4be7-9cfd-81a1276bf5f1", null, "manager", "MANAGER" },
                    { "4b19d009-24d0-471b-a9db-318dafd87487", null, "employee", "EMPLOYEE" },
                    { "4d458a1a-66a0-48df-9859-3ca3c74fdff8", null, "user", "USER" }
                });
        }
    }
}
