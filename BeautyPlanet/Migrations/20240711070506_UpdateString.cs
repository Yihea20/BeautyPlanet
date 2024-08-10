using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class UpdateString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "19e1df11-ae52-47fc-82b6-c569778dccf5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "763f8a2c-22f3-43c5-a02a-78387e1a7ece");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f0a21e99-a116-4eaa-81b9-fad83cc6d1b9");

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
                    { "4dd74fbf-dbf0-4b03-9d94-90a9eb39ec6a", null, "user", "USER" },
                    { "6a8ccca5-3ea0-4e37-9fec-adecf06ed856", null, "manager", "MANAGER" },
                    { "a0c2d968-f244-489c-88a7-2ea1b2118b68", null, "employee", "EMPLOYEE" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4dd74fbf-dbf0-4b03-9d94-90a9eb39ec6a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6a8ccca5-3ea0-4e37-9fec-adecf06ed856");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a0c2d968-f244-489c-88a7-2ea1b2118b68");

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
                    { "19e1df11-ae52-47fc-82b6-c569778dccf5", null, "employee", "EMPLOYEE" },
                    { "763f8a2c-22f3-43c5-a02a-78387e1a7ece", null, "manager", "MANAGER" },
                    { "f0a21e99-a116-4eaa-81b9-fad83cc6d1b9", null, "user", "USER" }
                });
        }
    }
}
