using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class sevicesp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_ServiceSpecialists_ServiceSpecialistId",
                table: "Appointments");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3e72ec2a-7807-4ed7-b01f-15ae4869f756");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5b21c8d0-c358-4c0f-a1fa-9e118d0de4ff");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a650681f-eada-4cf9-9d1a-b25c8e23ad73");

            migrationBuilder.RenameColumn(
                name: "ServiceSpecialistId",
                table: "Appointments",
                newName: "ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_ServiceSpecialistId",
                table: "Appointments",
                newName: "IX_Appointments_ServiceId");

            migrationBuilder.AddColumn<string>(
                name: "SpecialistId",
                table: "Appointments",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "83a7d6b7-bdf7-4c2e-b547-2d68009136df", null, "employee", "EMPLOYEE" },
                    { "85f7ed6c-24df-4d76-926f-0c790119cc9a", null, "user", "USER" },
                    { "90787224-7e16-4dd3-9e3c-36f593d27d9d", null, "manager", "MANAGER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_SpecialistId",
                table: "Appointments",
                column: "SpecialistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Services_ServiceId",
                table: "Appointments",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Specialists_SpecialistId",
                table: "Appointments",
                column: "SpecialistId",
                principalTable: "Specialists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Services_ServiceId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Specialists_SpecialistId",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_SpecialistId",
                table: "Appointments");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "83a7d6b7-bdf7-4c2e-b547-2d68009136df");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "85f7ed6c-24df-4d76-926f-0c790119cc9a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "90787224-7e16-4dd3-9e3c-36f593d27d9d");

            migrationBuilder.DropColumn(
                name: "SpecialistId",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "ServiceId",
                table: "Appointments",
                newName: "ServiceSpecialistId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_ServiceId",
                table: "Appointments",
                newName: "IX_Appointments_ServiceSpecialistId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3e72ec2a-7807-4ed7-b01f-15ae4869f756", null, "manager", "MANAGER" },
                    { "5b21c8d0-c358-4c0f-a1fa-9e118d0de4ff", null, "user", "USER" },
                    { "a650681f-eada-4cf9-9d1a-b25c8e23ad73", null, "employee", "EMPLOYEE" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_ServiceSpecialists_ServiceSpecialistId",
                table: "Appointments",
                column: "ServiceSpecialistId",
                principalTable: "ServiceSpecialists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
