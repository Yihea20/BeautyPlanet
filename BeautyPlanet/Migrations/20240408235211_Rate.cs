using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class Rate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d2f4ae7-e927-449a-93d2-a0f488c15959");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ee4f7efc-1ffb-4452-ae51-8f20643ca405");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f31a7251-d956-4bee-85da-e3014306dafb");

            migrationBuilder.AddColumn<int>(
                name: "Rate",
                table: "Services",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3bde50fa-b9b2-4b83-870e-d5372845655a", null, "user", "USER" },
                    { "8c4a1588-98c7-402f-803b-c1210584140b", null, "employee", "EMPLOYEE" },
                    { "d6dc334e-5660-4f18-abc5-ac88ca0461a2", null, "manager", "MANAGER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3bde50fa-b9b2-4b83-870e-d5372845655a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8c4a1588-98c7-402f-803b-c1210584140b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d6dc334e-5660-4f18-abc5-ac88ca0461a2");

            migrationBuilder.DropColumn(
                name: "Rate",
                table: "Services");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4d2f4ae7-e927-449a-93d2-a0f488c15959", null, "user", "USER" },
                    { "ee4f7efc-1ffb-4452-ae51-8f20643ca405", null, "employee", "EMPLOYEE" },
                    { "f31a7251-d956-4bee-85da-e3014306dafb", null, "manager", "MANAGER" }
                });
        }
    }
}
