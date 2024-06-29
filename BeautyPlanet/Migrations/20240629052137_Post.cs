using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class Post : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "83a7d6b7-bdf7-4c2e-b547-2d68009136df");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "85f7ed6c-24df-4d76-926f-0c790119cc9a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "90787224-7e16-4dd3-9e3c-36f593d27d9d");

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CenterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Centers_CenterId",
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
                    { "9c05f89f-ba0b-4b43-9127-6854443ae376", null, "employee", "EMPLOYEE" },
                    { "eda6d60e-e183-4c67-804d-b0b94d849c7f", null, "user", "USER" },
                    { "f524c67f-1d25-4aa1-bccd-e897af20115c", null, "manager", "MANAGER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CenterId",
                table: "Posts",
                column: "CenterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9c05f89f-ba0b-4b43-9127-6854443ae376");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eda6d60e-e183-4c67-804d-b0b94d849c7f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f524c67f-1d25-4aa1-bccd-e897af20115c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "83a7d6b7-bdf7-4c2e-b547-2d68009136df", null, "employee", "EMPLOYEE" },
                    { "85f7ed6c-24df-4d76-926f-0c790119cc9a", null, "user", "USER" },
                    { "90787224-7e16-4dd3-9e3c-36f593d27d9d", null, "manager", "MANAGER" }
                });
        }
    }
}
