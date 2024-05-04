using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class ListImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "23d0533e-f657-49c2-bb4a-f546b6bb465b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "92d64613-21fb-402e-aaa3-ec3bcda83ec4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a861e5a3-31f8-44c8-8a45-5c4aebf5b358");

            migrationBuilder.CreateTable(
                name: "ListImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListImages", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "548e134d-4d6e-4f8b-bd52-da27b0b6819f", null, "user", "USER" },
                    { "94344c28-56c1-4df7-b24d-d0042166d9ae", null, "manager", "MANAGER" },
                    { "d68a6d57-2afe-4913-9615-7c874e46b717", null, "employee", "EMPLOYEE" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ListImages");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "548e134d-4d6e-4f8b-bd52-da27b0b6819f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94344c28-56c1-4df7-b24d-d0042166d9ae");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d68a6d57-2afe-4913-9615-7c874e46b717");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "23d0533e-f657-49c2-bb4a-f546b6bb465b", null, "employee", "EMPLOYEE" },
                    { "92d64613-21fb-402e-aaa3-ec3bcda83ec4", null, "manager", "MANAGER" },
                    { "a861e5a3-31f8-44c8-8a45-5c4aebf5b358", null, "user", "USER" }
                });
        }
    }
}
