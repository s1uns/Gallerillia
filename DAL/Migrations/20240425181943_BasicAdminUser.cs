using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class BasicAdminUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "ef04a893-8a7b-499a-9d74-d08072744c20", "AQAAAAIAAYagAAAAELcvXUdAu8QOYikxkBu23/AXqZKdy/NfY9xsYIwj1Ah/zcf6EhVmogudVG9Fts1KSg==" });
        }
    }
}
