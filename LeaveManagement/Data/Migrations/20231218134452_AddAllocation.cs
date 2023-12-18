using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddAllocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Period",
                table: "LeaveAllLocations",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d77d78b9d7d-1c3e-449d-f66e1234",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0b01cae6-c446-4d92-a49d-93c6f09471d5", "AQAAAAIAAYagAAAAEJePfvBN6UGwZ567kJ/B/jgPF+j1M1Vrwihskv42KqHnRiSN2nmh/qMdqcoYFvhpIw==", "d55f85ee-5737-485b-ade7-c7aa33c1bddd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f66e1234-1c3e-449d-80c7-6d77d7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a03d8e76-79c3-45fd-b6ee-d60b7deb87af", "AQAAAAIAAYagAAAAEDmW5/RCaAwX/XoHR/KDWfO8Ubv4/OgbZSI0GiQ1laQ9ct8neR14bxNkWa1FzAULsQ==", "31ad2ef8-a1d1-4a03-9dc4-329de87b4591" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Period",
                table: "LeaveAllLocations");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d77d78b9d7d-1c3e-449d-f66e1234",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "acdf5a6d-b7c4-45b8-b251-d165ebb28778", "AQAAAAIAAYagAAAAEPG+zmLXOKHRcVij0Bcb0k6o0sqOx4vx3Pg5Gry4Ld+9xOF9FIuNDevdL3QJWKcD9Q==", "d6564fa5-c3f9-45fc-9a04-f061fb43799b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f66e1234-1c3e-449d-80c7-6d77d7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7d49b100-c2be-4073-8ee3-95ed8d6188ba", "AQAAAAIAAYagAAAAELWsyct3N1nk3hBO44U70WCVsng08XTepSKHpsFH8fe9Qm1CjOwAjcEMh4IE1/P1lA==", "94c6b978-7952-49b8-a22a-58ff9271008d" });
        }
    }
}
