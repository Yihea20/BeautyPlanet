using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class spLike : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "563d9858-6492-4f3a-96e3-c2cd1c55a5dd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "90b622a6-4af1-4b19-b781-8bb7f80314a4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dd616dc2-90b5-4258-8cc2-eb6fa25c0e0c");

            migrationBuilder.AddColumn<int>(
                name: "Like",
                table: "Specialists",
                type: "int",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Like",
                table: "Specialists");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "563d9858-6492-4f3a-96e3-c2cd1c55a5dd", null, "user", "USER" },
                    { "90b622a6-4af1-4b19-b781-8bb7f80314a4", null, "manager", "MANAGER" },
                    { "dd616dc2-90b5-4258-8cc2-eb6fa25c0e0c", null, "employee", "EMPLOYEE" }
                });
        }
    }
}
