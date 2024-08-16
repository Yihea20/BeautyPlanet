using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class KeyProductStore1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCenterColorSizes_Companies_StorId",
                table: "ProductCenterColorSizes");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCarts_Companies_StoreId",
                table: "ShoppingCarts");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCategoryStore_Companies_StoresId",
                table: "ShoppingCategoryStore");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Companies",
                table: "Companies");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "12d4f4c1-d021-42ba-96db-91eb598b4d08");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4f70613e-7466-4a64-9bf6-869d0412a72a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e5d29f9a-2a0b-46eb-9096-e71efdb155c6");

            migrationBuilder.RenameTable(
                name: "Companies",
                newName: "Stores");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stores",
                table: "Stores",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "058bb0bd-cc0f-47b6-b01f-d0db514e2471", null, "manager", "MANAGER" },
                    { "0f0408dd-38e4-46c5-b37e-f4db053bbb49", null, "user", "USER" },
                    { "84e346e9-af13-4f98-86c3-190e7bbd0401", null, "employee", "EMPLOYEE" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCenterColorSizes_Stores_StorId",
                table: "ProductCenterColorSizes",
                column: "StorId",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCarts_Stores_StoreId",
                table: "ShoppingCarts",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCategoryStore_Stores_StoresId",
                table: "ShoppingCategoryStore",
                column: "StoresId",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCenterColorSizes_Stores_StorId",
                table: "ProductCenterColorSizes");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCarts_Stores_StoreId",
                table: "ShoppingCarts");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCategoryStore_Stores_StoresId",
                table: "ShoppingCategoryStore");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stores",
                table: "Stores");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "058bb0bd-cc0f-47b6-b01f-d0db514e2471");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f0408dd-38e4-46c5-b37e-f4db053bbb49");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "84e346e9-af13-4f98-86c3-190e7bbd0401");

            migrationBuilder.RenameTable(
                name: "Stores",
                newName: "Companies");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Companies",
                table: "Companies",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "12d4f4c1-d021-42ba-96db-91eb598b4d08", null, "user", "USER" },
                    { "4f70613e-7466-4a64-9bf6-869d0412a72a", null, "employee", "EMPLOYEE" },
                    { "e5d29f9a-2a0b-46eb-9096-e71efdb155c6", null, "manager", "MANAGER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCenterColorSizes_Companies_StorId",
                table: "ProductCenterColorSizes",
                column: "StorId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCarts_Companies_StoreId",
                table: "ShoppingCarts",
                column: "StoreId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCategoryStore_Companies_StoresId",
                table: "ShoppingCategoryStore",
                column: "StoresId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
