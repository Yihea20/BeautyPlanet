using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class ShoppingCartAddToStores : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCarts_Stores_StoreId",
                table: "ShoppingCarts");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4668719d-999d-4e7e-8426-23db16072f02");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "78c4c684-83fe-4ebf-8974-e6b2d0f5cef7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d90a3359-8cc9-4642-a137-15c8a3f371ce");

            migrationBuilder.AlterColumn<int>(
                name: "StoreId",
                table: "ShoppingCarts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "24868a1f-9d06-4e1b-9c6e-a9073fa11602", null, "user", "USER" },
                    { "af9265dd-532b-4c7e-867c-8abdb34a376c", null, "manager", "MANAGER" },
                    { "e9600885-be3c-41f4-8996-3b4d89cf52c5", null, "employee", "EMPLOYEE" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCarts_Stores_StoreId",
                table: "ShoppingCarts",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCarts_Stores_StoreId",
                table: "ShoppingCarts");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "24868a1f-9d06-4e1b-9c6e-a9073fa11602");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "af9265dd-532b-4c7e-867c-8abdb34a376c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e9600885-be3c-41f4-8996-3b4d89cf52c5");

            migrationBuilder.AlterColumn<int>(
                name: "StoreId",
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
                    { "4668719d-999d-4e7e-8426-23db16072f02", null, "manager", "MANAGER" },
                    { "78c4c684-83fe-4ebf-8974-e6b2d0f5cef7", null, "user", "USER" },
                    { "d90a3359-8cc9-4642-a137-15c8a3f371ce", null, "employee", "EMPLOYEE" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCarts_Stores_StoreId",
                table: "ShoppingCarts",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
