using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class Fillters : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27648c8d-e54e-4e82-976b-632f9f107d8a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ccb8938-15a0-4f0a-b5a1-4dcac1394c8c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c9ae50a5-c709-4072-be87-4eb0881dc9cd");

            migrationBuilder.CreateTable(
                name: "Distances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    From = table.Column<double>(type: "float", nullable: false),
                    To = table.Column<double>(type: "float", nullable: false),
                    FromTo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Distances", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TheRate = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rates", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "82a6ae98-9c9a-4348-9f88-6e486ca8bef6", null, "employee", "EMPLOYEE" },
                    { "89ab2b90-2bdf-4d4f-8ee9-9a2f142cb563", null, "manager", "MANAGER" },
                    { "b6728e01-09db-4102-8ad5-7b4cbf092868", null, "user", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Distances",
                columns: new[] { "Id", "From", "FromTo", "To" },
                values: new object[,]
                {
                    { 1, 0.0, " < 10 km", 10.0 },
                    { 2, 10.0, " 10 - 15 km", 15.0 },
                    { 3, 15.0, " 15 - 20 km", 20.0 },
                    { 4, 20.0, " 20 - 25 km", 25.0 },
                    { 5, 25.0, " 25 - 30 km", 30.0 }
                });

            migrationBuilder.InsertData(
                table: "Rates",
                columns: new[] { "Id", "TheRate" },
                values: new object[,]
                {
                    { 1, 1.0 },
                    { 2, 1.5 },
                    { 3, 2.0 },
                    { 4, 2.5 },
                    { 5, 3.0 },
                    { 6, 3.5 },
                    { 7, 4.0 },
                    { 8, 4.5 },
                    { 9, 5.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Distances");

            migrationBuilder.DropTable(
                name: "Rates");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "82a6ae98-9c9a-4348-9f88-6e486ca8bef6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "89ab2b90-2bdf-4d4f-8ee9-9a2f142cb563");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b6728e01-09db-4102-8ad5-7b4cbf092868");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "27648c8d-e54e-4e82-976b-632f9f107d8a", null, "manager", "MANAGER" },
                    { "6ccb8938-15a0-4f0a-b5a1-4dcac1394c8c", null, "employee", "EMPLOYEE" },
                    { "c9ae50a5-c709-4072-be87-4eb0881dc9cd", null, "user", "USER" }
                });
        }
    }
}
