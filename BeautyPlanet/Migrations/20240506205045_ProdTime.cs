using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class ProdTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "798b40d0-b2e5-4be6-8671-0711708855b6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9901efce-c318-4dfe-a95c-8a58f14ccec6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d0c4cd8a-223c-4ffb-b71a-7193392a9080");

            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "Reviews",
                newName: "ReviewAddTime");

            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "Products",
                newName: "ProductAddTime");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "496e9d64-4b79-477a-9724-7653ca6e709c", null, "manager", "MANAGER" },
                    { "4d5dc08c-13ea-431d-9990-6b30edf82a06", null, "employee", "EMPLOYEE" },
                    { "e59d36f7-448f-40f1-9b33-8f5e06f6b8e4", null, "user", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "496e9d64-4b79-477a-9724-7653ca6e709c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d5dc08c-13ea-431d-9990-6b30edf82a06");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e59d36f7-448f-40f1-9b33-8f5e06f6b8e4");

            migrationBuilder.RenameColumn(
                name: "ReviewAddTime",
                table: "Reviews",
                newName: "DateTime");

            migrationBuilder.RenameColumn(
                name: "ProductAddTime",
                table: "Products",
                newName: "DateTime");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "798b40d0-b2e5-4be6-8671-0711708855b6", null, "employee", "EMPLOYEE" },
                    { "9901efce-c318-4dfe-a95c-8a58f14ccec6", null, "manager", "MANAGER" },
                    { "d0c4cd8a-223c-4ffb-b71a-7193392a9080", null, "user", "USER" }
                });
        }
    }
}
