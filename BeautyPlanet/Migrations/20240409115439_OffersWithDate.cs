using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class OffersWithDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ed80048-d960-4f70-8f03-a23e07234dd9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e15d22ba-9b21-4902-a493-94dfbb275de9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ff359e4d-b8a0-4b97-a678-df6a8b654373");

            migrationBuilder.DropColumn(
                name: "ImageIcone",
                table: "Services");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "Offers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "37d655b5-92c2-4160-b659-5d8ef416f7da", null, "manager", "MANAGER" },
                    { "3f8e8c6b-3553-4f62-b366-8a15ca8a47a9", null, "employee", "EMPLOYEE" },
                    { "42c6e8db-d510-45a6-a0d0-a5f4e96563d4", null, "user", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "37d655b5-92c2-4160-b659-5d8ef416f7da");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3f8e8c6b-3553-4f62-b366-8a15ca8a47a9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "42c6e8db-d510-45a6-a0d0-a5f4e96563d4");

            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "Offers");

            migrationBuilder.AddColumn<string>(
                name: "ImageIcone",
                table: "Services",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6ed80048-d960-4f70-8f03-a23e07234dd9", null, "employee", "EMPLOYEE" },
                    { "e15d22ba-9b21-4902-a493-94dfbb275de9", null, "manager", "MANAGER" },
                    { "ff359e4d-b8a0-4b97-a678-df6a8b654373", null, "user", "USER" }
                });
        }
    }
}
