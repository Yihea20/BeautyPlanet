using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class AddSatusShoppingCart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3aa5632d-bbf4-4bcf-a248-92dccb868c12");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad3702f3-d2fd-4f67-ab42-734243db1a66");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db42307e-1890-4c57-b0f6-318f831e9732");

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "ShoppingCarts",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1122694c-9fd0-447e-98b9-e2e58f5bd54b", null, "manager", "MANAGER" },
                    { "3d5f2da2-b73b-4fbc-ac95-3ed24fb147fe", null, "user", "USER" },
                    { "df489810-7690-4018-b7f4-cbb63e8e1afa", null, "employee", "EMPLOYEE" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_StatusId",
                table: "ShoppingCarts",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCarts_Statuses_StatusId",
                table: "ShoppingCarts",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCarts_Statuses_StatusId",
                table: "ShoppingCarts");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCarts_StatusId",
                table: "ShoppingCarts");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1122694c-9fd0-447e-98b9-e2e58f5bd54b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d5f2da2-b73b-4fbc-ac95-3ed24fb147fe");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df489810-7690-4018-b7f4-cbb63e8e1afa");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "ShoppingCarts");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3aa5632d-bbf4-4bcf-a248-92dccb868c12", null, "manager", "MANAGER" },
                    { "ad3702f3-d2fd-4f67-ab42-734243db1a66", null, "employee", "EMPLOYEE" },
                    { "db42307e-1890-4c57-b0f6-318f831e9732", null, "user", "USER" }
                });
        }
    }
}
