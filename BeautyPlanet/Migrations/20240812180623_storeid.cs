using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class storeid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCenterColorSizes_Stores_StorId",
                table: "ProductCenterColorSizes");

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

            migrationBuilder.RenameColumn(
                name: "StorId",
                table: "ProductCenterColorSizes",
                newName: "StoreId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCenterColorSizes_StorId",
                table: "ProductCenterColorSizes",
                newName: "IX_ProductCenterColorSizes_StoreId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCenterColorSizes_ProductId_StorId",
                table: "ProductCenterColorSizes",
                newName: "IX_ProductCenterColorSizes_ProductId_StoreId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "82aa2008-e372-46f4-9985-b5c9301a0e44", null, "employee", "EMPLOYEE" },
                    { "dd8d28e1-b454-41b2-a684-8f9381e31622", null, "manager", "MANAGER" },
                    { "f0095b63-eda5-481a-9da9-b58adf183a17", null, "user", "USER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCenterColorSizes_Stores_StoreId",
                table: "ProductCenterColorSizes",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCenterColorSizes_Stores_StoreId",
                table: "ProductCenterColorSizes");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "82aa2008-e372-46f4-9985-b5c9301a0e44");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dd8d28e1-b454-41b2-a684-8f9381e31622");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f0095b63-eda5-481a-9da9-b58adf183a17");

            migrationBuilder.RenameColumn(
                name: "StoreId",
                table: "ProductCenterColorSizes",
                newName: "StorId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCenterColorSizes_StoreId",
                table: "ProductCenterColorSizes",
                newName: "IX_ProductCenterColorSizes_StorId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCenterColorSizes_ProductId_StoreId",
                table: "ProductCenterColorSizes",
                newName: "IX_ProductCenterColorSizes_ProductId_StorId");

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
        }
    }
}
