using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class NewServer2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c6132974-dd5d-4e50-8cde-7d33dd6ac848");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d1017906-bb62-4e98-b468-0fe63a472a9e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e77a6fa0-be38-4977-867b-98805580a00a");

            migrationBuilder.AlterColumn<string>(
                name: "WorkingTime",
                table: "Centers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "[\"monday - friday   , 08:00 am - 10:00 pm \",\"saturday - sunday   , 08:00 am - 10:00 pm \"]");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "29342c80-a622-48c3-a8db-e89f0aa00668", null, "user", "USER" },
                    { "d392f96e-2f30-45aa-8708-ae6228b23f6e", null, "employee", "EMPLOYEE" },
                    { "d6b44ae2-00c2-4694-a79a-0c890b8f6a50", null, "manager", "MANAGER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29342c80-a622-48c3-a8db-e89f0aa00668");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d392f96e-2f30-45aa-8708-ae6228b23f6e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d6b44ae2-00c2-4694-a79a-0c890b8f6a50");

            migrationBuilder.AlterColumn<string>(
                name: "WorkingTime",
                table: "Centers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[\"monday - friday   , 08:00 am - 10:00 pm \",\"saturday - sunday   , 08:00 am - 10:00 pm \"]",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c6132974-dd5d-4e50-8cde-7d33dd6ac848", null, "manager", "MANAGER" },
                    { "d1017906-bb62-4e98-b468-0fe63a472a9e", null, "user", "USER" },
                    { "e77a6fa0-be38-4977-867b-98805580a00a", null, "employee", "EMPLOYEE" }
                });
        }
    }
}
