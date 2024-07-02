using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class Postspcenter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Centers_CenterId",
                table: "Posts");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "048fc4f0-54a2-4b63-89a4-f9c5d39fd01b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c1d89e45-84dc-4df6-bce8-b783b414c493");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d41c1e0e-cbfd-4c52-beb2-abd0a5a8c666");

            migrationBuilder.AlterColumn<int>(
                name: "CenterId",
                table: "Posts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "SpecialistId",
                table: "Posts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "09c29847-2cb5-4ebd-9b28-b9433689280a", null, "employee", "EMPLOYEE" },
                    { "6708e340-4a61-4afd-a439-33fc6a3f2836", null, "manager", "MANAGER" },
                    { "9b96a4ed-15cb-40c4-bf5a-e90b9f05a762", null, "user", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_SpecialistId",
                table: "Posts",
                column: "SpecialistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Centers_CenterId",
                table: "Posts",
                column: "CenterId",
                principalTable: "Centers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Specialists_SpecialistId",
                table: "Posts",
                column: "SpecialistId",
                principalTable: "Specialists",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Centers_CenterId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Specialists_SpecialistId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_SpecialistId",
                table: "Posts");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "09c29847-2cb5-4ebd-9b28-b9433689280a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6708e340-4a61-4afd-a439-33fc6a3f2836");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9b96a4ed-15cb-40c4-bf5a-e90b9f05a762");

            migrationBuilder.DropColumn(
                name: "SpecialistId",
                table: "Posts");

            migrationBuilder.AlterColumn<int>(
                name: "CenterId",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "048fc4f0-54a2-4b63-89a4-f9c5d39fd01b", null, "employee", "EMPLOYEE" },
                    { "c1d89e45-84dc-4df6-bce8-b783b414c493", null, "user", "USER" },
                    { "d41c1e0e-cbfd-4c52-beb2-abd0a5a8c666", null, "manager", "MANAGER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Centers_CenterId",
                table: "Posts",
                column: "CenterId",
                principalTable: "Centers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
