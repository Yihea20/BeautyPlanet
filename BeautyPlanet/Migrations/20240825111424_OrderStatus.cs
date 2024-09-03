using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class OrderStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCarts_Statuses_StatusId",
                table: "ShoppingCarts");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "588850e3-696b-4509-9924-263ed3a5f50d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8830c0bd-650c-4ac6-9acc-132cfe601a9e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e5d2fb10-cc79-44e5-919b-5213af28cb3d");

            migrationBuilder.RenameColumn(
                name: "StatusId",
                table: "ShoppingCarts",
                newName: "OrderStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCarts_StatusId",
                table: "ShoppingCarts",
                newName: "IX_ShoppingCarts_OrderStatusId");

            migrationBuilder.CreateTable(
                name: "OrderStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatuses", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5436fb27-cf9a-46da-9b62-264d2b1983b9", null, "manager", "MANAGER" },
                    { "9efe0f00-6f14-46fb-935a-23ea9adf3bed", null, "employee", "EMPLOYEE" },
                    { "f43fe8fd-147e-482b-8153-f4069ccfaf9b", null, "user", "USER" }
                });

            migrationBuilder.InsertData(
                table: "OrderStatuses",
                columns: new[] { "Id", "Status" },
                values: new object[,]
                {
                    { 1, "UnPaid" },
                    { 2, "Processing" },
                    { 3, "Shipped" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCarts_OrderStatuses_OrderStatusId",
                table: "ShoppingCarts",
                column: "OrderStatusId",
                principalTable: "OrderStatuses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCarts_OrderStatuses_OrderStatusId",
                table: "ShoppingCarts");

            migrationBuilder.DropTable(
                name: "OrderStatuses");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5436fb27-cf9a-46da-9b62-264d2b1983b9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9efe0f00-6f14-46fb-935a-23ea9adf3bed");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f43fe8fd-147e-482b-8153-f4069ccfaf9b");

            migrationBuilder.RenameColumn(
                name: "OrderStatusId",
                table: "ShoppingCarts",
                newName: "StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCarts_OrderStatusId",
                table: "ShoppingCarts",
                newName: "IX_ShoppingCarts_StatusId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "588850e3-696b-4509-9924-263ed3a5f50d", null, "employee", "EMPLOYEE" },
                    { "8830c0bd-650c-4ac6-9acc-132cfe601a9e", null, "user", "USER" },
                    { "e5d2fb10-cc79-44e5-919b-5213af28cb3d", null, "manager", "MANAGER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCarts_Statuses_StatusId",
                table: "ShoppingCarts",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id");
        }
    }
}
