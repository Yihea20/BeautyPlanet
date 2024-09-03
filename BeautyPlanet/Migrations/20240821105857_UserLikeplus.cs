using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class UserLikeplus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1df713e7-f490-406e-bae1-49cabbc80360");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ddc3b676-c8de-450a-b59b-277efe9290cd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e5646499-e8f5-48e0-8ac1-461d6cbc5925");

            migrationBuilder.AlterColumn<int>(
                name: "Like",
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
                    { "33eb6cca-1ddf-4e17-a0f3-45ffa5fab6d2", null, "employee", "EMPLOYEE" },
                    { "5a0652cc-b5aa-49d1-8273-055e3b7aa753", null, "manager", "MANAGER" },
                    { "abfe12ec-e4bb-415a-b8f3-a153f251b57a", null, "user", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "Like",
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
                    { "1df713e7-f490-406e-bae1-49cabbc80360", null, "user", "USER" },
                    { "ddc3b676-c8de-450a-b59b-277efe9290cd", null, "manager", "MANAGER" },
                    { "e5646499-e8f5-48e0-8ac1-461d6cbc5925", null, "employee", "EMPLOYEE" }
                });
        }
    }
}
