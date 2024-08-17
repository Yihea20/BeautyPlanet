using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class ProfileSp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b3210570-e0f4-4d44-8f19-f693b219576e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cabba29e-563b-4cd6-98f9-2e19d1d51c43");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fbcd9a08-b4a6-4715-9a7d-0a648aa7a4f2");

            migrationBuilder.AddColumn<int>(
                name: "AppointmentNumber",
                table: "Specialists",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PoastNumber",
                table: "Specialists",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "65d73d4e-c47f-47b1-9a6e-f59eb8aae75e", null, "manager", "MANAGER" },
                    { "7e57b492-a92f-4135-8c30-a72ace272619", null, "user", "USER" },
                    { "91a1a93e-f8b1-419b-83f8-e62af2333476", null, "employee", "EMPLOYEE" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65d73d4e-c47f-47b1-9a6e-f59eb8aae75e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7e57b492-a92f-4135-8c30-a72ace272619");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "91a1a93e-f8b1-419b-83f8-e62af2333476");

            migrationBuilder.DropColumn(
                name: "AppointmentNumber",
                table: "Specialists");

            migrationBuilder.DropColumn(
                name: "PoastNumber",
                table: "Specialists");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b3210570-e0f4-4d44-8f19-f693b219576e", null, "user", "USER" },
                    { "cabba29e-563b-4cd6-98f9-2e19d1d51c43", null, "employee", "EMPLOYEE" },
                    { "fbcd9a08-b4a6-4715-9a7d-0a648aa7a4f2", null, "manager", "MANAGER" }
                });
        }
    }
}
