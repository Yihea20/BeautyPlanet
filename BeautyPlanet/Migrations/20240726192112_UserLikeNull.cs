using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class UserLikeNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d46eac6f-a08f-4ec9-b843-d41e6d94d7db");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ea878c20-3c5c-4d96-afa6-a8f639d5442a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f5623751-0cb9-4972-802f-72eb4e80b3cc");

            migrationBuilder.AlterColumn<int>(
                name: "Like",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9bae86e3-edfb-4868-a34d-253aa36aa52d", null, "employee", "EMPLOYEE" },
                    { "9c1564ad-f406-410a-8efb-9a117feef3e4", null, "manager", "MANAGER" },
                    { "ba7055fb-c64b-4c8a-9b73-3da4c284a8c1", null, "user", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9bae86e3-edfb-4868-a34d-253aa36aa52d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9c1564ad-f406-410a-8efb-9a117feef3e4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ba7055fb-c64b-4c8a-9b73-3da4c284a8c1");

            migrationBuilder.AlterColumn<int>(
                name: "Like",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "d46eac6f-a08f-4ec9-b843-d41e6d94d7db", null, "manager", "MANAGER" },
                    { "ea878c20-3c5c-4d96-afa6-a8f639d5442a", null, "employee", "EMPLOYEE" },
                    { "f5623751-0cb9-4972-802f-72eb4e80b3cc", null, "user", "USER" }
                });
        }
    }
}
