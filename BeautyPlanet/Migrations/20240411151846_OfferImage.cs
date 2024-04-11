using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class OfferImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "37049f78-d5dc-4c84-9231-23f2edd1067e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5a1bb790-6e0f-4d1b-b440-6024a5f29257");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "af7be00c-4bcc-4e87-b699-29283aa4d444");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Offers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "18d43b35-5226-4582-bb2d-e59cb4163f56", null, "manager", "MANAGER" },
                    { "e3edadde-4349-4c29-9510-23c5eecbb3ef", null, "user", "USER" },
                    { "f80d2786-0677-4cfd-af1d-e5f6ce25c687", null, "employee", "EMPLOYEE" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18d43b35-5226-4582-bb2d-e59cb4163f56");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e3edadde-4349-4c29-9510-23c5eecbb3ef");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f80d2786-0677-4cfd-af1d-e5f6ce25c687");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Offers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "37049f78-d5dc-4c84-9231-23f2edd1067e", null, "user", "USER" },
                    { "5a1bb790-6e0f-4d1b-b440-6024a5f29257", null, "manager", "MANAGER" },
                    { "af7be00c-4bcc-4e87-b699-29283aa4d444", null, "employee", "EMPLOYEE" }
                });
        }
    }
}
