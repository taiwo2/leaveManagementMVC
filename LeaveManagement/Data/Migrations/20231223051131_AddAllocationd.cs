using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddAllocationd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d77d78b9d7d-1c3e-449d-f66e1234",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fe903c82-068b-4388-946f-61380a6b0ae4", "AQAAAAIAAYagAAAAEBZ8tz6POxVNX1cK5ucHxKexOFZSURj6rhVYpOpbVwr1kJg4GdCpGQPyQw1Cum+UMA==", "aa40a91d-0f54-484f-add2-a29751430121" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f66e1234-1c3e-449d-80c7-6d77d7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5b00e3a5-dbf7-40a3-9a19-2811d398f1df", "AQAAAAIAAYagAAAAENCaeyh8+B5n/RvYQ7cX2b8NofhX/XTzEwBd9MukJW45xT+LtsHsa/KGFIUq1ATz6A==", "45320ea6-7237-4ad6-b3cc-ff36abae5dde" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
