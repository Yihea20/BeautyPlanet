using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class BandUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<bool>(
                name: "Ban",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "CancelDate",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "43e46913-daa5-4359-a036-cd262142eda7", null, "employee", "EMPLOYEE" },
                    { "a2c2c243-fe59-4ee5-92ac-74f7f28d971b", null, "manager", "MANAGER" },
                    { "fc6059ae-b410-4389-b4d0-cbfd78d6459b", null, "user", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "43e46913-daa5-4359-a036-cd262142eda7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a2c2c243-fe59-4ee5-92ac-74f7f28d971b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fc6059ae-b410-4389-b4d0-cbfd78d6459b");

            migrationBuilder.DropColumn(
                name: "Ban",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CancelDate",
                table: "Users");

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
    }
}
