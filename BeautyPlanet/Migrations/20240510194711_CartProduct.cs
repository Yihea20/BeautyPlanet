using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class CartProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCarts_ProductCenters_ProductCenterId",
                table: "ShoppingCarts");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ad86769-02d6-486d-9407-6bcae71aff2d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4587c241-246b-45ec-9a9a-181ede3c5106");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4aedc616-8ddd-48f8-854d-fbfe7b7c37c7");

            migrationBuilder.AlterColumn<int>(
                name: "ProductCenterId",
                table: "ShoppingCarts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CenterId",
                table: "ShoppingCarts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ShoppingCartId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2539ffa3-af8f-43fa-b7af-e6329944feda", null, "manager", "MANAGER" },
                    { "475c24e5-b989-4c01-a4ac-42ad3bb3ceef", null, "user", "USER" },
                    { "f025d77f-fb1d-488a-b849-98106f0543b6", null, "employee", "EMPLOYEE" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_CenterId",
                table: "ShoppingCarts",
                column: "CenterId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ShoppingCartId",
                table: "Products",
                column: "ShoppingCartId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ShoppingCarts_ShoppingCartId",
                table: "Products",
                column: "ShoppingCartId",
                principalTable: "ShoppingCarts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCarts_Centers_CenterId",
                table: "ShoppingCarts",
                column: "CenterId",
                principalTable: "Centers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCarts_ProductCenters_ProductCenterId",
                table: "ShoppingCarts",
                column: "ProductCenterId",
                principalTable: "ProductCenters",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ShoppingCarts_ShoppingCartId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCarts_Centers_CenterId",
                table: "ShoppingCarts");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCarts_ProductCenters_ProductCenterId",
                table: "ShoppingCarts");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCarts_CenterId",
                table: "ShoppingCarts");

            migrationBuilder.DropIndex(
                name: "IX_Products_ShoppingCartId",
                table: "Products");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2539ffa3-af8f-43fa-b7af-e6329944feda");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "475c24e5-b989-4c01-a4ac-42ad3bb3ceef");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f025d77f-fb1d-488a-b849-98106f0543b6");

            migrationBuilder.DropColumn(
                name: "CenterId",
                table: "ShoppingCarts");

            migrationBuilder.DropColumn(
                name: "ShoppingCartId",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "ProductCenterId",
                table: "ShoppingCarts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1ad86769-02d6-486d-9407-6bcae71aff2d", null, "manager", "MANAGER" },
                    { "4587c241-246b-45ec-9a9a-181ede3c5106", null, "employee", "EMPLOYEE" },
                    { "4aedc616-8ddd-48f8-854d-fbfe7b7c37c7", null, "user", "USER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCarts_ProductCenters_ProductCenterId",
                table: "ShoppingCarts",
                column: "ProductCenterId",
                principalTable: "ProductCenters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
