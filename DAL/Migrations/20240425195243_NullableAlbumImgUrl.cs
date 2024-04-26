using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class NullableAlbumImgUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c9cc9f3c-6d40-492b-9e24-9ccd235ee084", "AQAAAAIAAYagAAAAEAUIf0iibXC9laiFcXvVNjxx+b6Hl5Xn312LuivaLJhIVWOFyGxMij+fV8DFEx7A0w==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8e457840-a596-4a77-9d9d-c234d198419e", "AQAAAAIAAYagAAAAEAPTqLJ8B0Pg3vsxkCJFKFWkBUUiXspCuXys3W4MqSObSPF0sAKtIuVlKQQW0tsejw==" });
        }
    }
}
