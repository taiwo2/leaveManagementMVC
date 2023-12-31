using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedLeaveRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d77d78b9d7d-1c3e-449d-f66e1234",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5038cf29-3b7f-43aa-a2e5-6036426c73d7", "AQAAAAIAAYagAAAAEJWIzTonrjCpD7Xezp79VcaTNm9RBcyHoiHQQlmafhrloSQYT7A42BSKRH4gSjOu4A==", "853dff8b-158d-4a41-8e44-7718dd816d45" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f66e1234-1c3e-449d-80c7-6d77d7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3f85cfdf-515b-4fe4-9a00-414b8873b4a8", "AQAAAAIAAYagAAAAEOvCrnWEZSY9Dz2jH9nONw0Eo+lUen++5HqEZI2mR3WUDV8KCIctAAhzW2y28+TgUA==", "b360950d-714e-4a4f-a1af-051d08b85b92" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d77d78b9d7d-1c3e-449d-f66e1234",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d32619f0-cc9c-498c-9df1-3da8bb848172", "AQAAAAIAAYagAAAAECOHYzQ70RpJdg0zWvH3bA8xXhpxbX1EdpOlnnNDubUXjFHW4P+cAoBAdHdaAN5ZlQ==", "a87fdbe4-7607-4284-ac03-4ae1aa192c44" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f66e1234-1c3e-449d-80c7-6d77d7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fb42eb1b-95b5-421a-8c54-127690f87925", "AQAAAAIAAYagAAAAEIL2R8hcDJVFVk1pEObYZJYbr4Zm3x/XgpFaCCrgVE1zpW5wyRY5/lMFD/wJyrukAg==", "9fe16652-43f5-4eb3-914e-e139b9ca2734" });
        }
    }
}
