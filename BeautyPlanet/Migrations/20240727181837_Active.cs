using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class Active : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "910f50c7-af03-4956-b984-bc70f1635f40");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b3ed25c9-9596-48ca-ac0c-e7945c851130");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e05e70ac-39dd-4179-ae38-5724b8584106");

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Centers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1e749a78-440e-4df7-aa0e-f419fdba6260", null, "manager", "MANAGER" },
                    { "83580047-9fff-4256-9f2e-faf58dba4f0a", null, "employee", "EMPLOYEE" },
                    { "d6cf9674-5f92-499c-9d04-fc94a9453d9c", null, "user", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1e749a78-440e-4df7-aa0e-f419fdba6260");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "83580047-9fff-4256-9f2e-faf58dba4f0a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d6cf9674-5f92-499c-9d04-fc94a9453d9c");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Centers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "910f50c7-af03-4956-b984-bc70f1635f40", null, "employee", "EMPLOYEE" },
                    { "b3ed25c9-9596-48ca-ac0c-e7945c851130", null, "manager", "MANAGER" },
                    { "e05e70ac-39dd-4179-ae38-5724b8584106", null, "user", "USER" }
                });
        }
    }
}
