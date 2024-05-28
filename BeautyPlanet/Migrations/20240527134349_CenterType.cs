using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class CenterType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "086180c4-0338-44df-a7bb-d3ba06567ee9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29412027-0c6f-497c-a6ab-41e4821bee76");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29b9d59a-536f-4a86-b359-e27fad3f24d6");

            migrationBuilder.CreateTable(
                name: "CenterTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CenterTypes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "30389630-b715-41b5-8348-5a9913503b23", null, "manager", "MANAGER" },
                    { "65abfed1-1ef7-410e-b8f3-83235f27dd66", null, "employee", "EMPLOYEE" },
                    { "769ee941-193d-4968-bcc2-a71b80acb30c", null, "user", "USER" }
                });

            migrationBuilder.InsertData(
                table: "CenterTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "BeautyCenter" },
                    { 2, "Store" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CenterTypes");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "30389630-b715-41b5-8348-5a9913503b23");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65abfed1-1ef7-410e-b8f3-83235f27dd66");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "769ee941-193d-4968-bcc2-a71b80acb30c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "086180c4-0338-44df-a7bb-d3ba06567ee9", null, "manager", "MANAGER" },
                    { "29412027-0c6f-497c-a6ab-41e4821bee76", null, "user", "USER" },
                    { "29b9d59a-536f-4a86-b359-e27fad3f24d6", null, "employee", "EMPLOYEE" }
                });
        }
    }
}
