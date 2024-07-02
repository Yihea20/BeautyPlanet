using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class CenterGAlleryDTOlistdel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "31eb80b5-9644-45a5-a0c2-2683c90a3a82");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7544ecbd-77bb-4653-b709-23a8687b3661");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9bed8597-bff4-4e94-ac90-9b9b13f53747");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a0eb5c9e-ef5d-4e6f-b6ac-2b968d944d51", null, "employee", "EMPLOYEE" },
                    { "c67cabc3-3077-4a22-84ce-f690a70f8c05", null, "manager", "MANAGER" },
                    { "d89397c6-2f9f-4b50-9f5c-63acec2451bc", null, "user", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a0eb5c9e-ef5d-4e6f-b6ac-2b968d944d51");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c67cabc3-3077-4a22-84ce-f690a70f8c05");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d89397c6-2f9f-4b50-9f5c-63acec2451bc");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "31eb80b5-9644-45a5-a0c2-2683c90a3a82", null, "employee", "EMPLOYEE" },
                    { "7544ecbd-77bb-4653-b709-23a8687b3661", null, "manager", "MANAGER" },
                    { "9bed8597-bff4-4e94-ac90-9b9b13f53747", null, "user", "USER" }
                });
        }
    }
}
