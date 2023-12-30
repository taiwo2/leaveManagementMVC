using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Data.Migrations
{
    /// <inheritdoc />
    public partial class addedLeaveRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LeaveRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LeaveTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    DateRequested = table.Column<DateTime>(type: "TEXT", nullable: false),
                    RequestComments = table.Column<string>(type: "TEXT", nullable: true),
                    Approved = table.Column<bool>(type: "INTEGER", nullable: true),
                    Cancelled = table.Column<bool>(type: "INTEGER", nullable: false),
                    RequestingEmployeeId = table.Column<string>(type: "TEXT", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateModified = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeaveRequests_LeaveTypes_LeaveTypeId",
                        column: x => x.LeaveTypeId,
                        principalTable: "LeaveTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d77d78b9d7d-1c3e-449d-f66e1234",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "101e9f74-ccae-495b-9651-7e0006d782c7", "AQAAAAIAAYagAAAAEDeIycVbFlF8rxPIMAMw2jLo8qbkVAfyweSN/pabU60yjE5n1kf8kqyqDkx8NIEHSQ==", "9a7083da-ae14-4b57-bb2b-f515d901d8bf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f66e1234-1c3e-449d-80c7-6d77d7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9dca908b-1278-46b2-b86b-ff56188677bb", "AQAAAAIAAYagAAAAEMaM7eYG1OVK+da5eY39ggvL4OfHFUPKGZPMOpG8XeWmczY+VRpsmv6IOxlzDHLFwQ==", "f031ff92-7d87-471b-ae73-51be6d7838ed" });

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequests_LeaveTypeId",
                table: "LeaveRequests",
                column: "LeaveTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeaveRequests");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d77d78b9d7d-1c3e-449d-f66e1234",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "96ed0de9-28a0-4485-b459-6a5b30f986bb", "AQAAAAIAAYagAAAAEGn0vLWvx8kWKq5p5YT7H4oRuy/AAl/aSX8AwrUTRkIYiDzdfalWyxN/6HLoJaUCWw==", "48b64f98-382b-43df-b5b4-17f212dc9a4f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f66e1234-1c3e-449d-80c7-6d77d7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c2bc02a2-12fa-4904-914a-643eec0fa601", "AQAAAAIAAYagAAAAEK3fV4UcW34U7TcgphNXN9tX50LiEWNoZlHlCs1O43tpqVb9Q66y+Izx/wqraVqRDA==", "0e634c75-03d8-4b4a-b979-1fdd2dc557e5" });
        }
    }
}
