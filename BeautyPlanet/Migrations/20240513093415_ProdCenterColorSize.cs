using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class ProdCenterColorSize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductColorSizes");

            migrationBuilder.DropTable(
                name: "ShoppingCarts");

            migrationBuilder.DropTable(
                name: "ProductCenters");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0dccb934-dd3b-467f-88a8-ecf38381ef25");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2f1b55ce-5d0b-47bb-8695-45d379340f60");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9c2cfcad-6af2-494c-b379-749f4a944fcf");

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.CreateTable(
                name: "ProductCenterColorSizes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColorId = table.Column<int>(type: "int", nullable: true),
                    SizeId = table.Column<int>(type: "int", nullable: true),
                    CenterId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCenterColorSizes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductCenterColorSizes_Centers_CenterId",
                        column: x => x.CenterId,
                        principalTable: "Centers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCenterColorSizes_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductCenterColorSizes_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCenterColorSizes_Sizes_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Sizes",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "312da386-b3ed-4be6-a82a-b84142b2a663", null, "employee", "EMPLOYEE" },
                    { "50e4caf7-65da-4bc4-8969-3de295dc1f5b", null, "manager", "MANAGER" },
                    { "5a6c6aa4-8f83-430f-a5d8-96b409d3e2aa", null, "user", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductCenterColorSizes_CenterId",
                table: "ProductCenterColorSizes",
                column: "CenterId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCenterColorSizes_ColorId",
                table: "ProductCenterColorSizes",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCenterColorSizes_ProductId_CenterId",
                table: "ProductCenterColorSizes",
                columns: new[] { "ProductId", "CenterId" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductCenterColorSizes_ProductId_ColorId",
                table: "ProductCenterColorSizes",
                columns: new[] { "ProductId", "ColorId" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductCenterColorSizes_ProductId_SizeId",
                table: "ProductCenterColorSizes",
                columns: new[] { "ProductId", "SizeId" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductCenterColorSizes_SizeId",
                table: "ProductCenterColorSizes",
                column: "SizeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductCenterColorSizes");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "312da386-b3ed-4be6-a82a-b84142b2a663");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "50e4caf7-65da-4bc4-8969-3de295dc1f5b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5a6c6aa4-8f83-430f-a5d8-96b409d3e2aa");

            migrationBuilder.CreateTable(
                name: "ProductCenters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CenterId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCenters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductCenters_Centers_CenterId",
                        column: x => x.CenterId,
                        principalTable: "Centers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCenters_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCarts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CenterId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    ProductCenterId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCarts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCarts_Centers_CenterId",
                        column: x => x.CenterId,
                        principalTable: "Centers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoppingCarts_ProductCenters_ProductCenterId",
                        column: x => x.ProductCenterId,
                        principalTable: "ProductCenters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ShoppingCarts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductColorSizes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColorId = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    SizeId = table.Column<int>(type: "int", nullable: true),
                    ShoppingCartId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductColorSizes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductColorSizes_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductColorSizes_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductColorSizes_ShoppingCarts_ShoppingCartId",
                        column: x => x.ShoppingCartId,
                        principalTable: "ShoppingCarts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductColorSizes_Sizes_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Sizes",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0dccb934-dd3b-467f-88a8-ecf38381ef25", null, "manager", "MANAGER" },
                    { "2f1b55ce-5d0b-47bb-8695-45d379340f60", null, "employee", "EMPLOYEE" },
                    { "9c2cfcad-6af2-494c-b379-749f4a944fcf", null, "user", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "UpComing" },
                    { 2, "Completed" },
                    { 3, "Cancelled" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductCenters_CenterId",
                table: "ProductCenters",
                column: "CenterId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCenters_ProductId_CenterId",
                table: "ProductCenters",
                columns: new[] { "ProductId", "CenterId" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductColorSizes_ColorId",
                table: "ProductColorSizes",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductColorSizes_ProductId_ColorId",
                table: "ProductColorSizes",
                columns: new[] { "ProductId", "ColorId" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductColorSizes_ProductId_SizeId",
                table: "ProductColorSizes",
                columns: new[] { "ProductId", "SizeId" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductColorSizes_ShoppingCartId",
                table: "ProductColorSizes",
                column: "ShoppingCartId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductColorSizes_SizeId",
                table: "ProductColorSizes",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_CenterId",
                table: "ShoppingCarts",
                column: "CenterId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_ProductCenterId",
                table: "ShoppingCarts",
                column: "ProductCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_UserId",
                table: "ShoppingCarts",
                column: "UserId");
        }
    }
}
