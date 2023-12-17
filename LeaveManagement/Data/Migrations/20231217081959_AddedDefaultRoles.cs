using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LeaveManagement.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedDefaultRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "admin12-f7bb-4448-baaf-1add431ccbbf", null, "Administrator", "ADMINISTRATOR" },
                    { "user12-f7bb-4448-baaf-1acd431ddbbf", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateJoined", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TaxId", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "6d77d78b9d7d-1c3e-449d-f66e1234", 0, "acdf5a6d-b7c4-45b8-b251-d165ebb28778", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "adminsson@hotmail.com", true, "Admin", "Adminsson", false, null, "ADMINSSON@HOTMAIL.COM", "ADMINSSON@HOTMAIL.COM", "AQAAAAIAAYagAAAAEPG+zmLXOKHRcVij0Bcb0k6o0sqOx4vx3Pg5Gry4Ld+9xOF9FIuNDevdL3QJWKcD9Q==", null, false, "d6564fa5-c3f9-45fc-9a04-f061fb43799b", null, false, "adminsson@hotmail.com" },
                    { "f66e1234-1c3e-449d-80c7-6d77d7", 0, "7d49b100-c2be-4073-8ee3-95ed8d6188ba", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "usersson@hotmail.com", true, "User", "Usersson", false, null, "USERSSON@HOTMAIL.COM", "USERSSON@HOTMAIL.COM", "AQAAAAIAAYagAAAAELWsyct3N1nk3hBO44U70WCVsng08XTepSKHpsFH8fe9Qm1CjOwAjcEMh4IE1/P1lA==", null, false, "94c6b978-7952-49b8-a22a-58ff9271008d", null, false, "usersson@hotmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "admin12-f7bb-4448-baaf-1add431ccbbf", "6d77d78b9d7d-1c3e-449d-f66e1234" },
                    { "user12-f7bb-4448-baaf-1acd431ddbbf", "f66e1234-1c3e-449d-80c7-6d77d7" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "admin12-f7bb-4448-baaf-1add431ccbbf", "6d77d78b9d7d-1c3e-449d-f66e1234" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "user12-f7bb-4448-baaf-1acd431ddbbf", "f66e1234-1c3e-449d-80c7-6d77d7" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "admin12-f7bb-4448-baaf-1add431ccbbf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "user12-f7bb-4448-baaf-1acd431ddbbf");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d77d78b9d7d-1c3e-449d-f66e1234");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f66e1234-1c3e-449d-80c7-6d77d7");
        }
    }
}
