using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class NotificationDisplay : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Services_ServiceId",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_ServiceId",
                table: "Notifications");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a8cabf71-40d4-4156-9494-e9c2f2f3cfa4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aea74d8f-96c0-415e-a007-077be08532ae");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ea8a27b4-7baa-41cc-a778-1c3023b4c25e");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "Notifications");

            migrationBuilder.AlterColumn<string>(
                name: "DeviceToken",
                table: "Notifications",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "416a2885-1b1d-4aa4-8643-2b87f879015f", null, "manager", "MANAGER" },
                    { "69b8e98b-413e-48ca-8824-383ecd3681b8", null, "user", "USER" },
                    { "fe2d2918-dd14-4434-8ce3-be816ef91f3e", null, "employee", "EMPLOYEE" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_DeviceToken",
                table: "Notifications",
                column: "DeviceToken");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Notifications_DeviceToken",
                table: "Notifications");

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

            migrationBuilder.AlterColumn<string>(
                name: "DeviceToken",
                table: "Notifications",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ServiceId",
                table: "Notifications",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a8cabf71-40d4-4156-9494-e9c2f2f3cfa4", null, "user", "USER" },
                    { "aea74d8f-96c0-415e-a007-077be08532ae", null, "employee", "EMPLOYEE" },
                    { "ea8a27b4-7baa-41cc-a778-1c3023b4c25e", null, "manager", "MANAGER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_ServiceId",
                table: "Notifications",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Services_ServiceId",
                table: "Notifications",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id");
        }
    }
}
