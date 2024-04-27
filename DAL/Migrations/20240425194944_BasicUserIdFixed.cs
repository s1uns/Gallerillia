using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class BasicUserIdFixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrdinaryUsers",
                keyColumn: "Id",
                keyValue: new Guid("a18be9c0-aa65-4af8-bd17-00bd9344e576"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8e457840-a596-4a77-9d9d-c234d198419e", "AQAAAAIAAYagAAAAEAPTqLJ8B0Pg3vsxkCJFKFWkBUUiXspCuXys3W4MqSObSPF0sAKtIuVlKQQW0tsejw==" });

            migrationBuilder.InsertData(
                table: "OrdinaryUsers",
                columns: new[] { "Id", "Email" },
                values: new object[] { new Guid("a18be9c0-aa65-4af8-bd17-00bd9344e575"), "illiateliuk@gmail.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrdinaryUsers",
                keyColumn: "Id",
                keyValue: new Guid("a18be9c0-aa65-4af8-bd17-00bd9344e575"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f8f6da7d-a92a-4811-9dad-d8ab6014bca1", "AQAAAAIAAYagAAAAEKpLSQApeE6VNPldU6pSUThisYP9rPRTPH3NCaHz2A5fmhfU8/xYc6jqFEznTt8AEw==" });

            migrationBuilder.InsertData(
                table: "OrdinaryUsers",
                columns: new[] { "Id", "Email" },
                values: new object[] { new Guid("a18be9c0-aa65-4af8-bd17-00bd9344e576"), "illiateliuk@gmail.com" });
        }
    }
}
