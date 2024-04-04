using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class Service : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7f3ed0af-df66-4c06-8c4a-e6df5f27539f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b3b846a2-5281-43d9-b2a9-38c0aaf00743");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ff398565-7096-4d87-a238-2aab7f0d5667");

            migrationBuilder.AddColumn<int>(
                name: "ServiceId",
                table: "Specialists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceCenters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    CenterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceCenters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceCenters_Centers_CenterId",
                        column: x => x.CenterId,
                        principalTable: "Centers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceCenters_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7e2d2c83-035b-407e-903e-9277bdc1b154", null, "employee", "EMPLOYEE" },
                    { "875a9118-48b4-431c-9852-6c2858a03a90", null, "manager", "MANAGER" },
                    { "ca9f7b46-6084-4c61-a312-a3d3d2138517", null, "user", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Specialists_ServiceId",
                table: "Specialists",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceCenters_CenterId",
                table: "ServiceCenters",
                column: "CenterId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceCenters_ServiceId_CenterId",
                table: "ServiceCenters",
                columns: new[] { "ServiceId", "CenterId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Specialists_Services_ServiceId",
                table: "Specialists",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Specialists_Services_ServiceId",
                table: "Specialists");

            migrationBuilder.DropTable(
                name: "ServiceCenters");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Specialists_ServiceId",
                table: "Specialists");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7e2d2c83-035b-407e-903e-9277bdc1b154");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "875a9118-48b4-431c-9852-6c2858a03a90");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ca9f7b46-6084-4c61-a312-a3d3d2138517");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "Specialists");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7f3ed0af-df66-4c06-8c4a-e6df5f27539f", null, "user", "USER" },
                    { "b3b846a2-5281-43d9-b2a9-38c0aaf00743", null, "employee", "EMPLOYEE" },
                    { "ff398565-7096-4d87-a238-2aab7f0d5667", null, "manager", "MANAGER" }
                });
        }
    }
}
