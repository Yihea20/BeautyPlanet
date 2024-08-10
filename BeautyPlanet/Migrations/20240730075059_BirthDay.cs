using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class BirthDay : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "241fd1f3-768f-41c9-a0f7-022d833e93a1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ae7e3adb-023f-45a6-b08e-abe4384e2455");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ceb4a06a-5145-45c6-a5d9-740470815bae");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "Users");

            migrationBuilder.AddColumn<DateTime>(
                name: "Birthday",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0e0aa0c9-8f91-48e4-8242-ab0a022cf966", null, "employee", "EMPLOYEE" },
                    { "4c521e4d-eb74-48b7-a759-7b1285560ae6", null, "manager", "MANAGER" },
                    { "f85ec3bd-cad2-4e5d-b5d2-13d07f57e4ce", null, "user", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0e0aa0c9-8f91-48e4-8242-ab0a022cf966");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4c521e4d-eb74-48b7-a759-7b1285560ae6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f85ec3bd-cad2-4e5d-b5d2-13d07f57e4ce");

            migrationBuilder.DropColumn(
                name: "Birthday",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "241fd1f3-768f-41c9-a0f7-022d833e93a1", null, "employee", "EMPLOYEE" },
                    { "ae7e3adb-023f-45a6-b08e-abe4384e2455", null, "user", "USER" },
                    { "ceb4a06a-5145-45c6-a5d9-740470815bae", null, "manager", "MANAGER" }
                });
        }
    }
}
