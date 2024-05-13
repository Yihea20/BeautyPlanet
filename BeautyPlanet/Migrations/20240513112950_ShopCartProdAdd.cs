using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class ShopCartProdAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "409066fd-5279-42cc-90e1-90a5393c2d01");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "91ee00dd-fd0c-42fd-8195-beeef5c42b22");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f364e41f-d260-41ff-8878-e40057bb69e7");

            migrationBuilder.RenameColumn(
                name: "Count",
                table: "ShoppingCarts",
                newName: "TotalPrice");

            migrationBuilder.AddColumn<int>(
                name: "count",
                table: "ProductShopCarts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3aa5632d-bbf4-4bcf-a248-92dccb868c12", null, "manager", "MANAGER" },
                    { "ad3702f3-d2fd-4f67-ab42-734243db1a66", null, "employee", "EMPLOYEE" },
                    { "db42307e-1890-4c57-b0f6-318f831e9732", null, "user", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3aa5632d-bbf4-4bcf-a248-92dccb868c12");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad3702f3-d2fd-4f67-ab42-734243db1a66");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db42307e-1890-4c57-b0f6-318f831e9732");

            migrationBuilder.DropColumn(
                name: "count",
                table: "ProductShopCarts");

            migrationBuilder.RenameColumn(
                name: "TotalPrice",
                table: "ShoppingCarts",
                newName: "Count");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "409066fd-5279-42cc-90e1-90a5393c2d01", null, "employee", "EMPLOYEE" },
                    { "91ee00dd-fd0c-42fd-8195-beeef5c42b22", null, "manager", "MANAGER" },
                    { "f364e41f-d260-41ff-8878-e40057bb69e7", null, "user", "USER" }
                });
        }
    }
}
