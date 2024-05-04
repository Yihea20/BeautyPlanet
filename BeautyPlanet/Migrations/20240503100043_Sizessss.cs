using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class Sizessss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Sizes_SizessId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_SizessId",
                table: "Products");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "999af68a-2c1e-485a-a868-c5e18f94e859");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a79f5786-7867-4ee3-a514-a718252bc9e9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c9f4bcff-9a3d-4b56-93d8-f9dbd2510c00");

            migrationBuilder.DropColumn(
                name: "SizeId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SizessId",
                table: "Products");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1e15967f-cbfc-4ad2-8e5c-86c2acc46541", null, "user", "USER" },
                    { "28f76d49-a5ad-45b1-bebf-5510a9c360ea", null, "employee", "EMPLOYEE" },
                    { "8a38acf9-d513-48b6-bae8-9827f0fe52a6", null, "manager", "MANAGER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1e15967f-cbfc-4ad2-8e5c-86c2acc46541");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "28f76d49-a5ad-45b1-bebf-5510a9c360ea");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8a38acf9-d513-48b6-bae8-9827f0fe52a6");

            migrationBuilder.AddColumn<int>(
                name: "SizeId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SizessId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "999af68a-2c1e-485a-a868-c5e18f94e859", null, "manager", "MANAGER" },
                    { "a79f5786-7867-4ee3-a514-a718252bc9e9", null, "user", "USER" },
                    { "c9f4bcff-9a3d-4b56-93d8-f9dbd2510c00", null, "employee", "EMPLOYEE" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_SizessId",
                table: "Products",
                column: "SizessId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Sizes_SizessId",
                table: "Products",
                column: "SizessId",
                principalTable: "Sizes",
                principalColumn: "Id");
        }
    }
}
