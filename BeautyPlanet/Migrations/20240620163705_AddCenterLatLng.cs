using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class AddCenterLatLng : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<double>(
                name: "Lat",
                table: "Centers",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Lng",
                table: "Centers",
                type: "float",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8d107c00-d675-4eb2-b221-37fde33d14ca", null, "user", "USER" },
                    { "f3fa0a34-9fa4-4504-8fa8-5c9e3b4c39be", null, "manager", "MANAGER" },
                    { "fc8b965d-8bde-4a99-ab2b-76f499db59a1", null, "employee", "EMPLOYEE" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8d107c00-d675-4eb2-b221-37fde33d14ca");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f3fa0a34-9fa4-4504-8fa8-5c9e3b4c39be");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fc8b965d-8bde-4a99-ab2b-76f499db59a1");

            migrationBuilder.DropColumn(
                name: "Lat",
                table: "Centers");

            migrationBuilder.DropColumn(
                name: "Lng",
                table: "Centers");

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
    }
}
