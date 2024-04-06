using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class New : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7e2d2c83-035b-407e-903e-9277bdc1b154");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "875a9118-48b4-431c-9852-6c2858a03a90");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ca9f7b46-6084-4c61-a312-a3d3d2138517");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "57bb07fc-0422-418a-b3ed-551c6019fa9a", null, "user", "USER" },
                    { "7994be45-a477-4451-b3cd-816d83b853b9", null, "employee", "EMPLOYEE" },
                    { "a7065377-3a4c-4daa-8ac7-c050e50a93ad", null, "manager", "MANAGER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "57bb07fc-0422-418a-b3ed-551c6019fa9a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7994be45-a477-4451-b3cd-816d83b853b9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a7065377-3a4c-4daa-8ac7-c050e50a93ad");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7e2d2c83-035b-407e-903e-9277bdc1b154", null, "employee", "EMPLOYEE" },
                    { "875a9118-48b4-431c-9852-6c2858a03a90", null, "manager", "MANAGER" },
                    { "ca9f7b46-6084-4c61-a312-a3d3d2138517", null, "user", "USER" }
                });
        }
    }
}
