using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class cancellDAteUSer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "13c09f54-7adc-4702-92c1-ddb7ee00aa26");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3c7a5ab6-176d-4c18-bb31-4ee0b5c56878");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "899c4124-a8dd-414c-9e15-8747a9900f0f");

            migrationBuilder.AlterColumn<string>(
                name: "CancelDate",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "CancelDate",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "13c09f54-7adc-4702-92c1-ddb7ee00aa26", null, "manager", "MANAGER" },
                    { "3c7a5ab6-176d-4c18-bb31-4ee0b5c56878", null, "user", "USER" },
                    { "899c4124-a8dd-414c-9e15-8747a9900f0f", null, "employee", "EMPLOYEE" }
                });
        }
    }
}
