using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class TimeStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                keyValue: "05e2464a-0197-429f-a8ff-e36c495b76c4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3c13a608-5f7a-4f7b-8a31-0d628845a5f2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b0944e43-1872-4dcf-bc8b-33adf698a5aa");

            migrationBuilder.AddColumn<string>(
                name: "Times",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Times",
                table: "Specialists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5deec19d-5f36-45e6-a4bb-351cb0bb9f54", null, "manager", "MANAGER" },
                    { "9b77da1f-9caa-4d8f-b4d8-530500cab590", null, "user", "USER" },
                    { "e86c22bc-7c66-425e-a502-572fda409424", null, "employee", "EMPLOYEE" }
                });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "UpComing" },
                    { 2, "Completed" },
                    { 3, "Cancelled" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5deec19d-5f36-45e6-a4bb-351cb0bb9f54");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9b77da1f-9caa-4d8f-b4d8-530500cab590");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e86c22bc-7c66-425e-a502-572fda409424");

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "Times",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Times",
                table: "Specialists");

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
                    { "05e2464a-0197-429f-a8ff-e36c495b76c4", null, "employee", "EMPLOYEE" },
                    { "3c13a608-5f7a-4f7b-8a31-0d628845a5f2", null, "user", "USER" },
                    { "b0944e43-1872-4dcf-bc8b-33adf698a5aa", null, "manager", "MANAGER" }
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
    }
}
