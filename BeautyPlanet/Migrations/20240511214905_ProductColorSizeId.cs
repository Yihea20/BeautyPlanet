using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class ProductColorSizeId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ColorsProduct");

            migrationBuilder.DropTable(
                name: "ProductSizes");

            migrationBuilder.DropIndex(
                name: "IX_ProductColorSizes_ProductId",
                table: "ProductColorSizes");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2dc3f74f-fc96-4990-85e6-68da7218f608");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4f3a283-5ceb-4657-93a6-496d15fd61ef");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d704ce12-6123-449d-8aca-d217afab17c6");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1ad78a1f-3ba5-4633-897d-cbd192b49ac9", null, "employee", "EMPLOYEE" },
                    { "802fa45a-ef25-41c8-af1e-07dc42911f74", null, "manager", "MANAGER" },
                    { "9328874d-9479-4cab-8a87-d687526af4e0", null, "user", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductColorSizes_ProductId_ColorId",
                table: "ProductColorSizes",
                columns: new[] { "ProductId", "ColorId" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductColorSizes_ProductId_SizeId",
                table: "ProductColorSizes",
                columns: new[] { "ProductId", "SizeId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ProductColorSizes_ProductId_ColorId",
                table: "ProductColorSizes");

            migrationBuilder.DropIndex(
                name: "IX_ProductColorSizes_ProductId_SizeId",
                table: "ProductColorSizes");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ad78a1f-3ba5-4633-897d-cbd192b49ac9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "802fa45a-ef25-41c8-af1e-07dc42911f74");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9328874d-9479-4cab-8a87-d687526af4e0");

            migrationBuilder.CreateTable(
                name: "ColorsProduct",
                columns: table => new
                {
                    ColorsId = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColorsProduct", x => new { x.ColorsId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_ColorsProduct_Colors_ColorsId",
                        column: x => x.ColorsId,
                        principalTable: "Colors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ColorsProduct_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductSizes",
                columns: table => new
                {
                    ProductsId = table.Column<int>(type: "int", nullable: false),
                    SizesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSizes", x => new { x.ProductsId, x.SizesId });
                    table.ForeignKey(
                        name: "FK_ProductSizes_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductSizes_Sizes_SizesId",
                        column: x => x.SizesId,
                        principalTable: "Sizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2dc3f74f-fc96-4990-85e6-68da7218f608", null, "employee", "EMPLOYEE" },
                    { "b4f3a283-5ceb-4657-93a6-496d15fd61ef", null, "manager", "MANAGER" },
                    { "d704ce12-6123-449d-8aca-d217afab17c6", null, "user", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductColorSizes_ProductId",
                table: "ProductColorSizes",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ColorsProduct_ProductsId",
                table: "ColorsProduct",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSizes_SizesId",
                table: "ProductSizes",
                column: "SizesId");
        }
    }
}
