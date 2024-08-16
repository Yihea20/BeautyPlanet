using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class OfferPrice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_ServiceCenters_ServiceCenterId",
                table: "Offers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "82aa2008-e372-46f4-9985-b5c9301a0e44");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dd8d28e1-b454-41b2-a684-8f9381e31622");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f0095b63-eda5-481a-9da9-b58adf183a17");

            migrationBuilder.AlterColumn<int>(
                name: "ServiceCenterId",
                table: "Offers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Offers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "503fcf53-d172-4692-98f7-830deedfb207", null, "employee", "EMPLOYEE" },
                    { "7a64b96b-89f9-4b0a-8820-a420805388f4", null, "user", "USER" },
                    { "e4c09368-d4c8-4d5f-9443-3e241b68f599", null, "manager", "MANAGER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_ServiceCenters_ServiceCenterId",
                table: "Offers",
                column: "ServiceCenterId",
                principalTable: "ServiceCenters",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_ServiceCenters_ServiceCenterId",
                table: "Offers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "503fcf53-d172-4692-98f7-830deedfb207");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7a64b96b-89f9-4b0a-8820-a420805388f4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4c09368-d4c8-4d5f-9443-3e241b68f599");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Offers");

            migrationBuilder.AlterColumn<int>(
                name: "ServiceCenterId",
                table: "Offers",
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
                    { "82aa2008-e372-46f4-9985-b5c9301a0e44", null, "employee", "EMPLOYEE" },
                    { "dd8d28e1-b454-41b2-a684-8f9381e31622", null, "manager", "MANAGER" },
                    { "f0095b63-eda5-481a-9da9-b58adf183a17", null, "user", "USER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_ServiceCenters_ServiceCenterId",
                table: "Offers",
                column: "ServiceCenterId",
                principalTable: "ServiceCenters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
