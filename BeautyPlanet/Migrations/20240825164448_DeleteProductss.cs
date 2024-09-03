using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class DeleteProductss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d4da3bf-6b84-4a28-a0c3-96408f0b0dc0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6bcfb63a-da10-42a9-b5cf-6aeb00a65909");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7fca8912-1eb7-4133-9ac5-b62570149702");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2d4da3bf-6b84-4a28-a0c3-96408f0b0dc0", null, "employee", "EMPLOYEE" },
                    { "6bcfb63a-da10-42a9-b5cf-6aeb00a65909", null, "manager", "MANAGER" },
                    { "7fca8912-1eb7-4133-9ac5-b62570149702", null, "user", "USER" }
                });
        }
    }
}
