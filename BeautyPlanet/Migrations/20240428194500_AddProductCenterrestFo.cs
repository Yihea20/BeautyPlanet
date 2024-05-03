using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class AddProductCenterrestFo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CenterProduct");

            migrationBuilder.DropIndex(
                name: "IX_ProductCenters_ProductId",
                table: "ProductCenters");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2433ca33-65b5-422c-99ce-f9e473ec9073");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2f1afa7f-013e-4207-a6f7-5b520a8a33fa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "be0f7a7b-b28f-4ab1-b906-060e254a9c5f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "999af68a-2c1e-485a-a868-c5e18f94e859", null, "manager", "MANAGER" },
                    { "a79f5786-7867-4ee3-a514-a718252bc9e9", null, "user", "USER" },
                    { "c9f4bcff-9a3d-4b56-93d8-f9dbd2510c00", null, "employee", "EMPLOYEE" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductCenters_ProductId_CenterId",
                table: "ProductCenters",
                columns: new[] { "ProductId", "CenterId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ProductCenters_ProductId_CenterId",
                table: "ProductCenters");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "999af68a-2c1e-485a-a868-c5e18f94e859");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a79f5786-7867-4ee3-a514-a718252bc9e9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c9f4bcff-9a3d-4b56-93d8-f9dbd2510c00");

            migrationBuilder.CreateTable(
                name: "CenterProduct",
                columns: table => new
                {
                    CentersId = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CenterProduct", x => new { x.CentersId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_CenterProduct_Centers_CentersId",
                        column: x => x.CentersId,
                        principalTable: "Centers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CenterProduct_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2433ca33-65b5-422c-99ce-f9e473ec9073", null, "employee", "EMPLOYEE" },
                    { "2f1afa7f-013e-4207-a6f7-5b520a8a33fa", null, "user", "USER" },
                    { "be0f7a7b-b28f-4ab1-b906-060e254a9c5f", null, "manager", "MANAGER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductCenters_ProductId",
                table: "ProductCenters",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_CenterProduct_ProductsId",
                table: "CenterProduct",
                column: "ProductsId");
        }
    }
}
