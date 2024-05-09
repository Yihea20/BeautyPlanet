using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class Specialization : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "Specialization",
                table: "Specialists",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1ad86769-02d6-486d-9407-6bcae71aff2d", null, "manager", "MANAGER" },
                    { "4587c241-246b-45ec-9a9a-181ede3c5106", null, "employee", "EMPLOYEE" },
                    { "4aedc616-8ddd-48f8-854d-fbfe7b7c37c7", null, "user", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ad86769-02d6-486d-9407-6bcae71aff2d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4587c241-246b-45ec-9a9a-181ede3c5106");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4aedc616-8ddd-48f8-854d-fbfe7b7c37c7");

            migrationBuilder.DropColumn(
                name: "Specialization",
                table: "Specialists");

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
    }
}
