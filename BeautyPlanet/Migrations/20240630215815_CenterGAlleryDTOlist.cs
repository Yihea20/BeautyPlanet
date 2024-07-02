using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class CenterGAlleryDTOlist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6536e6f6-7e27-4fba-baf4-cc1a26e7fedb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8174159e-47c1-4cf0-8c34-ebd20feb70f0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f6abb440-0fa2-4776-8a8c-e42c7ff24682");

            migrationBuilder.AlterColumn<string>(
                name: "GalleryImage",
                table: "Centers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "31eb80b5-9644-45a5-a0c2-2683c90a3a82", null, "employee", "EMPLOYEE" },
                    { "7544ecbd-77bb-4653-b709-23a8687b3661", null, "manager", "MANAGER" },
                    { "9bed8597-bff4-4e94-ac90-9b9b13f53747", null, "user", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "31eb80b5-9644-45a5-a0c2-2683c90a3a82");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7544ecbd-77bb-4653-b709-23a8687b3661");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9bed8597-bff4-4e94-ac90-9b9b13f53747");

            migrationBuilder.AlterColumn<string>(
                name: "GalleryImage",
                table: "Centers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6536e6f6-7e27-4fba-baf4-cc1a26e7fedb", null, "manager", "MANAGER" },
                    { "8174159e-47c1-4cf0-8c34-ebd20feb70f0", null, "employee", "EMPLOYEE" },
                    { "f6abb440-0fa2-4776-8a8c-e42c7ff24682", null, "user", "USER" }
                });
        }
    }
}
