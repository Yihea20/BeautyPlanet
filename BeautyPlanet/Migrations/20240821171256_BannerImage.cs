using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class BannerImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "HomeImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeImages", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3039d7a8-bfb9-4559-85a5-1b1ee0b03631", null, "employee", "EMPLOYEE" },
                    { "3a574527-990d-424f-a746-da8c3c2a6dc0", null, "manager", "MANAGER" },
                    { "cd6b2fe5-fcb8-4e70-bb4c-aff0e78eef87", null, "user", "USER" }
                });

            migrationBuilder.InsertData(
                table: "HomeImages",
                columns: new[] { "Id", "ImageUrl" },
                values: new object[] { 1, "[]" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HomeImages");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3039d7a8-bfb9-4559-85a5-1b1ee0b03631");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3a574527-990d-424f-a746-da8c3c2a6dc0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cd6b2fe5-fcb8-4e70-bb4c-aff0e78eef87");

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
    }
}
