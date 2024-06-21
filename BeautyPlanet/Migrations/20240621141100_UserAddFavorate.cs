using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class UserAddFavorate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favorate_Centers_CenterId",
                table: "Favorate");

            migrationBuilder.DropForeignKey(
                name: "FK_Favorate_Users_UserId",
                table: "Favorate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Favorate",
                table: "Favorate");

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

            migrationBuilder.RenameTable(
                name: "Favorate",
                newName: "Favorates");

            migrationBuilder.RenameIndex(
                name: "IX_Favorate_UserId",
                table: "Favorates",
                newName: "IX_Favorates_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Favorate_CenterId_UserId",
                table: "Favorates",
                newName: "IX_Favorates_CenterId_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Favorates",
                table: "Favorates",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "33b6aec2-8827-4240-be8d-3ea8eb699542", null, "user", "USER" },
                    { "b7fc7432-2464-4eae-9edc-0d2aff7a25b0", null, "employee", "EMPLOYEE" },
                    { "e96c7176-31b8-46c3-9701-3e383c33ca4d", null, "manager", "MANAGER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Favorates_Centers_CenterId",
                table: "Favorates",
                column: "CenterId",
                principalTable: "Centers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Favorates_Users_UserId",
                table: "Favorates",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favorates_Centers_CenterId",
                table: "Favorates");

            migrationBuilder.DropForeignKey(
                name: "FK_Favorates_Users_UserId",
                table: "Favorates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Favorates",
                table: "Favorates");

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

            migrationBuilder.RenameTable(
                name: "Favorates",
                newName: "Favorate");

            migrationBuilder.RenameIndex(
                name: "IX_Favorates_UserId",
                table: "Favorate",
                newName: "IX_Favorate_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Favorates_CenterId_UserId",
                table: "Favorate",
                newName: "IX_Favorate_CenterId_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Favorate",
                table: "Favorate",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "33349f01-dea5-4a7e-82a4-4ce362b4646c", null, "user", "USER" },
                    { "44e4077d-1ece-4dbe-b05b-7a708f896269", null, "employee", "EMPLOYEE" },
                    { "99b2f41e-9cea-445d-b2b6-0b5a22128bdd", null, "manager", "MANAGER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Favorate_Centers_CenterId",
                table: "Favorate",
                column: "CenterId",
                principalTable: "Centers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Favorate_Users_UserId",
                table: "Favorate",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
