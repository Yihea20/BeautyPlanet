using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class AddProductCenterr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCenters_Products_ProductId",
                table: "ProductCenters");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0a628bdf-699a-49d8-9485-f255cb334755");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1bffd8d6-7893-4aff-802b-e353ba9c101d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c4a23874-b1f6-42e1-9446-b5da739d809b");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "0a628bdf-699a-49d8-9485-f255cb334755", null, "employee", "EMPLOYEE" },
                    { "1bffd8d6-7893-4aff-802b-e353ba9c101d", null, "user", "USER" },
                    { "c4a23874-b1f6-42e1-9446-b5da739d809b", null, "manager", "MANAGER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCenters_Products_ProductId",
                table: "ProductCenters",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
