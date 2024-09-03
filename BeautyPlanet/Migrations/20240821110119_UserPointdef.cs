using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class UserPointdef : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "33eb6cca-1ddf-4e17-a0f3-45ffa5fab6d2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5a0652cc-b5aa-49d1-8273-055e3b7aa753");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "abfe12ec-e4bb-415a-b8f3-a153f251b57a");

            migrationBuilder.AlterColumn<int>(
                name: "Point",
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
                    { "445bcfdb-b0c2-4912-a34e-9f45ab9d63da", null, "manager", "MANAGER" },
                    { "63974db0-29fb-476d-933e-84b1bc0b140a", null, "user", "USER" },
                    { "7e27dd1b-c66b-4ba9-b73b-26b7aa5fd83e", null, "employee", "EMPLOYEE" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "445bcfdb-b0c2-4912-a34e-9f45ab9d63da");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "63974db0-29fb-476d-933e-84b1bc0b140a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7e27dd1b-c66b-4ba9-b73b-26b7aa5fd83e");

            migrationBuilder.AlterColumn<int>(
                name: "Point",
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
                    { "33eb6cca-1ddf-4e17-a0f3-45ffa5fab6d2", null, "employee", "EMPLOYEE" },
                    { "5a0652cc-b5aa-49d1-8273-055e3b7aa753", null, "manager", "MANAGER" },
                    { "abfe12ec-e4bb-415a-b8f3-a153f251b57a", null, "user", "USER" }
                });
        }
    }
}
