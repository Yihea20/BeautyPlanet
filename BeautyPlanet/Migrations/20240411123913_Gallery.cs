using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class Gallery : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7ab18690-88e8-49e5-b255-a7bc69fc99e8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d9a60024-70d8-49d6-b9be-e94f834eb2b5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db65bef2-07fa-4e8a-8168-a1e3ca2fbb26");

            migrationBuilder.AddColumn<string>(
                name: "GallaryName",
                table: "Galleries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImagesUrl",
                table: "Galleries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3eaa3406-b344-4ff4-8473-468fbd9ba7d9", null, "user", "USER" },
                    { "94035e43-22ed-4d98-8dd9-79c0714e8d39", null, "manager", "MANAGER" },
                    { "fd39126a-5f10-4248-8f63-584d86ee4b29", null, "employee", "EMPLOYEE" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3eaa3406-b344-4ff4-8473-468fbd9ba7d9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94035e43-22ed-4d98-8dd9-79c0714e8d39");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fd39126a-5f10-4248-8f63-584d86ee4b29");

            migrationBuilder.DropColumn(
                name: "GallaryName",
                table: "Galleries");

            migrationBuilder.DropColumn(
                name: "ImagesUrl",
                table: "Galleries");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7ab18690-88e8-49e5-b255-a7bc69fc99e8", null, "employee", "EMPLOYEE" },
                    { "d9a60024-70d8-49d6-b9be-e94f834eb2b5", null, "manager", "MANAGER" },
                    { "db65bef2-07fa-4e8a-8168-a1e3ca2fbb26", null, "user", "USER" }
                });
        }
    }
}
