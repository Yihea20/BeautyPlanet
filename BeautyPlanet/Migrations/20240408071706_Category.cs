using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class Category : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "73373710-6a27-4dba-8e58-f5f9de047cfd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "880bfd2e-9ee7-455d-9b49-473b85c9f2f5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aec0f5ff-1e7f-44c0-aefb-8630e0cf4d58");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Services");

            migrationBuilder.AlterColumn<string>(
                name: "ImageURL",
                table: "Services",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Services",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1bdcab70-5df8-4140-8297-6ab7865c8c29", null, "employee", "EMPLOYEE" },
                    { "2dbe6675-0848-4473-895b-1fbe1386b749", null, "manager", "MANAGER" },
                    { "ec70107c-f946-4786-98a6-b5c319cc3edc", null, "user", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Services_CategoryId",
                table: "Services",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Category_CategoryId",
                table: "Services",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_Category_CategoryId",
                table: "Services");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Services_CategoryId",
                table: "Services");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1bdcab70-5df8-4140-8297-6ab7865c8c29");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2dbe6675-0848-4473-895b-1fbe1386b749");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ec70107c-f946-4786-98a6-b5c319cc3edc");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Services");

            migrationBuilder.AlterColumn<string>(
                name: "ImageURL",
                table: "Services",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Services",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "73373710-6a27-4dba-8e58-f5f9de047cfd", null, "employee", "EMPLOYEE" },
                    { "880bfd2e-9ee7-455d-9b49-473b85c9f2f5", null, "user", "USER" },
                    { "aec0f5ff-1e7f-44c0-aefb-8630e0cf4d58", null, "manager", "MANAGER" }
                });
        }
    }
}
