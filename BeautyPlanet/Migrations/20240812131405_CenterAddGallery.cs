using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class CenterAddGallery : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b9f30046-2a02-4789-bbcb-21bce4df5ec3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d1129a29-f7bb-4ca7-8772-a85a5b081b9f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d8a45d69-c197-4e0c-8b17-868a6c18c652");

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
                    { "1da0859c-2d34-4580-b8bf-496f0ac5b1a8", null, "user", "USER" },
                    { "691b7e9e-ee99-4557-8d90-3e4b66c3e6ec", null, "employee", "EMPLOYEE" },
                    { "ace52dd8-a6bb-4c43-8925-9022ec86d1d8", null, "manager", "MANAGER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1da0859c-2d34-4580-b8bf-496f0ac5b1a8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "691b7e9e-ee99-4557-8d90-3e4b66c3e6ec");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ace52dd8-a6bb-4c43-8925-9022ec86d1d8");

            migrationBuilder.DropColumn(
                name: "GalleryImage",
                table: "Centers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b9f30046-2a02-4789-bbcb-21bce4df5ec3", null, "manager", "MANAGER" },
                    { "d1129a29-f7bb-4ca7-8772-a85a5b081b9f", null, "user", "USER" },
                    { "d8a45d69-c197-4e0c-8b17-868a6c18c652", null, "employee", "EMPLOYEE" }
                });
        }
    }
}
