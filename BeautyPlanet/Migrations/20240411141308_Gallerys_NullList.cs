using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class Gallerys_NullList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2b20c4bc-c146-47cd-93d7-1fd7e14a916a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44c552ba-13eb-4cbf-b72f-da23ffca5c27");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "460d542a-a18b-4feb-89d6-0651bcbd551e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9c3fece0-b7b8-4cdf-bad4-feb81cad1973", null, "manager", "MANAGER" },
                    { "af31ae71-bf87-440e-80b4-d2d1e2735f33", null, "user", "USER" },
                    { "d102928d-6203-4ba8-9c02-eae24cf0974e", null, "employee", "EMPLOYEE" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9c3fece0-b7b8-4cdf-bad4-feb81cad1973");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "af31ae71-bf87-440e-80b4-d2d1e2735f33");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d102928d-6203-4ba8-9c02-eae24cf0974e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2b20c4bc-c146-47cd-93d7-1fd7e14a916a", null, "user", "USER" },
                    { "44c552ba-13eb-4cbf-b72f-da23ffca5c27", null, "manager", "MANAGER" },
                    { "460d542a-a18b-4feb-89d6-0651bcbd551e", null, "employee", "EMPLOYEE" }
                });
        }
    }
}
