using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class SaveLikePostSpecialist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Users_UserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPosts_Users_UserId",
                table: "UserPosts");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSavedPosts_Users_UserId",
                table: "UserSavedPosts");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "503fcf53-d172-4692-98f7-830deedfb207");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7a64b96b-89f9-4b0a-8820-a420805388f4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4c09368-d4c8-4d5f-9443-3e241b68f599");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserSavedPosts",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "SpecialistId",
                table: "UserSavedPosts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserPosts",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "SpecialistId",
                table: "UserPosts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserComments",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "SpecialistId",
                table: "UserComments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Comments",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

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
                    { "12826790-0703-4e8e-b897-c3cb6f43c431", null, "user", "USER" },
                    { "58ae6e58-2ca8-4bf2-84da-135d666dc364", null, "manager", "MANAGER" },
                    { "fb04eaa1-cf15-46bc-842c-cdc31da99934", null, "employee", "EMPLOYEE" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserSavedPosts_SpecialistId_PostId",
                table: "UserSavedPosts",
                columns: new[] { "SpecialistId", "PostId" });

            migrationBuilder.CreateIndex(
                name: "IX_UserPosts_SpecialistId_PostId",
                table: "UserPosts",
                columns: new[] { "SpecialistId", "PostId" });

            migrationBuilder.CreateIndex(
                name: "IX_UserComments_SpecialistId_CommentId",
                table: "UserComments",
                columns: new[] { "SpecialistId", "CommentId" });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_SpecialistId",
                table: "Comments",
                column: "SpecialistId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_UserComments_Specialists_SpecialistId",
                table: "UserComments",
                column: "SpecialistId",
                principalTable: "Specialists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPosts_Specialists_SpecialistId",
                table: "UserPosts",
                column: "SpecialistId",
                principalTable: "Specialists",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserPosts_Users_UserId",
                table: "UserPosts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserSavedPosts_Specialists_SpecialistId",
                table: "UserSavedPosts",
                column: "SpecialistId",
                principalTable: "Specialists",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserSavedPosts_Users_UserId",
                table: "UserSavedPosts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Specialists_SpecialistId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Users_UserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_UserComments_Specialists_SpecialistId",
                table: "UserComments");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPosts_Specialists_SpecialistId",
                table: "UserPosts");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPosts_Users_UserId",
                table: "UserPosts");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSavedPosts_Specialists_SpecialistId",
                table: "UserSavedPosts");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSavedPosts_Users_UserId",
                table: "UserSavedPosts");

            migrationBuilder.DropIndex(
                name: "IX_UserSavedPosts_SpecialistId_PostId",
                table: "UserSavedPosts");

            migrationBuilder.DropIndex(
                name: "IX_UserPosts_SpecialistId_PostId",
                table: "UserPosts");

            migrationBuilder.DropIndex(
                name: "IX_UserComments_SpecialistId_CommentId",
                table: "UserComments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_SpecialistId",
                table: "Comments");

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

            migrationBuilder.DropColumn(
                name: "SpecialistId",
                table: "UserSavedPosts");

            migrationBuilder.DropColumn(
                name: "SpecialistId",
                table: "UserPosts");

            migrationBuilder.DropColumn(
                name: "SpecialistId",
                table: "UserComments");

            migrationBuilder.DropColumn(
                name: "SpecialistId",
                table: "Comments");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserSavedPosts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserPosts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserComments",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Comments",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "503fcf53-d172-4692-98f7-830deedfb207", null, "employee", "EMPLOYEE" },
                    { "7a64b96b-89f9-4b0a-8820-a420805388f4", null, "user", "USER" },
                    { "e4c09368-d4c8-4d5f-9443-3e241b68f599", null, "manager", "MANAGER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Users_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPosts_Users_UserId",
                table: "UserPosts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserSavedPosts_Users_UserId",
                table: "UserSavedPosts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
