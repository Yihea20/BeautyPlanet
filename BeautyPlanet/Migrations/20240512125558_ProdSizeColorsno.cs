using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class ProdSizeColorsno : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "0dccb934-dd3b-467f-88a8-ecf38381ef25", null, "manager", "MANAGER" },
                    { "2f1b55ce-5d0b-47bb-8695-45d379340f60", null, "employee", "EMPLOYEE" },
                    { "9c2cfcad-6af2-494c-b379-749f4a944fcf", null, "user", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 10000, "No Color" });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 10000, "No Size" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0dccb934-dd3b-467f-88a8-ecf38381ef25");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2f1b55ce-5d0b-47bb-8695-45d379340f60");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9c2cfcad-6af2-494c-b379-749f4a944fcf");

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 10000);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 10000);

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
    }
}
