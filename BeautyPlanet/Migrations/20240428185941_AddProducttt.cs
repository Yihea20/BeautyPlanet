using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class AddProducttt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ShoppingCategories_CategoryyId",
                table: "Products");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "14ce0ab0-87c0-4316-bfe9-709897f2b3d0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "457f8522-5e0a-41d8-868b-8f5947202934");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7d247b05-42f4-41fc-87ca-b33b946bcec1");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "CategoryyId",
                table: "Products",
                newName: "ShoppingCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CategoryyId",
                table: "Products",
                newName: "IX_Products_ShoppingCategoryId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9a35a2fb-6321-4d30-8eb2-5733d5bb6cb7", null, "employee", "EMPLOYEE" },
                    { "b3a7b6e5-0507-4769-a114-f016fa7a16b4", null, "user", "USER" },
                    { "fc14d910-6754-4f2a-b712-fd5ff0d6973f", null, "manager", "MANAGER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ShoppingCategories_ShoppingCategoryId",
                table: "Products",
                column: "ShoppingCategoryId",
                principalTable: "ShoppingCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ShoppingCategories_ShoppingCategoryId",
                table: "Products");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a35a2fb-6321-4d30-8eb2-5733d5bb6cb7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b3a7b6e5-0507-4769-a114-f016fa7a16b4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fc14d910-6754-4f2a-b712-fd5ff0d6973f");

            migrationBuilder.RenameColumn(
                name: "ShoppingCategoryId",
                table: "Products",
                newName: "CategoryyId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_ShoppingCategoryId",
                table: "Products",
                newName: "IX_Products_CategoryyId");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "14ce0ab0-87c0-4316-bfe9-709897f2b3d0", null, "manager", "MANAGER" },
                    { "457f8522-5e0a-41d8-868b-8f5947202934", null, "employee", "EMPLOYEE" },
                    { "7d247b05-42f4-41fc-87ca-b33b946bcec1", null, "user", "USER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ShoppingCategories_CategoryyId",
                table: "Products",
                column: "CategoryyId",
                principalTable: "ShoppingCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
