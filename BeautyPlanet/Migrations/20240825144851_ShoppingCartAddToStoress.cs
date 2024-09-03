using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class ShoppingCartAddToStoress : Migration
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
                    { "a546d71a-ff81-46ab-9f19-67aabfc99a12", null, "user", "USER" },
                    { "c6b90aec-a7b4-47ee-9726-ff97c553ec07", null, "manager", "MANAGER" },
                    { "ed038662-549b-4990-af27-06c0b633ca6e", null, "employee", "EMPLOYEE" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCarts_Stores_StoreId",
                table: "ShoppingCarts",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
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
                keyValue: "a546d71a-ff81-46ab-9f19-67aabfc99a12");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c6b90aec-a7b4-47ee-9726-ff97c553ec07");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ed038662-549b-4990-af27-06c0b633ca6e");

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
    }
}
