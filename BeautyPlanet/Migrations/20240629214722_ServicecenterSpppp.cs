using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class ServicecenterSpppp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Centers_CenterId",
                table: "Appointments");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "95cb4b75-846a-460a-ad8d-b5780a143f42");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e291f1ef-f228-4635-9d35-e516be3f62c3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f653a9f0-42da-4143-9e48-6fec221346cc");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "57262702-00db-46f1-9244-5ed6c7c2e4d7", null, "employee", "EMPLOYEE" },
                    { "c0fd5f59-00e3-415c-a73e-3297d5c9b66c", null, "manager", "MANAGER" },
                    { "e78a9317-102b-41f5-83a6-0ab31c5b4321", null, "user", "USER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Centers_CenterId",
                table: "Appointments",
                column: "CenterId",
                principalTable: "Centers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Centers_CenterId",
                table: "Appointments");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "57262702-00db-46f1-9244-5ed6c7c2e4d7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c0fd5f59-00e3-415c-a73e-3297d5c9b66c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e78a9317-102b-41f5-83a6-0ab31c5b4321");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "95cb4b75-846a-460a-ad8d-b5780a143f42", null, "user", "USER" },
                    { "e291f1ef-f228-4635-9d35-e516be3f62c3", null, "employee", "EMPLOYEE" },
                    { "f653a9f0-42da-4143-9e48-6fec221346cc", null, "manager", "MANAGER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Centers_CenterId",
                table: "Appointments",
                column: "CenterId",
                principalTable: "Centers",
                principalColumn: "Id");
        }
    }
}
