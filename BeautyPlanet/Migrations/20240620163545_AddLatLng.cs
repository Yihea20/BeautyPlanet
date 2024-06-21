using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class AddLatLng : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3cf9e350-864a-4f27-8650-ea0d17facca1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "50cfc543-4e02-4792-845c-a00b1642eb4f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5bd7e1be-77c3-483b-be79-3fdcbaa11857");

            migrationBuilder.AddColumn<double>(
                name: "Lat",
                table: "Users",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Lng",
                table: "Users",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Lat",
                table: "Specialists",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Lng",
                table: "Specialists",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Lat",
                table: "AspNetUsers",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Lng",
                table: "AspNetUsers",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Lat",
                table: "Admins",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Lng",
                table: "Admins",
                type: "float",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "07fab605-e8d9-4d92-b64c-cf62872f87dd", null, "manager", "MANAGER" },
                    { "2b38db1c-0bf6-4b28-8802-4db63705d761", null, "employee", "EMPLOYEE" },
                    { "960cda89-ee54-4a13-a063-4fef527da55f", null, "user", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "07fab605-e8d9-4d92-b64c-cf62872f87dd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2b38db1c-0bf6-4b28-8802-4db63705d761");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "960cda89-ee54-4a13-a063-4fef527da55f");

            migrationBuilder.DropColumn(
                name: "Lat",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Lng",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Lat",
                table: "Specialists");

            migrationBuilder.DropColumn(
                name: "Lng",
                table: "Specialists");

            migrationBuilder.DropColumn(
                name: "Lat",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Lng",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Lat",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "Lng",
                table: "Admins");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3cf9e350-864a-4f27-8650-ea0d17facca1", null, "manager", "MANAGER" },
                    { "50cfc543-4e02-4792-845c-a00b1642eb4f", null, "employee", "EMPLOYEE" },
                    { "5bd7e1be-77c3-483b-be79-3fdcbaa11857", null, "user", "USER" }
                });
        }
    }
}
