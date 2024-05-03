using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class Company : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Company_CompanyId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ShoppingCategory_CategoryyId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingCategory",
                table: "ShoppingCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Company",
                table: "Company");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f8cf530-a2b7-47a8-b4e5-c18bb33e24f7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "10dd2a21-630e-4651-be08-0970372d21de");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1558dfa3-9d33-405a-a901-6a67ddafe1b1");

            migrationBuilder.RenameTable(
                name: "ShoppingCategory",
                newName: "ShoppingCategories");

            migrationBuilder.RenameTable(
                name: "Company",
                newName: "Companies");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingCategories",
                table: "ShoppingCategories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Companies",
                table: "Companies",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "41e2d776-b657-40d5-a075-6ffe8467814a", null, "user", "USER" },
                    { "5d1a1cad-768f-4c30-8a40-0e2671b665ce", null, "employee", "EMPLOYEE" },
                    { "5dc2e9c9-a432-49c4-b77f-096a1668dcce", null, "manager", "MANAGER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Companies_CompanyId",
                table: "Products",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ShoppingCategories_CategoryyId",
                table: "Products",
                column: "CategoryyId",
                principalTable: "ShoppingCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Companies_CompanyId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ShoppingCategories_CategoryyId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingCategories",
                table: "ShoppingCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Companies",
                table: "Companies");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "41e2d776-b657-40d5-a075-6ffe8467814a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d1a1cad-768f-4c30-8a40-0e2671b665ce");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5dc2e9c9-a432-49c4-b77f-096a1668dcce");

            migrationBuilder.RenameTable(
                name: "ShoppingCategories",
                newName: "ShoppingCategory");

            migrationBuilder.RenameTable(
                name: "Companies",
                newName: "Company");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingCategory",
                table: "ShoppingCategory",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Company",
                table: "Company",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0f8cf530-a2b7-47a8-b4e5-c18bb33e24f7", null, "employee", "EMPLOYEE" },
                    { "10dd2a21-630e-4651-be08-0970372d21de", null, "user", "USER" },
                    { "1558dfa3-9d33-405a-a901-6a67ddafe1b1", null, "manager", "MANAGER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Company_CompanyId",
                table: "Products",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ShoppingCategory_CategoryyId",
                table: "Products",
                column: "CategoryyId",
                principalTable: "ShoppingCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
