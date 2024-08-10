using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class spAppointemnt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2af785ce-8d4a-488e-9efb-a509595d45e1", null, "user", "USER" },
                    { "310957d2-14ae-4433-b9e1-50d09126d33a", null, "manager", "MANAGER" },
                    { "b781ae75-cb52-4790-bc5a-9c22c737cfb9", null, "employee", "EMPLOYEE" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2af785ce-8d4a-488e-9efb-a509595d45e1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "310957d2-14ae-4433-b9e1-50d09126d33a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b781ae75-cb52-4790-bc5a-9c22c737cfb9");

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
    }
}
