using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class NotificationDispla : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "416a2885-1b1d-4aa4-8643-2b87f879015f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "69b8e98b-413e-48ca-8824-383ecd3681b8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fe2d2918-dd14-4434-8ce3-be816ef91f3e");

            migrationBuilder.AddColumn<string>(
                name: "CenterImage",
                table: "Notifications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CenterName",
                table: "Notifications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "588850e3-696b-4509-9924-263ed3a5f50d", null, "employee", "EMPLOYEE" },
                    { "8830c0bd-650c-4ac6-9acc-132cfe601a9e", null, "user", "USER" },
                    { "e5d2fb10-cc79-44e5-919b-5213af28cb3d", null, "manager", "MANAGER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "588850e3-696b-4509-9924-263ed3a5f50d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8830c0bd-650c-4ac6-9acc-132cfe601a9e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e5d2fb10-cc79-44e5-919b-5213af28cb3d");

            migrationBuilder.DropColumn(
                name: "CenterImage",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "CenterName",
                table: "Notifications");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "416a2885-1b1d-4aa4-8643-2b87f879015f", null, "manager", "MANAGER" },
                    { "69b8e98b-413e-48ca-8824-383ecd3681b8", null, "user", "USER" },
                    { "fe2d2918-dd14-4434-8ce3-be816ef91f3e", null, "employee", "EMPLOYEE" }
                });
        }
    }
}
