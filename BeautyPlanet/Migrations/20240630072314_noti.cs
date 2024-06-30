using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class noti : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "57262702-00db-46f1-9244-5ed6c7c2e4d7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c0fd5f59-00e3-415c-a73e-3297d5c9b66c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e78a9317-102b-41f5-83a6-0ab31c5b4321");

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeviceToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "048fc4f0-54a2-4b63-89a4-f9c5d39fd01b", null, "employee", "EMPLOYEE" },
                    { "c1d89e45-84dc-4df6-bce8-b783b414c493", null, "user", "USER" },
                    { "d41c1e0e-cbfd-4c52-beb2-abd0a5a8c666", null, "manager", "MANAGER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_ServiceId",
                table: "Notifications",
                column: "ServiceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notifications");

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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "57262702-00db-46f1-9244-5ed6c7c2e4d7", null, "employee", "EMPLOYEE" },
                    { "c0fd5f59-00e3-415c-a73e-3297d5c9b66c", null, "manager", "MANAGER" },
                    { "e78a9317-102b-41f5-83a6-0ab31c5b4321", null, "user", "USER" }
                });
        }
    }
}
