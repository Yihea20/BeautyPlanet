using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class location : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "45aaf535-b721-45eb-88e5-4ffbbb49df32");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7bf710b7-d420-454c-9742-29dab6bd1f86");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "867030ec-f352-44f0-a814-a754e2f62f03");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Specialists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Admins",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "17efe2a9-f7cd-4453-b2fb-9daaaa62a60a", null, "employee", "EMPLOYEE" },
                    { "1b8fc781-691d-4b33-b189-c0192b248c0d", null, "user", "USER" },
                    { "cd0ceb95-c251-4815-9b1c-f42595a48cb6", null, "manager", "MANAGER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "17efe2a9-f7cd-4453-b2fb-9daaaa62a60a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b8fc781-691d-4b33-b189-c0192b248c0d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cd0ceb95-c251-4815-9b1c-f42595a48cb6");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Specialists");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Admins");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "45aaf535-b721-45eb-88e5-4ffbbb49df32", null, "employee", "EMPLOYEE" },
                    { "7bf710b7-d420-454c-9742-29dab6bd1f86", null, "manager", "MANAGER" },
                    { "867030ec-f352-44f0-a814-a754e2f62f03", null, "user", "USER" }
                });
        }
    }
}
