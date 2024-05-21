using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class Prodcountcenter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1122694c-9fd0-447e-98b9-e2e58f5bd54b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d5f2da2-b73b-4fbc-ac95-3ed24fb147fe");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df489810-7690-4018-b7f4-cbb63e8e1afa");

            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "ProductCenterColorSizes",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "086180c4-0338-44df-a7bb-d3ba06567ee9", null, "manager", "MANAGER" },
                    { "29412027-0c6f-497c-a6ab-41e4821bee76", null, "user", "USER" },
                    { "29b9d59a-536f-4a86-b359-e27fad3f24d6", null, "employee", "EMPLOYEE" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "086180c4-0338-44df-a7bb-d3ba06567ee9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29412027-0c6f-497c-a6ab-41e4821bee76");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29b9d59a-536f-4a86-b359-e27fad3f24d6");

            migrationBuilder.DropColumn(
                name: "Count",
                table: "ProductCenterColorSizes");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1122694c-9fd0-447e-98b9-e2e58f5bd54b", null, "manager", "MANAGER" },
                    { "3d5f2da2-b73b-4fbc-ac95-3ed24fb147fe", null, "user", "USER" },
                    { "df489810-7690-4018-b7f4-cbb63e8e1afa", null, "employee", "EMPLOYEE" }
                });
        }
    }
}
