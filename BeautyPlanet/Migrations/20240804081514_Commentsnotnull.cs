using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class Commentsnotnull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d51141a-8027-4ea9-a16b-ce7b28d2c923");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "66046aa3-afcf-496f-b14e-173c31a3330f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e066a236-7501-4b49-a7ad-54c8f013ea9f");

            migrationBuilder.AlterColumn<int>(
                name: "Like",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2483bb23-dde4-477e-9922-768f5f6353a9", null, "employee", "EMPLOYEE" },
                    { "3e117ec4-8897-4433-8b13-7ba47db1268d", null, "user", "USER" },
                    { "e7200274-c86d-4712-a1e0-53ea55edf95a", null, "manager", "MANAGER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2483bb23-dde4-477e-9922-768f5f6353a9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3e117ec4-8897-4433-8b13-7ba47db1268d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e7200274-c86d-4712-a1e0-53ea55edf95a");

            migrationBuilder.AlterColumn<int>(
                name: "Like",
                table: "Comments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2d51141a-8027-4ea9-a16b-ce7b28d2c923", null, "manager", "MANAGER" },
                    { "66046aa3-afcf-496f-b14e-173c31a3330f", null, "employee", "EMPLOYEE" },
                    { "e066a236-7501-4b49-a7ad-54c8f013ea9f", null, "user", "USER" }
                });
        }
    }
}
