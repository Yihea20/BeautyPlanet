using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class LikePosetDislike : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "82a6ae98-9c9a-4348-9f88-6e486ca8bef6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "89ab2b90-2bdf-4d4f-8ee9-9a2f142cb563");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b6728e01-09db-4102-8ad5-7b4cbf092868");

            migrationBuilder.CreateTable(
                name: "UserPost",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPost", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserPost_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPost_Users_UserId",
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
                    { "1d7188f0-f6ca-4939-b5e9-1f7f1b271b9f", null, "manager", "MANAGER" },
                    { "8ce85cbd-9779-43a1-9e99-7024db80d4b8", null, "employee", "EMPLOYEE" },
                    { "e32ab9fe-e7c3-4cb4-a53d-bb83a8df029a", null, "user", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserPost_PostId",
                table: "UserPost",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPost_UserId_PostId",
                table: "UserPost",
                columns: new[] { "UserId", "PostId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserPost");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1d7188f0-f6ca-4939-b5e9-1f7f1b271b9f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8ce85cbd-9779-43a1-9e99-7024db80d4b8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e32ab9fe-e7c3-4cb4-a53d-bb83a8df029a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "82a6ae98-9c9a-4348-9f88-6e486ca8bef6", null, "employee", "EMPLOYEE" },
                    { "89ab2b90-2bdf-4d4f-8ee9-9a2f142cb563", null, "manager", "MANAGER" },
                    { "b6728e01-09db-4102-8ad5-7b4cbf092868", null, "user", "USER" }
                });
        }
    }
}
