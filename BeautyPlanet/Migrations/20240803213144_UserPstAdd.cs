using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class UserPstAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserPost_Posts_PostId",
                table: "UserPost");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPost_Users_UserId",
                table: "UserPost");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserPost",
                table: "UserPost");

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

            migrationBuilder.RenameTable(
                name: "UserPost",
                newName: "UserPosts");

            migrationBuilder.RenameIndex(
                name: "IX_UserPost_UserId_PostId",
                table: "UserPosts",
                newName: "IX_UserPosts_UserId_PostId");

            migrationBuilder.RenameIndex(
                name: "IX_UserPost_PostId",
                table: "UserPosts",
                newName: "IX_UserPosts_PostId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserPosts",
                table: "UserPosts",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ec488960-5ca6-4214-975e-e5bdef0eb939", null, "manager", "MANAGER" },
                    { "ed91f292-08c3-4f32-bc88-c59cf0465dd1", null, "employee", "EMPLOYEE" },
                    { "feecc0d2-41c1-413a-951d-401c1e6b3146", null, "user", "USER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_UserPosts_Posts_PostId",
                table: "UserPosts",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPosts_Users_UserId",
                table: "UserPosts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserPosts_Posts_PostId",
                table: "UserPosts");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPosts_Users_UserId",
                table: "UserPosts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserPosts",
                table: "UserPosts");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ec488960-5ca6-4214-975e-e5bdef0eb939");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ed91f292-08c3-4f32-bc88-c59cf0465dd1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "feecc0d2-41c1-413a-951d-401c1e6b3146");

            migrationBuilder.RenameTable(
                name: "UserPosts",
                newName: "UserPost");

            migrationBuilder.RenameIndex(
                name: "IX_UserPosts_UserId_PostId",
                table: "UserPost",
                newName: "IX_UserPost_UserId_PostId");

            migrationBuilder.RenameIndex(
                name: "IX_UserPosts_PostId",
                table: "UserPost",
                newName: "IX_UserPost_PostId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserPost",
                table: "UserPost",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1d7188f0-f6ca-4939-b5e9-1f7f1b271b9f", null, "manager", "MANAGER" },
                    { "8ce85cbd-9779-43a1-9e99-7024db80d4b8", null, "employee", "EMPLOYEE" },
                    { "e32ab9fe-e7c3-4cb4-a53d-bb83a8df029a", null, "user", "USER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_UserPost_Posts_PostId",
                table: "UserPost",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPost_Users_UserId",
                table: "UserPost",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
