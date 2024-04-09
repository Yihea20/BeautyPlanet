using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class Offers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3bde50fa-b9b2-4b83-870e-d5372845655a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8c4a1588-98c7-402f-803b-c1210584140b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d6dc334e-5660-4f18-abc5-ac88ca0461a2");

            migrationBuilder.AddColumn<string>(
                name: "ImageIcone",
                table: "Services",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceCenterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Offers_ServiceCenters_ServiceCenterId",
                        column: x => x.ServiceCenterId,
                        principalTable: "ServiceCenters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6ed80048-d960-4f70-8f03-a23e07234dd9", null, "employee", "EMPLOYEE" },
                    { "e15d22ba-9b21-4902-a493-94dfbb275de9", null, "manager", "MANAGER" },
                    { "ff359e4d-b8a0-4b97-a678-df6a8b654373", null, "user", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Offers_ServiceCenterId",
                table: "Offers",
                column: "ServiceCenterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Offers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ed80048-d960-4f70-8f03-a23e07234dd9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e15d22ba-9b21-4902-a493-94dfbb275de9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ff359e4d-b8a0-4b97-a678-df6a8b654373");

            migrationBuilder.DropColumn(
                name: "ImageIcone",
                table: "Services");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3bde50fa-b9b2-4b83-870e-d5372845655a", null, "user", "USER" },
                    { "8c4a1588-98c7-402f-803b-c1210584140b", null, "employee", "EMPLOYEE" },
                    { "d6dc334e-5660-4f18-abc5-ac88ca0461a2", null, "manager", "MANAGER" }
                });
        }
    }
}
