using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class Gallerys_Im : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Galleries_GallerId",
                table: "Images");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "536d6ef6-3f66-4dab-a8b5-af7b5cdc08bf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7542b35-5701-4f3f-a7a4-22eb4dbe9ade");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e7054960-fe14-414c-a64b-c20d815d1d39");

            migrationBuilder.DropColumn(
                name: "GalaryId",
                table: "Images");

            migrationBuilder.RenameColumn(
                name: "GallerId",
                table: "Images",
                newName: "GalleryId");

            migrationBuilder.RenameIndex(
                name: "IX_Images_GallerId",
                table: "Images",
                newName: "IX_Images_GalleryId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "37049f78-d5dc-4c84-9231-23f2edd1067e", null, "user", "USER" },
                    { "5a1bb790-6e0f-4d1b-b440-6024a5f29257", null, "manager", "MANAGER" },
                    { "af7be00c-4bcc-4e87-b699-29283aa4d444", null, "employee", "EMPLOYEE" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Galleries_GalleryId",
                table: "Images",
                column: "GalleryId",
                principalTable: "Galleries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Galleries_GalleryId",
                table: "Images");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "37049f78-d5dc-4c84-9231-23f2edd1067e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5a1bb790-6e0f-4d1b-b440-6024a5f29257");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "af7be00c-4bcc-4e87-b699-29283aa4d444");

            migrationBuilder.RenameColumn(
                name: "GalleryId",
                table: "Images",
                newName: "GallerId");

            migrationBuilder.RenameIndex(
                name: "IX_Images_GalleryId",
                table: "Images",
                newName: "IX_Images_GallerId");

            migrationBuilder.AddColumn<int>(
                name: "GalaryId",
                table: "Images",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "536d6ef6-3f66-4dab-a8b5-af7b5cdc08bf", null, "employee", "EMPLOYEE" },
                    { "d7542b35-5701-4f3f-a7a4-22eb4dbe9ade", null, "user", "USER" },
                    { "e7054960-fe14-414c-a64b-c20d815d1d39", null, "manager", "MANAGER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Galleries_GallerId",
                table: "Images",
                column: "GallerId",
                principalTable: "Galleries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
