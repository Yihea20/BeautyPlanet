using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class FromStringToTinme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3e059785-1712-499f-ab0f-fa00f4a76675");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5ef1de4e-81ce-4ae3-9778-91a57ed3128b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7468a87-e1a4-4eae-b527-1ecc4995aa16");

            migrationBuilder.DropColumn(
                name: "Times",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Specialists",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "Duration",
                table: "Services",
                type: "time",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "86294301-23e9-4cfe-94a2-0b62ed760c4a", null, "user", "USER" },
                    { "9710c22f-4eab-4523-b23a-b48bf63e71ce", null, "employee", "EMPLOYEE" },
                    { "dd330321-cb80-48d4-84b4-c8c7389d4210", null, "manager", "MANAGER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Specialists_CategoryId",
                table: "Specialists",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Specialists_Categories_CategoryId",
                table: "Specialists",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Specialists_Categories_CategoryId",
                table: "Specialists");

            migrationBuilder.DropIndex(
                name: "IX_Specialists_CategoryId",
                table: "Specialists");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "86294301-23e9-4cfe-94a2-0b62ed760c4a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9710c22f-4eab-4523-b23a-b48bf63e71ce");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dd330321-cb80-48d4-84b4-c8c7389d4210");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Specialists");

            migrationBuilder.AddColumn<string>(
                name: "Times",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Duration",
                table: "Services",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3e059785-1712-499f-ab0f-fa00f4a76675", null, "user", "USER" },
                    { "5ef1de4e-81ce-4ae3-9778-91a57ed3128b", null, "employee", "EMPLOYEE" },
                    { "b7468a87-e1a4-4eae-b527-1ecc4995aa16", null, "manager", "MANAGER" }
                });
        }
    }
}
