using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class Revew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4cbd9945-8f51-4de9-a94d-c968dae26d28");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7dce02d3-a0f2-4d5e-89ac-b199c72b1eb8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b0fa447b-5892-49b5-bb0a-aa206bde8911");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "23d0533e-f657-49c2-bb4a-f546b6bb465b", null, "employee", "EMPLOYEE" },
                    { "92d64613-21fb-402e-aaa3-ec3bcda83ec4", null, "manager", "MANAGER" },
                    { "a861e5a3-31f8-44c8-8a45-5c4aebf5b358", null, "user", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "S" },
                    { 2, "M" },
                    { 3, "L" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "23d0533e-f657-49c2-bb4a-f546b6bb465b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "92d64613-21fb-402e-aaa3-ec3bcda83ec4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a861e5a3-31f8-44c8-8a45-5c4aebf5b358");

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4cbd9945-8f51-4de9-a94d-c968dae26d28", null, "user", "USER" },
                    { "7dce02d3-a0f2-4d5e-89ac-b199c72b1eb8", null, "employee", "EMPLOYEE" },
                    { "b0fa447b-5892-49b5-bb0a-aa206bde8911", null, "manager", "MANAGER" }
                });
        }
    }
}
