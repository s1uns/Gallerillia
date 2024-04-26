using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class PicturesTableTitleFixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Picture_Albums_AlbumId",
                table: "Picture");

            migrationBuilder.DropForeignKey(
                name: "FK_Votes_Picture_PictureId",
                table: "Votes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Picture",
                table: "Picture");

            migrationBuilder.RenameTable(
                name: "Picture",
                newName: "Pictures");

            migrationBuilder.RenameIndex(
                name: "IX_Picture_AlbumId",
                table: "Pictures",
                newName: "IX_Pictures_AlbumId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pictures",
                table: "Pictures",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "91db98e2-d0a4-40cd-abb1-ccc320995521", "AQAAAAIAAYagAAAAEJKd+6foKOhZUoNtGLN3pDa4gMZL4r/epyneWaIr+5i4aweI6ecHvrR41T9OT+TXWg==" });

            migrationBuilder.AddForeignKey(
                name: "FK_Pictures_Albums_AlbumId",
                table: "Pictures",
                column: "AlbumId",
                principalTable: "Albums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_Pictures_PictureId",
                table: "Votes",
                column: "PictureId",
                principalTable: "Pictures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pictures_Albums_AlbumId",
                table: "Pictures");

            migrationBuilder.DropForeignKey(
                name: "FK_Votes_Pictures_PictureId",
                table: "Votes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pictures",
                table: "Pictures");

            migrationBuilder.RenameTable(
                name: "Pictures",
                newName: "Picture");

            migrationBuilder.RenameIndex(
                name: "IX_Pictures_AlbumId",
                table: "Picture",
                newName: "IX_Picture_AlbumId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Picture",
                table: "Picture",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c9cc9f3c-6d40-492b-9e24-9ccd235ee084", "AQAAAAIAAYagAAAAEAUIf0iibXC9laiFcXvVNjxx+b6Hl5Xn312LuivaLJhIVWOFyGxMij+fV8DFEx7A0w==" });

            migrationBuilder.AddForeignKey(
                name: "FK_Picture_Albums_AlbumId",
                table: "Picture",
                column: "AlbumId",
                principalTable: "Albums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_Picture_PictureId",
                table: "Votes",
                column: "PictureId",
                principalTable: "Picture",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
