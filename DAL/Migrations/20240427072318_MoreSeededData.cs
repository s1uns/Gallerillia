using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class MoreSeededData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "69c82957-43ea-4f23-9efc-0eac834e3486", "AQAAAAIAAYagAAAAEGR2sBH6VLnYUbFK6Sdqzpgt1SllzXdh+JGXyiaOwugXOoGKqDn8GJJz1ZGA2yFEtw==" });

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                column: "AlbumId",
                value: new Guid("88888888-8888-8888-8888-888888888888"));

            migrationBuilder.InsertData(
                table: "Pictures",
                columns: new[] { "Id", "AlbumId", "ImgUrl" },
                values: new object[,]
                {
                    { new Guid("09b0ce84-1a29-424d-a149-47daf09a9adb"), new Guid("88888888-8888-8888-8888-888888888888"), "https://img.freepik.com/free-photo/wide-angle-shot-single-tree-growing-clouded-sky-during-sunset-surrounded-by-grass_181624-22807.jpg" },
                    { new Guid("462ba917-573f-4e76-8f6c-a1d9323c1b3b"), new Guid("66666666-6666-6666-6666-666666666666"), "https://www.imgacademy.com/sites/default/files/img-academy-organization-schema.jpg" },
                    { new Guid("60ca3fde-6539-4651-8e1a-0fd6e116d41f"), new Guid("66666666-6666-6666-6666-666666666666"), "https://www.imgacademy.com/sites/default/files/img-academy-organization-schema.jpg" },
                    { new Guid("afad7ba2-98aa-4010-b965-0c5c223eace3"), new Guid("88888888-8888-8888-8888-888888888888"), "https://www.imgacademy.com/sites/default/files/img-academy-organization-schema.jpg" },
                    { new Guid("c263fcb6-4360-416d-8274-b6c1cbed34eb"), new Guid("66666666-6666-6666-6666-666666666666"), "https://img.freepik.com/free-photo/wide-angle-shot-single-tree-growing-clouded-sky-during-sunset-surrounded-by-grass_181624-22807.jpg" },
                    { new Guid("da743ff3-7330-4c10-aa7b-44eee6bfa727"), new Guid("66666666-6666-6666-6666-666666666666"), "https://img.freepik.com/free-photo/wide-angle-shot-single-tree-growing-clouded-sky-during-sunset-surrounded-by-grass_181624-22807.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: new Guid("09b0ce84-1a29-424d-a149-47daf09a9adb"));

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: new Guid("462ba917-573f-4e76-8f6c-a1d9323c1b3b"));

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: new Guid("60ca3fde-6539-4651-8e1a-0fd6e116d41f"));

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: new Guid("afad7ba2-98aa-4010-b965-0c5c223eace3"));

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: new Guid("c263fcb6-4360-416d-8274-b6c1cbed34eb"));

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: new Guid("da743ff3-7330-4c10-aa7b-44eee6bfa727"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a9756c09-00dd-4b00-8c12-1d5b32a52689", "AQAAAAIAAYagAAAAEKo/6Ilgy19GnWevlW3hB4OhK3YQVkSQ/l6Prx8QkrX3QgbR5C5YU/092SAYdu3iGw==" });

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                column: "AlbumId",
                value: new Guid("33333333-3333-3333-3333-333333333333"));
        }
    }
}
