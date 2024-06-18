using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class Notification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "32395dff-a12e-42b6-b86e-325d8a9c0480");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "88eb0256-05ac-4403-9d9e-b299bedbd50e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c5acc9a4-c4a7-408d-9a64-602172103de2");

            migrationBuilder.AddColumn<string>(
                name: "DeviceTokken",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DeviceTokken",
                table: "Specialists",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DeviceTokken",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DeviceTokken",
                table: "Admins",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "DeviceTokken",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DeviceTokken",
                table: "Specialists");

            migrationBuilder.DropColumn(
                name: "DeviceTokken",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DeviceTokken",
                table: "Admins");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "32395dff-a12e-42b6-b86e-325d8a9c0480", null, "manager", "MANAGER" },
                    { "88eb0256-05ac-4403-9d9e-b299bedbd50e", null, "user", "USER" },
                    { "c5acc9a4-c4a7-408d-9a64-602172103de2", null, "employee", "EMPLOYEE" }
                });
        }
    }
}
