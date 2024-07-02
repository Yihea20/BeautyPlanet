using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class CenterGAlleryDTOlistdell : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "GalleryImage",
                table: "Centers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2ad35571-7569-4845-b06f-127ec33c9dde", null, "employee", "EMPLOYEE" },
                    { "a187c74c-73aa-4ea1-91c3-93eca299be55", null, "manager", "MANAGER" },
                    { "bcdc3526-20cb-416a-b431-ed30d1ad6c93", null, "user", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2ad35571-7569-4845-b06f-127ec33c9dde");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a187c74c-73aa-4ea1-91c3-93eca299be55");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bcdc3526-20cb-416a-b431-ed30d1ad6c93");

            migrationBuilder.AddColumn<string>(
                name: "GalleryImage",
                table: "Centers",
                type: "nvarchar(max)",
                nullable: true);

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
    }
}
