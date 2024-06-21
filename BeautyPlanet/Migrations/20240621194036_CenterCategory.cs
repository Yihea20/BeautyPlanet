using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class CenterCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "33b6aec2-8827-4240-be8d-3ea8eb699542");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7fc7432-2464-4eae-9edc-0d2aff7a25b0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e96c7176-31b8-46c3-9701-3e383c33ca4d");

            migrationBuilder.CreateTable(
                name: "CenterCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CenterId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CenterCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CenterCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CenterCategories_Centers_CenterId",
                        column: x => x.CenterId,
                        principalTable: "Centers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3e72ec2a-7807-4ed7-b01f-15ae4869f756", null, "manager", "MANAGER" },
                    { "5b21c8d0-c358-4c0f-a1fa-9e118d0de4ff", null, "user", "USER" },
                    { "a650681f-eada-4cf9-9d1a-b25c8e23ad73", null, "employee", "EMPLOYEE" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CenterCategories_CategoryId",
                table: "CenterCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CenterCategories_CenterId_CategoryId",
                table: "CenterCategories",
                columns: new[] { "CenterId", "CategoryId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CenterCategories");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3e72ec2a-7807-4ed7-b01f-15ae4869f756");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5b21c8d0-c358-4c0f-a1fa-9e118d0de4ff");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a650681f-eada-4cf9-9d1a-b25c8e23ad73");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "33b6aec2-8827-4240-be8d-3ea8eb699542", null, "user", "USER" },
                    { "b7fc7432-2464-4eae-9edc-0d2aff7a25b0", null, "employee", "EMPLOYEE" },
                    { "e96c7176-31b8-46c3-9701-3e383c33ca4d", null, "manager", "MANAGER" }
                });
        }
    }
}
