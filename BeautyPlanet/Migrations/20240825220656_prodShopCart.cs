using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class prodShopCart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "70ad459f-b835-44c7-8569-9905f4617211");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "80859a69-427c-406f-a958-de38b855d572");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c403b29e-ff07-4e52-976a-83e2d0ddf0be");

            migrationBuilder.AlterColumn<int>(
                name: "ProductCenterColorSizeId",
                table: "ProductShopCarts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "48b7fcd7-1476-476f-9a26-71b3539eb137", null, "user", "USER" },
                    { "80744d75-98b4-40b8-9e7d-b779123c3b51", null, "employee", "EMPLOYEE" },
                    { "ee4c28d7-e243-4330-8ee3-6957be4e313a", null, "manager", "MANAGER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "48b7fcd7-1476-476f-9a26-71b3539eb137");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "80744d75-98b4-40b8-9e7d-b779123c3b51");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ee4c28d7-e243-4330-8ee3-6957be4e313a");

            migrationBuilder.AlterColumn<int>(
                name: "ProductCenterColorSizeId",
                table: "ProductShopCarts",
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
                    { "70ad459f-b835-44c7-8569-9905f4617211", null, "manager", "MANAGER" },
                    { "80859a69-427c-406f-a958-de38b855d572", null, "employee", "EMPLOYEE" },
                    { "c403b29e-ff07-4e52-976a-83e2d0ddf0be", null, "user", "USER" }
                });
        }
    }
}
