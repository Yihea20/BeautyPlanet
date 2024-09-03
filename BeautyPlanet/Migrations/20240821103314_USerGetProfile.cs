using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class USerGetProfile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "689eba19-d781-43f1-8409-671f8a8dffc5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8f2436f5-853e-4d86-b172-72b41328a708");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dae1fc64-24a2-4889-b9be-6d39296bc584");

            migrationBuilder.AddColumn<int>(
                name: "FavoriteCount",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrderCount",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1df713e7-f490-406e-bae1-49cabbc80360", null, "user", "USER" },
                    { "ddc3b676-c8de-450a-b59b-277efe9290cd", null, "manager", "MANAGER" },
                    { "e5646499-e8f5-48e0-8ac1-461d6cbc5925", null, "employee", "EMPLOYEE" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1df713e7-f490-406e-bae1-49cabbc80360");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ddc3b676-c8de-450a-b59b-277efe9290cd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e5646499-e8f5-48e0-8ac1-461d6cbc5925");

            migrationBuilder.DropColumn(
                name: "FavoriteCount",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "OrderCount",
                table: "Users");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "689eba19-d781-43f1-8409-671f8a8dffc5", null, "employee", "EMPLOYEE" },
                    { "8f2436f5-853e-4d86-b172-72b41328a708", null, "user", "USER" },
                    { "dae1fc64-24a2-4889-b9be-6d39296bc584", null, "manager", "MANAGER" }
                });
        }
    }
}
