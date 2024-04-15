using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class List : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "64563776-7312-4276-ab91-304247c05f07", null, "user", "USER" },
                    { "b327e9a0-42bc-4520-9fb5-ed950e6538aa", null, "manager", "MANAGER" },
                    { "b8b9a81e-d0fa-4da2-83ce-18da61a396db", null, "employee", "EMPLOYEE" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "64563776-7312-4276-ab91-304247c05f07");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b327e9a0-42bc-4520-9fb5-ed950e6538aa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b8b9a81e-d0fa-4da2-83ce-18da61a396db");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5deec19d-5f36-45e6-a4bb-351cb0bb9f54", null, "manager", "MANAGER" },
                    { "9b77da1f-9caa-4d8f-b4d8-530500cab590", null, "user", "USER" },
                    { "e86c22bc-7c66-425e-a502-572fda409424", null, "employee", "EMPLOYEE" }
                });
        }
    }
}
