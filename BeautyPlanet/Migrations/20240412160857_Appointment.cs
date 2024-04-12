using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class Appointment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Specialists_Services_ServiceId",
                table: "Specialists");

            migrationBuilder.DropIndex(
                name: "IX_Specialists_ServiceId",
                table: "Specialists");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18d43b35-5226-4582-bb2d-e59cb4163f56");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e3edadde-4349-4c29-9510-23c5eecbb3ef");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f80d2786-0677-4cfd-af1d-e5f6ce25c687");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "Specialists");

            migrationBuilder.CreateTable(
                name: "ServiceSpecialists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    SpecialistId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceSpecialists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceSpecialists_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceSpecialists_Specialists_SpecialistId",
                        column: x => x.SpecialistId,
                        principalTable: "Specialists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceSpecialistId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_ServiceSpecialists_ServiceSpecialistId",
                        column: x => x.ServiceSpecialistId,
                        principalTable: "ServiceSpecialists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_Users_UserId",
                        column: x => x.UserId,
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
                name: "IX_Appointments_ServiceSpecialistId",
                table: "Appointments",
                column: "ServiceSpecialistId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_StatusId",
                table: "Appointments",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_UserId",
                table: "Appointments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceSpecialists_ServiceId_SpecialistId",
                table: "ServiceSpecialists",
                columns: new[] { "ServiceId", "SpecialistId" });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceSpecialists_SpecialistId",
                table: "ServiceSpecialists",
                column: "SpecialistId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "ServiceSpecialists");

            migrationBuilder.DropTable(
                name: "Statuses");

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

            migrationBuilder.AddColumn<int>(
                name: "ServiceId",
                table: "Specialists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "18d43b35-5226-4582-bb2d-e59cb4163f56", null, "manager", "MANAGER" },
                    { "e3edadde-4349-4c29-9510-23c5eecbb3ef", null, "user", "USER" },
                    { "f80d2786-0677-4cfd-af1d-e5f6ce25c687", null, "employee", "EMPLOYEE" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Specialists_ServiceId",
                table: "Specialists",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Specialists_Services_ServiceId",
                table: "Specialists",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
