using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class DeleteProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCenterColorSizes_Products_ProductId",
                table: "ProductCenterColorSizes");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Products_ProductId",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Products_ProductId",
                table: "Reviews");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_ProductId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_ProductCenterColorSizes_ProductId_ColorId",
                table: "ProductCenterColorSizes");

            migrationBuilder.DropIndex(
                name: "IX_ProductCenterColorSizes_ProductId_SizeId",
                table: "ProductCenterColorSizes");

            migrationBuilder.DropIndex(
                name: "IX_ProductCenterColorSizes_ProductId_StoreId",
                table: "ProductCenterColorSizes");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a546d71a-ff81-46ab-9f19-67aabfc99a12");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c6b90aec-a7b4-47ee-9726-ff97c553ec07");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ed038662-549b-4990-af27-06c0b633ca6e");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "ProductCenterColorSizes",
                newName: "Rate");

            migrationBuilder.AddColumn<int>(
                name: "ProducttId",
                table: "Reviews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Conter",
                table: "ProductCenterColorSizes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ProductCenterColorSizes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "EarnPoint",
                table: "ProductCenterColorSizes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "ProductCenterColorSizes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ProductCenterColorSizes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "OfferPercent",
                table: "ProductCenterColorSizes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "ProductCenterColorSizes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ProductAddTime",
                table: "ProductCenterColorSizes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ShoppingCategoryId",
                table: "ProductCenterColorSizes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "ProductCenterColorSizes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2d4da3bf-6b84-4a28-a0c3-96408f0b0dc0", null, "employee", "EMPLOYEE" },
                    { "6bcfb63a-da10-42a9-b5cf-6aeb00a65909", null, "manager", "MANAGER" },
                    { "7fca8912-1eb7-4133-9ac5-b62570149702", null, "user", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ProducttId",
                table: "Reviews",
                column: "ProducttId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCenterColorSizes_ShoppingCategoryId",
                table: "ProductCenterColorSizes",
                column: "ShoppingCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCenterColorSizes_ShoppingCategories_ShoppingCategoryId",
                table: "ProductCenterColorSizes",
                column: "ShoppingCategoryId",
                principalTable: "ShoppingCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_ProductCenterColorSizes_ProductId",
                table: "Ratings",
                column: "ProductId",
                principalTable: "ProductCenterColorSizes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_ProductCenterColorSizes_ProducttId",
                table: "Reviews",
                column: "ProducttId",
                principalTable: "ProductCenterColorSizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCenterColorSizes_ShoppingCategories_ShoppingCategoryId",
                table: "ProductCenterColorSizes");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_ProductCenterColorSizes_ProductId",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_ProductCenterColorSizes_ProducttId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_ProducttId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_ProductCenterColorSizes_ShoppingCategoryId",
                table: "ProductCenterColorSizes");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d4da3bf-6b84-4a28-a0c3-96408f0b0dc0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6bcfb63a-da10-42a9-b5cf-6aeb00a65909");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7fca8912-1eb7-4133-9ac5-b62570149702");

            migrationBuilder.DropColumn(
                name: "ProducttId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "Conter",
                table: "ProductCenterColorSizes");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "ProductCenterColorSizes");

            migrationBuilder.DropColumn(
                name: "EarnPoint",
                table: "ProductCenterColorSizes");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "ProductCenterColorSizes");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ProductCenterColorSizes");

            migrationBuilder.DropColumn(
                name: "OfferPercent",
                table: "ProductCenterColorSizes");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "ProductCenterColorSizes");

            migrationBuilder.DropColumn(
                name: "ProductAddTime",
                table: "ProductCenterColorSizes");

            migrationBuilder.DropColumn(
                name: "ShoppingCategoryId",
                table: "ProductCenterColorSizes");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "ProductCenterColorSizes");

            migrationBuilder.RenameColumn(
                name: "Rate",
                table: "ProductCenterColorSizes",
                newName: "ProductId");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShoppingCategoryId = table.Column<int>(type: "int", nullable: false),
                    CenterId = table.Column<int>(type: "int", nullable: true),
                    Conter = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EarnPoint = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OfferPercent = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    ProductAddTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rate = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Centers_CenterId",
                        column: x => x.CenterId,
                        principalTable: "Centers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_ShoppingCategories_ShoppingCategoryId",
                        column: x => x.ShoppingCategoryId,
                        principalTable: "ShoppingCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a546d71a-ff81-46ab-9f19-67aabfc99a12", null, "user", "USER" },
                    { "c6b90aec-a7b4-47ee-9726-ff97c553ec07", null, "manager", "MANAGER" },
                    { "ed038662-549b-4990-af27-06c0b633ca6e", null, "employee", "EMPLOYEE" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ProductId",
                table: "Reviews",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCenterColorSizes_ProductId_ColorId",
                table: "ProductCenterColorSizes",
                columns: new[] { "ProductId", "ColorId" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductCenterColorSizes_ProductId_SizeId",
                table: "ProductCenterColorSizes",
                columns: new[] { "ProductId", "SizeId" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductCenterColorSizes_ProductId_StoreId",
                table: "ProductCenterColorSizes",
                columns: new[] { "ProductId", "StoreId" });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CenterId",
                table: "Products",
                column: "CenterId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ShoppingCategoryId",
                table: "Products",
                column: "ShoppingCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCenterColorSizes_Products_ProductId",
                table: "ProductCenterColorSizes",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Products_ProductId",
                table: "Ratings",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Products_ProductId",
                table: "Reviews",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
