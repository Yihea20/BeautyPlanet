using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class CategoryUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f60cf6a-0a3e-47af-be36-eb3c352d5ba5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bac568cc-f840-417e-b2ca-54b146d5f273");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e654d871-28d4-4eaf-b45c-fa98fa2a26ab");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Category",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "TimeModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpecialistTimeModel",
                columns: table => new
                {
                    SpecialistsId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TimesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialistTimeModel", x => new { x.SpecialistsId, x.TimesId });
                    table.ForeignKey(
                        name: "FK_SpecialistTimeModel_Specialists_SpecialistsId",
                        column: x => x.SpecialistsId,
                        principalTable: "Specialists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpecialistTimeModel_TimeModel_TimesId",
                        column: x => x.TimesId,
                        principalTable: "TimeModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TimeModelUser",
                columns: table => new
                {
                    TimesId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeModelUser", x => new { x.TimesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_TimeModelUser_TimeModel_TimesId",
                        column: x => x.TimesId,
                        principalTable: "TimeModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TimeModelUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7ab18690-88e8-49e5-b255-a7bc69fc99e8", null, "employee", "EMPLOYEE" },
                    { "d9a60024-70d8-49d6-b9be-e94f834eb2b5", null, "manager", "MANAGER" },
                    { "db65bef2-07fa-4e8a-8168-a1e3ca2fbb26", null, "user", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SpecialistTimeModel_TimesId",
                table: "SpecialistTimeModel",
                column: "TimesId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeModelUser_UsersId",
                table: "TimeModelUser",
                column: "UsersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SpecialistTimeModel");

            migrationBuilder.DropTable(
                name: "TimeModelUser");

            migrationBuilder.DropTable(
                name: "TimeModel");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7ab18690-88e8-49e5-b255-a7bc69fc99e8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d9a60024-70d8-49d6-b9be-e94f834eb2b5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db65bef2-07fa-4e8a-8168-a1e3ca2fbb26");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Category");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0f60cf6a-0a3e-47af-be36-eb3c352d5ba5", null, "manager", "MANAGER" },
                    { "bac568cc-f840-417e-b2ca-54b146d5f273", null, "employee", "EMPLOYEE" },
                    { "e654d871-28d4-4eaf-b45c-fa98fa2a26ab", null, "user", "USER" }
                });
        }
    }
}
