using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class AddTypeToProd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1240d703-2454-4529-acfd-0bc262f4480e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a38b1e21-c625-4766-b46a-19321c221902");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d295ab97-f49d-466d-bd1e-b91f524a4a73");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3cf9e350-864a-4f27-8650-ea0d17facca1", null, "manager", "MANAGER" },
                    { "50cfc543-4e02-4792-845c-a00b1642eb4f", null, "employee", "EMPLOYEE" },
                    { "5bd7e1be-77c3-483b-be79-3fdcbaa11857", null, "user", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "#000000");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "#FF0000");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "#00ff00");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Products");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1240d703-2454-4529-acfd-0bc262f4480e", null, "manager", "MANAGER" },
                    { "a38b1e21-c625-4766-b46a-19321c221902", null, "user", "USER" },
                    { "d295ab97-f49d-466d-bd1e-b91f524a4a73", null, "employee", "EMPLOYEE" }
                });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Black");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Red");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Green");
        }
    }
}
