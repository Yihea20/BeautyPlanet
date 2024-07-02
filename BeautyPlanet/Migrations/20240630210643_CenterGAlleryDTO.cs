using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class CenterGAlleryDTO : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Centers_Galleries_GalaryId",
                table: "Centers");

            migrationBuilder.DropIndex(
                name: "IX_Centers_GalaryId",
                table: "Centers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "09c29847-2cb5-4ebd-9b28-b9433689280a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6708e340-4a61-4afd-a439-33fc6a3f2836");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9b96a4ed-15cb-40c4-bf5a-e90b9f05a762");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Centers");

            migrationBuilder.DropColumn(
                name: "GalaryId",
                table: "Centers");

            migrationBuilder.AddColumn<string>(
                name: "GalleryImage",
                table: "Centers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6536e6f6-7e27-4fba-baf4-cc1a26e7fedb", null, "manager", "MANAGER" },
                    { "8174159e-47c1-4cf0-8c34-ebd20feb70f0", null, "employee", "EMPLOYEE" },
                    { "f6abb440-0fa2-4776-8a8c-e42c7ff24682", null, "user", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6536e6f6-7e27-4fba-baf4-cc1a26e7fedb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8174159e-47c1-4cf0-8c34-ebd20feb70f0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f6abb440-0fa2-4776-8a8c-e42c7ff24682");

            migrationBuilder.DropColumn(
                name: "GalleryImage",
                table: "Centers");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Centers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GalaryId",
                table: "Centers",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "09c29847-2cb5-4ebd-9b28-b9433689280a", null, "employee", "EMPLOYEE" },
                    { "6708e340-4a61-4afd-a439-33fc6a3f2836", null, "manager", "MANAGER" },
                    { "9b96a4ed-15cb-40c4-bf5a-e90b9f05a762", null, "user", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Centers_GalaryId",
                table: "Centers",
                column: "GalaryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Centers_Galleries_GalaryId",
                table: "Centers",
                column: "GalaryId",
                principalTable: "Galleries",
                principalColumn: "Id");
        }
    }
}
