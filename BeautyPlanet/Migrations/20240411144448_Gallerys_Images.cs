using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class Gallerys_Images : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9c3fece0-b7b8-4cdf-bad4-feb81cad1973");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "af31ae71-bf87-440e-80b4-d2d1e2735f33");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d102928d-6203-4ba8-9c02-eae24cf0974e");

            migrationBuilder.DropColumn(
                name: "ImagesUrl",
                table: "Galleries");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "079b1631-d72c-4a25-907c-a4cf3a3d02ac", null, "user", "USER" },
                    { "235902b5-ec7c-4ab9-b6f7-d67dcf2c2b70", null, "manager", "MANAGER" },
                    { "a9863912-d67d-48d4-a115-70420775cd28", null, "employee", "EMPLOYEE" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "079b1631-d72c-4a25-907c-a4cf3a3d02ac");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "235902b5-ec7c-4ab9-b6f7-d67dcf2c2b70");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a9863912-d67d-48d4-a115-70420775cd28");

            migrationBuilder.AddColumn<string>(
                name: "ImagesUrl",
                table: "Galleries",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9c3fece0-b7b8-4cdf-bad4-feb81cad1973", null, "manager", "MANAGER" },
                    { "af31ae71-bf87-440e-80b4-d2d1e2735f33", null, "user", "USER" },
                    { "d102928d-6203-4ba8-9c02-eae24cf0974e", null, "employee", "EMPLOYEE" }
                });
        }
    }
}
