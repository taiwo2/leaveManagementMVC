using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddAllocationVM : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaveAllLocations_LeaveTypes_LeaveTypeId",
                table: "LeaveAllLocations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LeaveAllLocations",
                table: "LeaveAllLocations");

            migrationBuilder.RenameTable(
                name: "LeaveAllLocations",
                newName: "LeaveAllocations");

            migrationBuilder.RenameIndex(
                name: "IX_LeaveAllLocations_LeaveTypeId",
                table: "LeaveAllocations",
                newName: "IX_LeaveAllocations_LeaveTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LeaveAllocations",
                table: "LeaveAllocations",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveAllocations_LeaveTypes_LeaveTypeId",
                table: "LeaveAllocations",
                column: "LeaveTypeId",
                principalTable: "LeaveTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaveAllocations_LeaveTypes_LeaveTypeId",
                table: "LeaveAllocations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LeaveAllocations",
                table: "LeaveAllocations");

            migrationBuilder.RenameTable(
                name: "LeaveAllocations",
                newName: "LeaveAllLocations");

            migrationBuilder.RenameIndex(
                name: "IX_LeaveAllocations_LeaveTypeId",
                table: "LeaveAllLocations",
                newName: "IX_LeaveAllLocations_LeaveTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LeaveAllLocations",
                table: "LeaveAllLocations",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d77d78b9d7d-1c3e-449d-f66e1234",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1fa09112-d0a5-484d-b978-06384d04a0ca", "AQAAAAIAAYagAAAAEHUx1ZQsB7E05YnymTP05p6FUc0Y8tqW0oWf7VBBVYKCEXVNyqC/4MmhrW15PIGGrQ==", "62b650f2-8f29-4c38-9776-2b7979ad0bd2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f66e1234-1c3e-449d-80c7-6d77d7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9cc3aa97-4523-4537-a05b-5a93544215b9", "AQAAAAIAAYagAAAAEJRl0BxgeawwidKpwZrhBJsbLEVvE47j3Sk5IUThBuKtEQGCbaM/GFwkYe+sTTi2nA==", "20234f65-8a83-4645-b9ee-90035b8fa848" });

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveAllLocations_LeaveTypes_LeaveTypeId",
                table: "LeaveAllLocations",
                column: "LeaveTypeId",
                principalTable: "LeaveTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
