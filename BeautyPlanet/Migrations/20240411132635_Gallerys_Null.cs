using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class Gallerys_Null : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03fcbee7-2043-4645-af01-023e221fd1c0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "994c8b6b-9863-4d88-a88c-c58db037a3f6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b626c810-3259-4ced-b85d-fdfa4fcb1513");

            migrationBuilder.AlterColumn<string>(
                name: "ImagesUrl",
                table: "Galleries",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2b20c4bc-c146-47cd-93d7-1fd7e14a916a", null, "user", "USER" },
                    { "44c552ba-13eb-4cbf-b72f-da23ffca5c27", null, "manager", "MANAGER" },
                    { "460d542a-a18b-4feb-89d6-0651bcbd551e", null, "employee", "EMPLOYEE" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2b20c4bc-c146-47cd-93d7-1fd7e14a916a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44c552ba-13eb-4cbf-b72f-da23ffca5c27");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "460d542a-a18b-4feb-89d6-0651bcbd551e");

            migrationBuilder.AlterColumn<string>(
                name: "ImagesUrl",
                table: "Galleries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "03fcbee7-2043-4645-af01-023e221fd1c0", null, "user", "USER" },
                    { "994c8b6b-9863-4d88-a88c-c58db037a3f6", null, "manager", "MANAGER" },
                    { "b626c810-3259-4ced-b85d-fdfa4fcb1513", null, "employee", "EMPLOYEE" }
                });
        }
    }
}
