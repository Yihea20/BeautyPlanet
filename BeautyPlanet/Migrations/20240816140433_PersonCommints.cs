using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class PersonCommints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Admins_AdminId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Specialists_SpecialistId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Users_UserId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_AdminId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_SpecialistId",
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

            migrationBuilder.DropColumn(
                name: "SpecialistId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Comments",
                newName: "PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                newName: "IX_Comments_PersonId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "563d9858-6492-4f3a-96e3-c2cd1c55a5dd", null, "user", "USER" },
                    { "90b622a6-4af1-4b19-b781-8bb7f80314a4", null, "manager", "MANAGER" },
                    { "dd616dc2-90b5-4258-8cc2-eb6fa25c0e0c", null, "employee", "EMPLOYEE" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "563d9858-6492-4f3a-96e3-c2cd1c55a5dd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "90b622a6-4af1-4b19-b781-8bb7f80314a4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dd616dc2-90b5-4258-8cc2-eb6fa25c0e0c");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "Comments",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_PersonId",
                table: "Comments",
                newName: "IX_Comments_UserId");

            migrationBuilder.AddColumn<string>(
                name: "AdminId",
                table: "Comments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SpecialistId",
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

            migrationBuilder.CreateIndex(
                name: "IX_Comments_SpecialistId",
                table: "Comments",
                column: "SpecialistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Admins_AdminId",
                table: "Comments",
                column: "AdminId",
                principalTable: "Admins",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Specialists_SpecialistId",
                table: "Comments",
                column: "SpecialistId",
                principalTable: "Specialists",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Users_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
