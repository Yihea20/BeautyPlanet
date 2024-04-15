using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class DateTimeAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "64563776-7312-4276-ab91-304247c05f07");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b327e9a0-42bc-4520-9fb5-ed950e6538aa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b8b9a81e-d0fa-4da2-83ce-18da61a396db");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTime",
                table: "Appointments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "17c413c5-e824-4581-aa3f-3102c3a94d27", null, "user", "USER" },
                    { "b6db462b-d683-4a61-9f16-1ce43737a5a9", null, "employee", "EMPLOYEE" },
                    { "d39e094f-85ca-47d0-a63f-23bb6fc2db73", null, "manager", "MANAGER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "17c413c5-e824-4581-aa3f-3102c3a94d27");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b6db462b-d683-4a61-9f16-1ce43737a5a9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d39e094f-85ca-47d0-a63f-23bb6fc2db73");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTime",
                table: "Appointments",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "64563776-7312-4276-ab91-304247c05f07", null, "user", "USER" },
                    { "b327e9a0-42bc-4520-9fb5-ed950e6538aa", null, "manager", "MANAGER" },
                    { "b8b9a81e-d0fa-4da2-83ce-18da61a396db", null, "employee", "EMPLOYEE" }
                });
        }
    }
}
