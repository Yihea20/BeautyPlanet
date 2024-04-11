using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class Gallerys_Imag : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Galleries_GalaryId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_GalaryId",
                table: "Images");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "079b1631-d72c-4a25-907c-a4cf3a3d02ac");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "235902b5-ec7c-4ab9-b6f7-d67dcf2c2b70");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a9863912-d67d-48d4-a115-70420775cd28");

            migrationBuilder.AddColumn<int>(
                name: "GallerId",
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

            migrationBuilder.CreateIndex(
                name: "IX_Images_GallerId",
                table: "Images",
                column: "GallerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Galleries_GallerId",
                table: "Images",
                column: "GallerId",
                principalTable: "Galleries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Galleries_GallerId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_GallerId",
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
                name: "GallerId",
                table: "Images");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "079b1631-d72c-4a25-907c-a4cf3a3d02ac", null, "user", "USER" },
                    { "235902b5-ec7c-4ab9-b6f7-d67dcf2c2b70", null, "manager", "MANAGER" },
                    { "a9863912-d67d-48d4-a115-70420775cd28", null, "employee", "EMPLOYEE" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Images_GalaryId",
                table: "Images",
                column: "GalaryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Galleries_GalaryId",
                table: "Images",
                column: "GalaryId",
                principalTable: "Galleries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
