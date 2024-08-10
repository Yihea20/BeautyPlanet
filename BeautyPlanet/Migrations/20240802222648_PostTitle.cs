using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class PostTitle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "27648c8d-e54e-4e82-976b-632f9f107d8a", null, "manager", "MANAGER" },
                    { "6ccb8938-15a0-4f0a-b5a1-4dcac1394c8c", null, "employee", "EMPLOYEE" },
                    { "c9ae50a5-c709-4072-be87-4eb0881dc9cd", null, "user", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27648c8d-e54e-4e82-976b-632f9f107d8a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ccb8938-15a0-4f0a-b5a1-4dcac1394c8c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c9ae50a5-c709-4072-be87-4eb0881dc9cd");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Posts");

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
    }
}
