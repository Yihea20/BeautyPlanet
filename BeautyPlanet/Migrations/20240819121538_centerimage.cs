using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class centerimage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "13c09f54-7adc-4702-92c1-ddb7ee00aa26", null, "manager", "MANAGER" },
                    { "3c7a5ab6-176d-4c18-bb31-4ee0b5c56878", null, "user", "USER" },
                    { "899c4124-a8dd-414c-9e15-8747a9900f0f", null, "employee", "EMPLOYEE" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "13c09f54-7adc-4702-92c1-ddb7ee00aa26");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3c7a5ab6-176d-4c18-bb31-4ee0b5c56878");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "899c4124-a8dd-414c-9e15-8747a9900f0f");

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
                    { "43e46913-daa5-4359-a036-cd262142eda7", null, "employee", "EMPLOYEE" },
                    { "a2c2c243-fe59-4ee5-92ac-74f7f28d971b", null, "manager", "MANAGER" },
                    { "fc6059ae-b410-4389-b4d0-cbfd78d6459b", null, "user", "USER" }
                });
        }
    }
}
