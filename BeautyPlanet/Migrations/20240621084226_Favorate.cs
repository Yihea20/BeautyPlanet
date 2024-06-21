using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class Favorate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Centers_Users_UserId",
                table: "Centers");

            migrationBuilder.DropIndex(
                name: "IX_Centers_UserId",
                table: "Centers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8d107c00-d675-4eb2-b221-37fde33d14ca");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f3fa0a34-9fa4-4504-8fa8-5c9e3b4c39be");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fc8b965d-8bde-4a99-ab2b-76f499db59a1");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Centers");

            migrationBuilder.CreateTable(
                name: "Favorate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CenterId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Favorate_Centers_CenterId",
                        column: x => x.CenterId,
                        principalTable: "Centers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Favorate_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "33349f01-dea5-4a7e-82a4-4ce362b4646c", null, "user", "USER" },
                    { "44e4077d-1ece-4dbe-b05b-7a708f896269", null, "employee", "EMPLOYEE" },
                    { "99b2f41e-9cea-445d-b2b6-0b5a22128bdd", null, "manager", "MANAGER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Favorate_CenterId_UserId",
                table: "Favorate",
                columns: new[] { "CenterId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_Favorate_UserId",
                table: "Favorate",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Favorate");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "33349f01-dea5-4a7e-82a4-4ce362b4646c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44e4077d-1ece-4dbe-b05b-7a708f896269");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99b2f41e-9cea-445d-b2b6-0b5a22128bdd");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Centers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8d107c00-d675-4eb2-b221-37fde33d14ca", null, "user", "USER" },
                    { "f3fa0a34-9fa4-4504-8fa8-5c9e3b4c39be", null, "manager", "MANAGER" },
                    { "fc8b965d-8bde-4a99-ab2b-76f499db59a1", null, "employee", "EMPLOYEE" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Centers_UserId",
                table: "Centers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Centers_Users_UserId",
                table: "Centers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
