using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class ProdSizeColors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ad78a1f-3ba5-4633-897d-cbd192b49ac9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "802fa45a-ef25-41c8-af1e-07dc42911f74");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9328874d-9479-4cab-8a87-d687526af4e0");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0f4da1d8-7346-4dda-9b93-4f92baf4b23b", null, "manager", "MANAGER" },
                    { "562b997a-7981-4ad4-a29b-8fd5663ea921", null, "user", "USER" },
                    { "68436629-d951-4543-870a-9f120b8d4660", null, "employee", "EMPLOYEE" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f4da1d8-7346-4dda-9b93-4f92baf4b23b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "562b997a-7981-4ad4-a29b-8fd5663ea921");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "68436629-d951-4543-870a-9f120b8d4660");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1ad78a1f-3ba5-4633-897d-cbd192b49ac9", null, "employee", "EMPLOYEE" },
                    { "802fa45a-ef25-41c8-af1e-07dc42911f74", null, "manager", "MANAGER" },
                    { "9328874d-9479-4cab-8a87-d687526af4e0", null, "user", "USER" }
                });
        }
    }
}
