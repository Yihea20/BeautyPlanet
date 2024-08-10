using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class CAtegoryToAppointment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4e01f052-f0bc-402e-a185-a232e020a5f8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a676da4d-5fa5-4640-8232-39e8bbd68cd7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b8d1e998-235d-4f60-8ce1-bfca5aa8d8ed");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Appointments",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3e059785-1712-499f-ab0f-fa00f4a76675", null, "user", "USER" },
                    { "5ef1de4e-81ce-4ae3-9778-91a57ed3128b", null, "employee", "EMPLOYEE" },
                    { "b7468a87-e1a4-4eae-b527-1ecc4995aa16", null, "manager", "MANAGER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_CategoryId",
                table: "Appointments",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Categories_CategoryId",
                table: "Appointments",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Categories_CategoryId",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_CategoryId",
                table: "Appointments");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3e059785-1712-499f-ab0f-fa00f4a76675");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5ef1de4e-81ce-4ae3-9778-91a57ed3128b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7468a87-e1a4-4eae-b527-1ecc4995aa16");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Appointments");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4e01f052-f0bc-402e-a185-a232e020a5f8", null, "employee", "EMPLOYEE" },
                    { "a676da4d-5fa5-4640-8232-39e8bbd68cd7", null, "user", "USER" },
                    { "b8d1e998-235d-4f60-8ce1-bfca5aa8d8ed", null, "manager", "MANAGER" }
                });
        }
    }
}
