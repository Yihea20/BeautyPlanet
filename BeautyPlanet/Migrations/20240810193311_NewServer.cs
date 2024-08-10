using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class NewServer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "731babf8-9c40-449e-a7a7-c801579bc659");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ac55540e-24d0-4910-a7ce-54aa442a593c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c12b5373-826f-426c-8fd8-76f5d0854eed");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c6132974-dd5d-4e50-8cde-7d33dd6ac848", null, "manager", "MANAGER" },
                    { "d1017906-bb62-4e98-b468-0fe63a472a9e", null, "user", "USER" },
                    { "e77a6fa0-be38-4977-867b-98805580a00a", null, "employee", "EMPLOYEE" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c6132974-dd5d-4e50-8cde-7d33dd6ac848");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d1017906-bb62-4e98-b468-0fe63a472a9e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e77a6fa0-be38-4977-867b-98805580a00a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "731babf8-9c40-449e-a7a7-c801579bc659", null, "user", "USER" },
                    { "ac55540e-24d0-4910-a7ce-54aa442a593c", null, "employee", "EMPLOYEE" },
                    { "c12b5373-826f-426c-8fd8-76f5d0854eed", null, "manager", "MANAGER" }
                });
        }
    }
}
