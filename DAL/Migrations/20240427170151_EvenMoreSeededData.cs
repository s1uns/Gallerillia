using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class EvenMoreSeededData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: new Guid("084075da-4814-4d6c-8dbf-d90629de3dc8"),
                column: "ImgUrl",
                value: "https://www.recordnet.com/gcdn/presto/2021/03/22/NRCD/9d9dd9e4-e84a-402e-ba8f-daa659e6e6c5-PhotoWord_003.JPG?width=660&height=425&fit=crop&format=pjpg&auto=web");

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: new Guid("183dbb6c-4465-47e3-8097-78b75744c7cf"),
                column: "ImgUrl",
                value: "https://img.freepik.com/free-photo/wide-angle-shot-single-tree-growing-clouded-sky-during-sunset-surrounded-by-grass_181624-22807.jpg");

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: new Guid("2ed99df9-d497-42a0-823a-1fb7b2361e80"),
                column: "ImgUrl",
                value: "https://img.freepik.com/free-photo/wide-angle-shot-single-tree-growing-clouded-sky-during-sunset-surrounded-by-grass_181624-22807.jpg");

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                column: "ImgUrl",
                value: "https://img.freepik.com/free-photo/wide-angle-shot-single-tree-growing-clouded-sky-during-sunset-surrounded-by-grass_181624-22807.jpg");

            migrationBuilder.InsertData(
                table: "Albums",
                columns: new[] { "Id", "AuthorId", "ImgUrl", "Title" },
                values: new object[,]
                {
                    { new Guid("0b341388-15b5-49b6-a1dc-838199038a3f"), new Guid("33333333-3333-3333-3333-333333333333"), "https://img.freepik.com/free-photo/sports-tools_53876-138077.jpg", "Sports" },
                    { new Guid("13781f37-1c81-487a-9dfd-5fb04458a071"), new Guid("11111111-1111-1111-1111-111111111111"), "https://www.imgacademy.com/sites/default/files/img-academy-organization-schema.jpg", "History" },
                    { new Guid("456671cb-bec1-4192-840c-0d12622b2341"), new Guid("22222222-2222-2222-2222-222222222222"), "https://www.j-dphoto.com/images/news/04122015111102imgfamily00134170810526.jpg", "Art" },
                    { new Guid("6011954d-12b7-4d95-9859-de453ac27f88"), new Guid("22222222-2222-2222-2222-222222222222"), "https://media.istockphoto.com/id/1457889029/photo/group-of-food-with-high-content-of-dietary-fiber-arranged-side-by-side.jpg?s=612x612&w=0&k=20&c=SEyObHsbBsrd1XZlgEg389VT86BMFKZKfKReKyVPAk4=", "Food" },
                    { new Guid("6758f828-de3f-4a34-96dd-578b0b5f5a27"), new Guid("22222222-2222-2222-2222-222222222222"), "https://upload.wikimedia.org/wikipedia/commons/e/e5/Creating_music.jpg", "Music" },
                    { new Guid("886741df-70ac-4cfe-830b-7c285a96d100"), new Guid("11111111-1111-1111-1111-111111111111"), "https://www.j-dphoto.com/images/news/04122015111102imgfamily00134170810526.jpg", "Science" },
                    { new Guid("bb7357f7-6a3e-4b27-a027-26e9ca140563"), new Guid("33333333-3333-3333-3333-333333333333"), "https://img.freepik.com/free-photo/wide-angle-shot-single-tree-growing-clouded-sky-during-sunset-surrounded-by-grass_181624-22807.jpg", "Cars" },
                    { new Guid("e1541da6-4614-449a-b43c-7b70b905cb90"), new Guid("11111111-1111-1111-1111-111111111111"), "https://imageio.forbes.com/specials-images/imageserve/5faad4255239c9448d6c7bcd/Best-Animal-Photos-Contest--Close-Up-Of-baby-monkey/960x0.jpg?format=jpg&width=960", "Animals" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f8888842-3f90-42be-a89b-877b7aad2b75", "AQAAAAIAAYagAAAAEEHDAW0/VTNq9+5WYub9zOSMHkuOxp20uffAwASw5CT5dCOLw0CQ6JS6Mc7pAtJGuQ==" });

            migrationBuilder.InsertData(
                table: "Pictures",
                columns: new[] { "Id", "AlbumId", "ImgUrl" },
                values: new object[,]
                {
                    { new Guid("010b060a-9cf6-4d43-ab32-a8297c09431c"), new Guid("2ed99df9-d497-42a0-823a-1fb7b2361e80"), "https://i0.wp.com/www.rebeccadanzenbaker.com/wp-content/uploads/2022/02/perfect-family-photo-session-by-rebecca-danzenbaker.jpg?fit=2000%2C1333&ssl=1" },
                    { new Guid("10d88bf7-885e-417a-8b9a-6eaba75b81dd"), new Guid("2ed99df9-d497-42a0-823a-1fb7b2361e80"), "https://www.imgacademy.com/sites/default/files/img-academy-organization-schema.jpg" },
                    { new Guid("418ad749-8629-4e0d-9ac2-ad98075a5c2e"), new Guid("084075da-4814-4d6c-8dbf-d90629de3dc8"), "https://www.recordnet.com/gcdn/presto/2021/03/22/NRCD/9d9dd9e4-e84a-402e-ba8f-daa659e6e6c5-PhotoWord_003.JPG?width=660&height=425&fit=crop&format=pjpg&auto=web" },
                    { new Guid("43427eee-ebb2-4f00-9e15-a639f7321cc8"), new Guid("084075da-4814-4d6c-8dbf-d90629de3dc8"), "https://i0.wp.com/www.rebeccadanzenbaker.com/wp-content/uploads/2022/02/perfect-family-photo-session-by-rebecca-danzenbaker.jpg?fit=2000%2C1333&ssl=1" },
                    { new Guid("58608d3f-ae58-4377-ab4f-f4284fb6f24a"), new Guid("084075da-4814-4d6c-8dbf-d90629de3dc8"), "https://inhisimagephotography.com/wp-content/uploads/2023/07/dawayne-mcIntosh-family-0007-NR-retouched-portfolio-1200px.jpg" },
                    { new Guid("952aa442-d4dd-4042-a077-0b4199b4b191"), new Guid("084075da-4814-4d6c-8dbf-d90629de3dc8"), "https://thumbs.dreamstime.com/b/portrait-four-member-happy-family-posing-together-parents-wi-kids-93774342.jpg" },
                    { new Guid("ae48f911-9ad3-4c3c-8648-7220a55a277c"), new Guid("183dbb6c-4465-47e3-8097-78b75744c7cf"), "https://img.freepik.com/free-photo/wide-angle-shot-single-tree-growing-clouded-sky-during-sunset-surrounded-by-grass_181624-22807.jpg" },
                    { new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), new Guid("22222222-2222-2222-2222-222222222222"), "https://www.imgacademy.com/sites/default/files/img-academy-organization-schema.jpg" },
                    { new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"), new Guid("33333333-3333-3333-3333-333333333333"), "https://www.imgacademy.com/sites/default/files/img-academy-organization-schema.jpg" },
                    { new Guid("d03c8bf5-1d0d-43df-a2b9-6162cefbf4ef"), new Guid("11111111-1111-1111-1111-111111111111"), "https://www.imgacademy.com/sites/default/files/img-academy-organization-schema.jpg" },
                    { new Guid("d53c1e32-dd6b-4760-ae29-255ae8e44955"), new Guid("2ed99df9-d497-42a0-823a-1fb7b2361e80"), "https://img.freepik.com/free-photo/wide-angle-shot-single-tree-growing-clouded-sky-during-sunset-surrounded-by-grass_181624-22807.jpg" },
                    { new Guid("dba95707-4f3c-4c17-952b-922d582d969a"), new Guid("2ed99df9-d497-42a0-823a-1fb7b2361e80"), "https://inhisimagephotography.com/wp-content/uploads/2023/07/dawayne-mcIntosh-family-0007-NR-retouched-portfolio-1200px.jpg" },
                    { new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd"), new Guid("66666666-6666-6666-6666-666666666666"), "https://www.imgacademy.com/sites/default/files/img-academy-organization-schema.jpg" },
                    { new Guid("e056eb29-1729-4d5e-9888-7452a9a835d2"), new Guid("084075da-4814-4d6c-8dbf-d90629de3dc8"), "https://www.j-dphoto.com/images/news/04122015111102imgfamily00134170810526.jpg" },
                    { new Guid("e365aa17-581a-4235-a798-cbb84a2eba4f"), new Guid("88888888-8888-8888-8888-888888888888"), "https://img.freepik.com/free-photo/wide-angle-shot-single-tree-growing-clouded-sky-during-sunset-surrounded-by-grass_181624-22807.jpg" },
                    { new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"), new Guid("77777777-7777-7777-7777-777777777777"), "https://www.imgacademy.com/sites/default/files/img-academy-organization-schema.jpg" },
                    { new Guid("fa0fb6e2-3db5-4130-8c05-2515bc18f10e"), new Guid("084075da-4814-4d6c-8dbf-d90629de3dc8"), "https://bambiniphoto.sg/wp-content/uploads/family-photography-bambini-025.jpg" },
                    { new Guid("13523610-c5f4-48f6-886c-5ff622311591"), new Guid("6758f828-de3f-4a34-96dd-578b0b5f5a27"), "https://upload.wikimedia.org/wikipedia/commons/e/e5/Creating_music.jpg" },
                    { new Guid("13523610-c5f4-48f6-886c-5ff622311592"), new Guid("6758f828-de3f-4a34-96dd-578b0b5f5a27"), "https://upload.wikimedia.org/wikipedia/commons/4/43/Music_.jpg" },
                    { new Guid("13523610-c5f4-48f6-886c-5ff622311593"), new Guid("6011954d-12b7-4d95-9859-de453ac27f88"), "https://media.istockphoto.com/id/1457889029/photo/group-of-food-with-high-content-of-dietary-fiber-arranged-side-by-side.jpg?s=612x612&w=0&k=20&c=SEyObHsbBsrd1XZlgEg389VT86BMFKZKfKReKyVPAk4=" },
                    { new Guid("13523610-c5f4-48f6-886c-5ff622311594"), new Guid("6011954d-12b7-4d95-9859-de453ac27f88"), "https://www.foodiesfeed.com/wp-content/uploads/2023/06/burger-with-melted-cheese.jpg" },
                    { new Guid("13523610-c5f4-48f6-886c-5ff622311595"), new Guid("6011954d-12b7-4d95-9859-de453ac27f88"), "https://imageio.forbes.com/specials-images/imageserve/5faad4255239c9448d6c7bcd/Best-Animal-Photos-Contest--Close-Up-Of-baby-monkey/960x0.jpg?format=jpg&width=960" },
                    { new Guid("13523610-c5f4-48f6-886c-5ff622311596"), new Guid("e1541da6-4614-449a-b43c-7b70b905cb90"), "https://imageio.forbes.com/specials-images/imageserve/5faad4255239c9448d6c7bcd/Best-Animal-Photos-Contest--Close-Up-Of-baby-monkey/960x0.jpg?format=jpg&width=960" },
                    { new Guid("13523610-c5f4-48f6-886c-5ff622311597"), new Guid("e1541da6-4614-449a-b43c-7b70b905cb90"), "https://cdn.firstcry.com/education/2022/12/09170530/Herbivores-Carnivores-And-Omnivores-Animals-For-Kids.jpg" },
                    { new Guid("13523610-c5f4-48f6-886c-5ff622311598"), new Guid("e1541da6-4614-449a-b43c-7b70b905cb90"), "https://media.wired.com/photos/593261cab8eb31692072f129/master/pass/85120553.jpg" },
                    { new Guid("13523610-c5f4-48f6-886c-5ff622311599"), new Guid("bb7357f7-6a3e-4b27-a027-26e9ca140563"), "https://img.freepik.com/free-photo/wide-angle-shot-single-tree-growing-clouded-sky-during-sunset-surrounded-by-grass_181624-22807.jpg" },
                    { new Guid("6c270284-b086-47fb-a84c-e6938116329b"), new Guid("0b341388-15b5-49b6-a1dc-838199038a3f"), "https://img.freepik.com/free-photo/sports-tools_53876-138077.jpg" },
                    { new Guid("6dbf8f73-54fd-4e56-b51f-4ad99b4b0183"), new Guid("456671cb-bec1-4192-840c-0d12622b2341"), "https://www.j-dphoto.com/images/news/04122015111102imgfamily00134170810526.jpg" },
                    { new Guid("70d63ad3-e751-47f3-94ec-da29ccd41b06"), new Guid("0b341388-15b5-49b6-a1dc-838199038a3f"), "https://www.j-dphoto.com/images/news/04122015111102imgfamily00134170810526.jpg" },
                    { new Guid("73e0d3cb-196f-4e58-bd3a-811702ca6427"), new Guid("6011954d-12b7-4d95-9859-de453ac27f88"), "https://img.freepik.com/free-photo/fresh-pasta-with-hearty-bolognese-parmesan-cheese-generated-by-ai_188544-9469.jpg" },
                    { new Guid("8578a55a-9b66-4656-9dbb-a254e2b6b6ac"), new Guid("886741df-70ac-4cfe-830b-7c285a96d100"), "https://www.j-dphoto.com/images/news/04122015111102imgfamily00134170810526.jpg" },
                    { new Guid("bd0b93ea-95a8-4a49-bb61-084c738b9c60"), new Guid("0b341388-15b5-49b6-a1dc-838199038a3f"), "https://st4.depositphotos.com/1005563/25369/i/450/depositphotos_253697550-stock-photo-award-winning-championship-concept-trophy.jpg" },
                    { new Guid("bf1b7ff8-2c5b-4082-90ff-06a3229e265c"), new Guid("6758f828-de3f-4a34-96dd-578b0b5f5a27"), "https://png.pngtree.com/thumb_back/fh260/background/20230612/pngtree-art-music-background-image_2928765.jpg" },
                    { new Guid("d03e6a0f-45f0-4ac4-af8a-e00ec7f5d2e7"), new Guid("456671cb-bec1-4192-840c-0d12622b2341"), "https://www.j-dphoto.com/images/news/04122015111102imgfamily00134170810526.jpg" },
                    { new Guid("fbe41eb8-a69b-4738-966e-f859e3663cca"), new Guid("13781f37-1c81-487a-9dfd-5fb04458a071"), "https://www.imgacademy.com/sites/default/files/img-academy-organization-schema.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: new Guid("010b060a-9cf6-4d43-ab32-a8297c09431c"));

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: new Guid("10d88bf7-885e-417a-8b9a-6eaba75b81dd"));

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: new Guid("13523610-c5f4-48f6-886c-5ff622311591"));

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: new Guid("13523610-c5f4-48f6-886c-5ff622311592"));

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: new Guid("13523610-c5f4-48f6-886c-5ff622311593"));

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: new Guid("13523610-c5f4-48f6-886c-5ff622311594"));

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: new Guid("13523610-c5f4-48f6-886c-5ff622311595"));

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: new Guid("13523610-c5f4-48f6-886c-5ff622311596"));

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: new Guid("13523610-c5f4-48f6-886c-5ff622311597"));

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: new Guid("13523610-c5f4-48f6-886c-5ff622311598"));

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: new Guid("13523610-c5f4-48f6-886c-5ff622311599"));

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: new Guid("418ad749-8629-4e0d-9ac2-ad98075a5c2e"));

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: new Guid("43427eee-ebb2-4f00-9e15-a639f7321cc8"));

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: new Guid("58608d3f-ae58-4377-ab4f-f4284fb6f24a"));

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: new Guid("6c270284-b086-47fb-a84c-e6938116329b"));

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: new Guid("6dbf8f73-54fd-4e56-b51f-4ad99b4b0183"));

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: new Guid("70d63ad3-e751-47f3-94ec-da29ccd41b06"));

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: new Guid("73e0d3cb-196f-4e58-bd3a-811702ca6427"));

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: new Guid("8578a55a-9b66-4656-9dbb-a254e2b6b6ac"));

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: new Guid("952aa442-d4dd-4042-a077-0b4199b4b191"));

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: new Guid("ae48f911-9ad3-4c3c-8648-7220a55a277c"));

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"));

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: new Guid("bd0b93ea-95a8-4a49-bb61-084c738b9c60"));

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: new Guid("bf1b7ff8-2c5b-4082-90ff-06a3229e265c"));

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"));

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: new Guid("d03c8bf5-1d0d-43df-a2b9-6162cefbf4ef"));

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: new Guid("d03e6a0f-45f0-4ac4-af8a-e00ec7f5d2e7"));

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: new Guid("d53c1e32-dd6b-4760-ae29-255ae8e44955"));

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: new Guid("dba95707-4f3c-4c17-952b-922d582d969a"));

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd"));

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: new Guid("e056eb29-1729-4d5e-9888-7452a9a835d2"));

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: new Guid("e365aa17-581a-4235-a798-cbb84a2eba4f"));

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"));

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: new Guid("fa0fb6e2-3db5-4130-8c05-2515bc18f10e"));

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: new Guid("fbe41eb8-a69b-4738-966e-f859e3663cca"));

            migrationBuilder.DeleteData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: new Guid("0b341388-15b5-49b6-a1dc-838199038a3f"));

            migrationBuilder.DeleteData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: new Guid("13781f37-1c81-487a-9dfd-5fb04458a071"));

            migrationBuilder.DeleteData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: new Guid("456671cb-bec1-4192-840c-0d12622b2341"));

            migrationBuilder.DeleteData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: new Guid("6011954d-12b7-4d95-9859-de453ac27f88"));

            migrationBuilder.DeleteData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: new Guid("6758f828-de3f-4a34-96dd-578b0b5f5a27"));

            migrationBuilder.DeleteData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: new Guid("886741df-70ac-4cfe-830b-7c285a96d100"));

            migrationBuilder.DeleteData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: new Guid("bb7357f7-6a3e-4b27-a027-26e9ca140563"));

            migrationBuilder.DeleteData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: new Guid("e1541da6-4614-449a-b43c-7b70b905cb90"));

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: new Guid("084075da-4814-4d6c-8dbf-d90629de3dc8"),
                column: "ImgUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: new Guid("183dbb6c-4465-47e3-8097-78b75744c7cf"),
                column: "ImgUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: new Guid("2ed99df9-d497-42a0-823a-1fb7b2361e80"),
                column: "ImgUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                column: "ImgUrl",
                value: "https://www.imgacademy.com/sites/default/files/img-academy-organization-schema.jpg");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "69c82957-43ea-4f23-9efc-0eac834e3486", "AQAAAAIAAYagAAAAEGR2sBH6VLnYUbFK6Sdqzpgt1SllzXdh+JGXyiaOwugXOoGKqDn8GJJz1ZGA2yFEtw==" });
        }
    }
}
