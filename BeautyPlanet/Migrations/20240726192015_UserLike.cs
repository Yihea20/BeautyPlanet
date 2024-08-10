using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class UserLike : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "31001703-12c6-463c-b685-b3c1d1dfe716");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8bfac68b-5805-4ff8-9b46-cc8035b8ae32");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c9e0934f-fe31-4ac5-ae5d-08897cc72df3");

            migrationBuilder.AddColumn<int>(
                name: "Like",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Like",
                table: "Users");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "31001703-12c6-463c-b685-b3c1d1dfe716", null, "manager", "MANAGER" },
                    { "8bfac68b-5805-4ff8-9b46-cc8035b8ae32", null, "user", "USER" },
                    { "c9e0934f-fe31-4ac5-ae5d-08897cc72df3", null, "employee", "EMPLOYEE" }
                });
        }
    }
}
