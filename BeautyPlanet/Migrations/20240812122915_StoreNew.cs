using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class StoreNew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCenterColorSizes_Centers_CenterId",
                table: "ProductCenterColorSizes");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Companies_CompanyId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCarts_Centers_CenterId",
                table: "ShoppingCarts");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "182031cd-3b53-4b20-90e4-b97534c7cf5e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "814e813a-04c6-4930-bc73-114de765aa5f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f5cff9d0-e735-4006-b202-e64af8902491");

            migrationBuilder.RenameColumn(
                name: "CenterId",
                table: "ShoppingCarts",
                newName: "StoreId");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCarts_CenterId",
                table: "ShoppingCarts",
                newName: "IX_ShoppingCarts_StoreId");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "Products",
                newName: "CenterId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CompanyId",
                table: "Products",
                newName: "IX_Products_CenterId");

            migrationBuilder.RenameColumn(
                name: "CenterId",
                table: "ProductCenterColorSizes",
                newName: "StorId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCenterColorSizes_ProductId_CenterId",
                table: "ProductCenterColorSizes",
                newName: "IX_ProductCenterColorSizes_ProductId_StorId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCenterColorSizes_CenterId",
                table: "ProductCenterColorSizes",
                newName: "IX_ProductCenterColorSizes_StorId");

            migrationBuilder.CreateTable(
                name: "ShoppingCategoryStore",
                columns: table => new
                {
                    ShoppingCategoriesId = table.Column<int>(type: "int", nullable: false),
                    StoresId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCategoryStore", x => new { x.ShoppingCategoriesId, x.StoresId });
                    table.ForeignKey(
                        name: "FK_ShoppingCategoryStore_Companies_StoresId",
                        column: x => x.StoresId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoppingCategoryStore_ShoppingCategories_ShoppingCategoriesId",
                        column: x => x.ShoppingCategoriesId,
                        principalTable: "ShoppingCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b9f30046-2a02-4789-bbcb-21bce4df5ec3", null, "manager", "MANAGER" },
                    { "d1129a29-f7bb-4ca7-8772-a85a5b081b9f", null, "user", "USER" },
                    { "d8a45d69-c197-4e0c-8b17-868a6c18c652", null, "employee", "EMPLOYEE" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCategoryStore_StoresId",
                table: "ShoppingCategoryStore",
                column: "StoresId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCenterColorSizes_Companies_StorId",
                table: "ProductCenterColorSizes",
                column: "StorId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Centers_CenterId",
                table: "Products",
                column: "CenterId",
                principalTable: "Centers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCarts_Companies_StoreId",
                table: "ShoppingCarts",
                column: "StoreId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCenterColorSizes_Companies_StorId",
                table: "ProductCenterColorSizes");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Centers_CenterId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCarts_Companies_StoreId",
                table: "ShoppingCarts");

            migrationBuilder.DropTable(
                name: "ShoppingCategoryStore");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b9f30046-2a02-4789-bbcb-21bce4df5ec3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d1129a29-f7bb-4ca7-8772-a85a5b081b9f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d8a45d69-c197-4e0c-8b17-868a6c18c652");

            migrationBuilder.RenameColumn(
                name: "StoreId",
                table: "ShoppingCarts",
                newName: "CenterId");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCarts_StoreId",
                table: "ShoppingCarts",
                newName: "IX_ShoppingCarts_CenterId");

            migrationBuilder.RenameColumn(
                name: "CenterId",
                table: "Products",
                newName: "CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CenterId",
                table: "Products",
                newName: "IX_Products_CompanyId");

            migrationBuilder.RenameColumn(
                name: "StorId",
                table: "ProductCenterColorSizes",
                newName: "CenterId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCenterColorSizes_StorId",
                table: "ProductCenterColorSizes",
                newName: "IX_ProductCenterColorSizes_CenterId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCenterColorSizes_ProductId_StorId",
                table: "ProductCenterColorSizes",
                newName: "IX_ProductCenterColorSizes_ProductId_CenterId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "182031cd-3b53-4b20-90e4-b97534c7cf5e", null, "employee", "EMPLOYEE" },
                    { "814e813a-04c6-4930-bc73-114de765aa5f", null, "manager", "MANAGER" },
                    { "f5cff9d0-e735-4006-b202-e64af8902491", null, "user", "USER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCenterColorSizes_Centers_CenterId",
                table: "ProductCenterColorSizes",
                column: "CenterId",
                principalTable: "Centers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Companies_CompanyId",
                table: "Products",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCarts_Centers_CenterId",
                table: "ShoppingCarts",
                column: "CenterId",
                principalTable: "Centers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
