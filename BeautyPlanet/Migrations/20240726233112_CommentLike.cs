using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class CommentLike : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9bae86e3-edfb-4868-a34d-253aa36aa52d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9c1564ad-f406-410a-8efb-9a117feef3e4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ba7055fb-c64b-4c8a-9b73-3da4c284a8c1");

            migrationBuilder.AddColumn<int>(
                name: "Like",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "078f7d68-6347-463e-b854-d1e27aa4e162", null, "manager", "MANAGER" },
                    { "10ff498e-31df-4ebc-859f-2a4755ab61ae", null, "user", "USER" },
                    { "348f10aa-ac95-4f8e-9853-737e6dec15cc", null, "employee", "EMPLOYEE" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "078f7d68-6347-463e-b854-d1e27aa4e162");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "10ff498e-31df-4ebc-859f-2a4755ab61ae");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "348f10aa-ac95-4f8e-9853-737e6dec15cc");

            migrationBuilder.DropColumn(
                name: "Like",
                table: "Comments");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9bae86e3-edfb-4868-a34d-253aa36aa52d", null, "employee", "EMPLOYEE" },
                    { "9c1564ad-f406-410a-8efb-9a117feef3e4", null, "manager", "MANAGER" },
                    { "ba7055fb-c64b-4c8a-9b73-3da4c284a8c1", null, "user", "USER" }
                });
        }
    }
}
