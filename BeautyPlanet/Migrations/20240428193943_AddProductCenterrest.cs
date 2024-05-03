using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class AddProductCenterrest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCenters_Products_ProducttId",
                table: "ProductCenters");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "181c9372-326a-46d1-bff6-8fca455d30d9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5965c315-794d-49ee-a465-e3d3214a218f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c521ebda-6e0d-4c40-8c6e-79de30043839");

            migrationBuilder.DropColumn(
                name: "ProducId",
                table: "ProductCenters");

            migrationBuilder.RenameColumn(
                name: "ProducttId",
                table: "ProductCenters",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCenters_ProducttId",
                table: "ProductCenters",
                newName: "IX_ProductCenters_ProductId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2433ca33-65b5-422c-99ce-f9e473ec9073", null, "employee", "EMPLOYEE" },
                    { "2f1afa7f-013e-4207-a6f7-5b520a8a33fa", null, "user", "USER" },
                    { "be0f7a7b-b28f-4ab1-b906-060e254a9c5f", null, "manager", "MANAGER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCenters_Products_ProductId",
                table: "ProductCenters",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCenters_Products_ProductId",
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

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "ProductCenters",
                newName: "ProducttId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCenters_ProductId",
                table: "ProductCenters",
                newName: "IX_ProductCenters_ProducttId");

            migrationBuilder.AddColumn<int>(
                name: "ProducId",
                table: "ProductCenters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "181c9372-326a-46d1-bff6-8fca455d30d9", null, "manager", "MANAGER" },
                    { "5965c315-794d-49ee-a465-e3d3214a218f", null, "employee", "EMPLOYEE" },
                    { "c521ebda-6e0d-4c40-8c6e-79de30043839", null, "user", "USER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCenters_Products_ProducttId",
                table: "ProductCenters",
                column: "ProducttId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
