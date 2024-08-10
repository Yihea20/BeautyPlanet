using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class SavedPost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2483bb23-dde4-477e-9922-768f5f6353a9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3e117ec4-8897-4433-8b13-7ba47db1268d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e7200274-c86d-4712-a1e0-53ea55edf95a");

            migrationBuilder.CreateTable(
                name: "UserSavedPosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSavedPosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSavedPosts_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserSavedPosts_Users_UserId",
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
                    { "731babf8-9c40-449e-a7a7-c801579bc659", null, "user", "USER" },
                    { "ac55540e-24d0-4910-a7ce-54aa442a593c", null, "employee", "EMPLOYEE" },
                    { "c12b5373-826f-426c-8fd8-76f5d0854eed", null, "manager", "MANAGER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserSavedPosts_PostId",
                table: "UserSavedPosts",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSavedPosts_UserId_PostId",
                table: "UserSavedPosts",
                columns: new[] { "UserId", "PostId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserSavedPosts");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "731babf8-9c40-449e-a7a7-c801579bc659");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ac55540e-24d0-4910-a7ce-54aa442a593c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c12b5373-826f-426c-8fd8-76f5d0854eed");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2483bb23-dde4-477e-9922-768f5f6353a9", null, "employee", "EMPLOYEE" },
                    { "3e117ec4-8897-4433-8b13-7ba47db1268d", null, "user", "USER" },
                    { "e7200274-c86d-4712-a1e0-53ea55edf95a", null, "manager", "MANAGER" }
                });
        }
    }
}
