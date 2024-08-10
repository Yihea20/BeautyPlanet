using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class CenterParsTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2af785ce-8d4a-488e-9efb-a509595d45e1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "310957d2-14ae-4433-b9e1-50d09126d33a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b781ae75-cb52-4790-bc5a-9c22c737cfb9");

            migrationBuilder.AddColumn<string>(
                name: "WorkingTime",
                table: "Centers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "WorkingTime",
                table: "Centers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2af785ce-8d4a-488e-9efb-a509595d45e1", null, "user", "USER" },
                    { "310957d2-14ae-4433-b9e1-50d09126d33a", null, "manager", "MANAGER" },
                    { "b781ae75-cb52-4790-bc5a-9c22c737cfb9", null, "employee", "EMPLOYEE" }
                });
        }
    }
}
