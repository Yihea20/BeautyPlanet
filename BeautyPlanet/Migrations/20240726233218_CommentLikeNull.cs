using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class CommentLikeNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "078f7d68-6347-463e-b854-d1e27aa4e162");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "10ff498e-31df-4ebc-859f-2a4755ab61ae");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "348f10aa-ac95-4f8e-9853-737e6dec15cc");

            migrationBuilder.AlterColumn<int>(
                name: "Like",
                table: "Comments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "910f50c7-af03-4956-b984-bc70f1635f40", null, "employee", "EMPLOYEE" },
                    { "b3ed25c9-9596-48ca-ac0c-e7945c851130", null, "manager", "MANAGER" },
                    { "e05e70ac-39dd-4179-ae38-5724b8584106", null, "user", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "910f50c7-af03-4956-b984-bc70f1635f40");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b3ed25c9-9596-48ca-ac0c-e7945c851130");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e05e70ac-39dd-4179-ae38-5724b8584106");

            migrationBuilder.AlterColumn<int>(
                name: "Like",
                table: "Comments",
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
                    { "078f7d68-6347-463e-b854-d1e27aa4e162", null, "manager", "MANAGER" },
                    { "10ff498e-31df-4ebc-859f-2a4755ab61ae", null, "user", "USER" },
                    { "348f10aa-ac95-4f8e-9853-737e6dec15cc", null, "employee", "EMPLOYEE" }
                });
        }
    }
}
