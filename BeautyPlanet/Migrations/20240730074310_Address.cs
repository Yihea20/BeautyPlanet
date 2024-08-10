using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class Address : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5661af52-59bc-4826-b788-18b87be38824");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "69b7f235-4753-4426-a983-9d61ce77db3d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "851c73cc-36a0-48a0-8114-14918b757ab1");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "241fd1f3-768f-41c9-a0f7-022d833e93a1", null, "employee", "EMPLOYEE" },
                    { "ae7e3adb-023f-45a6-b08e-abe4384e2455", null, "user", "USER" },
                    { "ceb4a06a-5145-45c6-a5d9-740470815bae", null, "manager", "MANAGER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "241fd1f3-768f-41c9-a0f7-022d833e93a1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ae7e3adb-023f-45a6-b08e-abe4384e2455");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ceb4a06a-5145-45c6-a5d9-740470815bae");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Users");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5661af52-59bc-4826-b788-18b87be38824", null, "employee", "EMPLOYEE" },
                    { "69b7f235-4753-4426-a983-9d61ce77db3d", null, "user", "USER" },
                    { "851c73cc-36a0-48a0-8114-14918b757ab1", null, "manager", "MANAGER" }
                });
        }
    }
}
