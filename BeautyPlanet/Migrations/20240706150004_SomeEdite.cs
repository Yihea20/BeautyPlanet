using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class SomeEdite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1204a3d6-52d8-4697-810c-3acfb5b39b0e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "28154184-8fdb-400a-94be-8bf197af661e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f05c02cc-57e9-4b99-8e37-be49522c84bf");

            migrationBuilder.DropColumn(
                name: "Times",
                table: "Specialists");

            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "Appointments",
                newName: "StartTime");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "Appointments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2c9935ca-f524-44bd-85a8-699cb1d63a1c", null, "employee", "EMPLOYEE" },
                    { "30cdbff7-60d7-4f78-92d5-8198576b9513", null, "manager", "MANAGER" },
                    { "3918a082-7990-4b4b-8fab-aebbf1702df9", null, "user", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c9935ca-f524-44bd-85a8-699cb1d63a1c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "30cdbff7-60d7-4f78-92d5-8198576b9513");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3918a082-7990-4b4b-8fab-aebbf1702df9");

            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "StartTime",
                table: "Appointments",
                newName: "DateTime");

            migrationBuilder.AddColumn<string>(
                name: "Times",
                table: "Specialists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1204a3d6-52d8-4697-810c-3acfb5b39b0e", null, "manager", "MANAGER" },
                    { "28154184-8fdb-400a-94be-8bf197af661e", null, "user", "USER" },
                    { "f05c02cc-57e9-4b99-8e37-be49522c84bf", null, "employee", "EMPLOYEE" }
                });
        }
    }
}
