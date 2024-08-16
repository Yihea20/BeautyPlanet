using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class PersonCommit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "12826790-0703-4e8e-b897-c3cb6f43c431");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "58ae6e58-2ca8-4bf2-84da-135d666dc364");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fb04eaa1-cf15-46bc-842c-cdc31da99934");

            migrationBuilder.AddColumn<string>(
                name: "AdminId",
                table: "Comments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9b8bc817-adb2-4bf4-b92d-c33414de81fe", null, "manager", "MANAGER" },
                    { "da5f5ae4-d0ac-4373-a647-d2d9f30f521f", null, "user", "USER" },
                    { "f7427e09-1529-4446-909d-9e716c227943", null, "employee", "EMPLOYEE" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AdminId",
                table: "Comments",
                column: "AdminId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Admins_AdminId",
                table: "Comments",
                column: "AdminId",
                principalTable: "Admins",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Admins_AdminId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_AdminId",
                table: "Comments");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9b8bc817-adb2-4bf4-b92d-c33414de81fe");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "da5f5ae4-d0ac-4373-a647-d2d9f30f521f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f7427e09-1529-4446-909d-9e716c227943");

            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "Comments");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "12826790-0703-4e8e-b897-c3cb6f43c431", null, "user", "USER" },
                    { "58ae6e58-2ca8-4bf2-84da-135d666dc364", null, "manager", "MANAGER" },
                    { "fb04eaa1-cf15-46bc-842c-cdc31da99934", null, "employee", "EMPLOYEE" }
                });
        }
    }
}
