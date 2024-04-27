using Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {

        private readonly IConfiguration _configuration;


        public required DbSet<Album> Albums { get; set; }
        public required DbSet<Picture> Pictures { get; set; }
        public required DbSet<User> OrdinaryUsers { get; set; }
        public required DbSet<Vote> Votes { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration)
        : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            const string ADMIN_ID = "a18be9c0-aa65-4af8-bd17-00bd9344e575";
            const string ROLE_ID = "ad376a8f-9eab-4bb9-9fca-30b01540f445";

            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = ROLE_ID,
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR"
            });

            var hasher = new PasswordHasher<IdentityUser>();
            builder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = ADMIN_ID,
                UserName = _configuration.GetRequiredSection("ADMIN")["EMAIL"],
                NormalizedUserName = _configuration.GetRequiredSection("ADMIN")["EMAIL"],
                Email = _configuration.GetRequiredSection("ADMIN")["EMAIL"],
                NormalizedEmail = _configuration.GetRequiredSection("ADMIN")["EMAIL"].ToUpper(),
                EmailConfirmed = false,
                PasswordHash = hasher.HashPassword(null, _configuration.GetRequiredSection("ADMIN")["PASSWORD"]),
                SecurityStamp = string.Empty
            });

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_ID,
                UserId = ADMIN_ID
            });

            builder.Entity<User>().HasData(new User
            {
                Id = new Guid(ADMIN_ID),
                Email = _configuration.GetRequiredSection("ADMIN")["EMAIL"]
            });

            builder.Entity<User>().HasData(
            new User { Id = new Guid("11111111-1111-1111-1111-111111111111"), Email = "user1@example.com" },
            new User { Id = new Guid("22222222-2222-2222-2222-222222222222"), Email = "user2@example.com" },
            new User { Id = new Guid("33333333-3333-3333-3333-333333333333"), Email = "user3@example.com" });


            builder.Entity<Album>().HasData(
                new Album { Id = new Guid("11111111-1111-1111-1111-111111111111"), AuthorId = new Guid("11111111-1111-1111-1111-111111111111"), Title = "Nature", ImgUrl = "https://www.imgacademy.com/sites/default/files/img-academy-organization-schema.jpg" },
                new Album { Id = new Guid("22222222-2222-2222-2222-222222222222"), AuthorId = new Guid("11111111-1111-1111-1111-111111111111"), Title = "Family", ImgUrl = "https://www.imgacademy.com/sites/default/files/img-academy-organization-schema.jpg" },
                new Album { Id = new Guid("33333333-3333-3333-3333-333333333333"), AuthorId = new Guid("11111111-1111-1111-1111-111111111111"), Title = "Travel", ImgUrl = "https://www.imgacademy.com/sites/default/files/img-academy-organization-schema.jpg" },

                new Album { Id = new Guid("66666666-6666-6666-6666-666666666666"), AuthorId = new Guid("22222222-2222-2222-2222-222222222222"), Title = "Nature", ImgUrl = "https://www.imgacademy.com/sites/default/files/img-academy-organization-schema.jpg" },
                new Album { Id = new Guid("77777777-7777-7777-7777-777777777777"), AuthorId = new Guid("22222222-2222-2222-2222-222222222222"), Title = "Family" },
                new Album { Id = new Guid("88888888-8888-8888-8888-888888888888"), AuthorId = new Guid("22222222-2222-2222-2222-222222222222"), Title = "Something", ImgUrl = "https://img.freepik.com/free-photo/wide-angle-shot-single-tree-growing-clouded-sky-during-sunset-surrounded-by-grass_181624-22807.jpg" },
                new Album { Id = new Guid("2ed99df9-d497-42a0-823a-1fb7b2361e80"), AuthorId = new Guid("33333333-3333-3333-3333-333333333333"), Title = "Nature", ImgUrl= "https://img.freepik.com/free-photo/wide-angle-shot-single-tree-growing-clouded-sky-during-sunset-surrounded-by-grass_181624-22807.jpg" },
                new Album { Id = new Guid("084075da-4814-4d6c-8dbf-d90629de3dc8"), AuthorId = new Guid("33333333-3333-3333-3333-333333333333"), Title = "Family", ImgUrl = "https://www.recordnet.com/gcdn/presto/2021/03/22/NRCD/9d9dd9e4-e84a-402e-ba8f-daa659e6e6c5-PhotoWord_003.JPG?width=660&height=425&fit=crop&format=pjpg&auto=web" },
                new Album { Id = new Guid("183dbb6c-4465-47e3-8097-78b75744c7cf"), AuthorId = new Guid("33333333-3333-3333-3333-333333333333"), Title = "Something", ImgUrl = "https://img.freepik.com/free-photo/wide-angle-shot-single-tree-growing-clouded-sky-during-sunset-surrounded-by-grass_181624-22807.jpg" },
                new Album { Id = new Guid("13781f37-1c81-487a-9dfd-5fb04458a071"), AuthorId = new Guid("11111111-1111-1111-1111-111111111111"), Title = "History", ImgUrl = "https://www.imgacademy.com/sites/default/files/img-academy-organization-schema.jpg" },
                new Album { Id = new Guid("886741df-70ac-4cfe-830b-7c285a96d100"), AuthorId = new Guid("11111111-1111-1111-1111-111111111111"), Title = "Science", ImgUrl = "https://www.j-dphoto.com/images/news/04122015111102imgfamily00134170810526.jpg" },
                new Album { Id = new Guid("456671cb-bec1-4192-840c-0d12622b2341"), AuthorId = new Guid("22222222-2222-2222-2222-222222222222"), Title = "Art", ImgUrl = "https://www.j-dphoto.com/images/news/04122015111102imgfamily00134170810526.jpg" },
                new Album { Id = new Guid("6758f828-de3f-4a34-96dd-578b0b5f5a27"), AuthorId = new Guid("22222222-2222-2222-2222-222222222222"), Title = "Music", ImgUrl = "https://upload.wikimedia.org/wikipedia/commons/e/e5/Creating_music.jpg" },
                new Album { Id = new Guid("0b341388-15b5-49b6-a1dc-838199038a3f"), AuthorId = new Guid("33333333-3333-3333-3333-333333333333"), Title = "Sports", ImgUrl = "https://img.freepik.com/free-photo/sports-tools_53876-138077.jpg" },
                new Album { Id = new Guid("bb7357f7-6a3e-4b27-a027-26e9ca140563"), AuthorId = new Guid("33333333-3333-3333-3333-333333333333"), Title = "Cars", ImgUrl = "https://img.freepik.com/free-photo/wide-angle-shot-single-tree-growing-clouded-sky-during-sunset-surrounded-by-grass_181624-22807.jpg" },
                new Album { Id = new Guid("e1541da6-4614-449a-b43c-7b70b905cb90"), AuthorId = new Guid("11111111-1111-1111-1111-111111111111"), Title = "Animals", ImgUrl = "https://imageio.forbes.com/specials-images/imageserve/5faad4255239c9448d6c7bcd/Best-Animal-Photos-Contest--Close-Up-Of-baby-monkey/960x0.jpg?format=jpg&width=960" },
                new Album { Id = new Guid("6011954d-12b7-4d95-9859-de453ac27f88"), AuthorId = new Guid("22222222-2222-2222-2222-222222222222"), Title = "Food" , ImgUrl = "https://media.istockphoto.com/id/1457889029/photo/group-of-food-with-high-content-of-dietary-fiber-arranged-side-by-side.jpg?s=612x612&w=0&k=20&c=SEyObHsbBsrd1XZlgEg389VT86BMFKZKfKReKyVPAk4=" }
                );

            builder.Entity<Picture>().HasData(
                new Picture { Id = new Guid("11111111-1111-1111-1111-111111111111"), AlbumId = new Guid("11111111-1111-1111-1111-111111111111"), ImgUrl = "https://www.imgacademy.com/sites/default/files/img-academy-organization-schema.jpg" },
                new Picture { Id = new Guid("22222222-2222-2222-2222-222222222222"), AlbumId = new Guid("11111111-1111-1111-1111-111111111111"), ImgUrl = "https://img.freepik.com/free-photo/wide-angle-shot-single-tree-growing-clouded-sky-during-sunset-surrounded-by-grass_181624-22807.jpg" },
                new Picture { Id = new Guid("55555555-5555-5555-5555-555555555555"), AlbumId = new Guid("11111111-1111-1111-1111-111111111111"), ImgUrl = "https://www.imgacademy.com/sites/default/files/img-academy-organization-schema.jpg" },
                new Picture { Id = new Guid("66666666-6666-6666-6666-666666666666"), AlbumId = new Guid("22222222-2222-2222-2222-222222222222"), ImgUrl = "https://www.imgacademy.com/sites/default/files/img-academy-organization-schema.jpg" },
                new Picture { Id = new Guid("44444444-4444-4444-4444-444444444444"), AlbumId = new Guid("22222222-2222-2222-2222-222222222222"), ImgUrl = "https://www.imgacademy.com/sites/default/files/img-academy-organization-schema.jpg" },
                new Picture { Id = new Guid("77777777-7777-7777-7777-777777777777"), AlbumId = new Guid("22222222-2222-2222-2222-222222222222"), ImgUrl = "https://img.freepik.com/free-photo/wide-angle-shot-single-tree-growing-clouded-sky-during-sunset-surrounded-by-grass_181624-22807.jpg" },
                new Picture { Id = new Guid("88888888-8888-8888-8888-888888888888"), AlbumId = new Guid("33333333-3333-3333-3333-333333333333"), ImgUrl = "https://www.imgacademy.com/sites/default/files/img-academy-organization-schema.jpg" },
                new Picture { Id = new Guid("99999999-9999-9999-9999-999999999999"), AlbumId = new Guid("33333333-3333-3333-3333-333333333333"), ImgUrl = "https://img.freepik.com/free-photo/wide-angle-shot-single-tree-growing-clouded-sky-during-sunset-surrounded-by-grass_181624-22807.jpg" },
                new Picture { Id = new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), AlbumId = new Guid("88888888-8888-8888-8888-888888888888"), ImgUrl = "https://www.imgacademy.com/sites/default/files/img-academy-organization-schema.jpg" },
                new Picture { Id = new Guid("afad7ba2-98aa-4010-b965-0c5c223eace3"), AlbumId = new Guid("88888888-8888-8888-8888-888888888888"), ImgUrl = "https://www.imgacademy.com/sites/default/files/img-academy-organization-schema.jpg" },
                new Picture { Id = new Guid("462ba917-573f-4e76-8f6c-a1d9323c1b3b"), AlbumId = new Guid("66666666-6666-6666-6666-666666666666"), ImgUrl = "https://www.imgacademy.com/sites/default/files/img-academy-organization-schema.jpg" },
                new Picture { Id = new Guid("60ca3fde-6539-4651-8e1a-0fd6e116d41f"), AlbumId = new Guid("66666666-6666-6666-6666-666666666666"), ImgUrl = "https://www.imgacademy.com/sites/default/files/img-academy-organization-schema.jpg" },
                new Picture { Id = new Guid("c263fcb6-4360-416d-8274-b6c1cbed34eb"), AlbumId = new Guid("66666666-6666-6666-6666-666666666666"), ImgUrl = "https://img.freepik.com/free-photo/wide-angle-shot-single-tree-growing-clouded-sky-during-sunset-surrounded-by-grass_181624-22807.jpg" },
                new Picture { Id = new Guid("da743ff3-7330-4c10-aa7b-44eee6bfa727"), AlbumId = new Guid("66666666-6666-6666-6666-666666666666"), ImgUrl = "https://img.freepik.com/free-photo/wide-angle-shot-single-tree-growing-clouded-sky-during-sunset-surrounded-by-grass_181624-22807.jpg" },
                new Picture { Id = new Guid("09b0ce84-1a29-424d-a149-47daf09a9adb"), AlbumId = new Guid("88888888-8888-8888-8888-888888888888"), ImgUrl = "https://img.freepik.com/free-photo/wide-angle-shot-single-tree-growing-clouded-sky-during-sunset-surrounded-by-grass_181624-22807.jpg" },
                new Picture { Id = new Guid("d03c8bf5-1d0d-43df-a2b9-6162cefbf4ef"), AlbumId = new Guid("11111111-1111-1111-1111-111111111111"), ImgUrl = "https://www.imgacademy.com/sites/default/files/img-academy-organization-schema.jpg" },
                new Picture { Id = new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), AlbumId = new Guid("22222222-2222-2222-2222-222222222222"), ImgUrl = "https://www.imgacademy.com/sites/default/files/img-academy-organization-schema.jpg" },
                new Picture { Id = new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"), AlbumId = new Guid("33333333-3333-3333-3333-333333333333"), ImgUrl = "https://www.imgacademy.com/sites/default/files/img-academy-organization-schema.jpg" },
                new Picture { Id = new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd"), AlbumId = new Guid("66666666-6666-6666-6666-666666666666"), ImgUrl = "https://www.imgacademy.com/sites/default/files/img-academy-organization-schema.jpg" },
                new Picture { Id = new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"), AlbumId = new Guid("77777777-7777-7777-7777-777777777777"), ImgUrl = "https://www.imgacademy.com/sites/default/files/img-academy-organization-schema.jpg" },
                new Picture { Id = new Guid("e365aa17-581a-4235-a798-cbb84a2eba4f"), AlbumId = new Guid("88888888-8888-8888-8888-888888888888"), ImgUrl = "https://img.freepik.com/free-photo/wide-angle-shot-single-tree-growing-clouded-sky-during-sunset-surrounded-by-grass_181624-22807.jpg" },
                new Picture { Id = new Guid("10d88bf7-885e-417a-8b9a-6eaba75b81dd"), AlbumId = new Guid("2ed99df9-d497-42a0-823a-1fb7b2361e80"), ImgUrl = "https://www.imgacademy.com/sites/default/files/img-academy-organization-schema.jpg" },
                new Picture { Id = new Guid("e056eb29-1729-4d5e-9888-7452a9a835d2"), AlbumId = new Guid("084075da-4814-4d6c-8dbf-d90629de3dc8"), ImgUrl = "https://www.j-dphoto.com/images/news/04122015111102imgfamily00134170810526.jpg" },
                new Picture { Id = new Guid("ae48f911-9ad3-4c3c-8648-7220a55a277c"), AlbumId = new Guid("183dbb6c-4465-47e3-8097-78b75744c7cf"), ImgUrl = "https://img.freepik.com/free-photo/wide-angle-shot-single-tree-growing-clouded-sky-during-sunset-surrounded-by-grass_181624-22807.jpg" },
                new Picture { Id = new Guid("fbe41eb8-a69b-4738-966e-f859e3663cca"), AlbumId = new Guid("13781f37-1c81-487a-9dfd-5fb04458a071"), ImgUrl = "https://www.imgacademy.com/sites/default/files/img-academy-organization-schema.jpg" },
                new Picture { Id = new Guid("8578a55a-9b66-4656-9dbb-a254e2b6b6ac"), AlbumId = new Guid("886741df-70ac-4cfe-830b-7c285a96d100"), ImgUrl = "https://www.j-dphoto.com/images/news/04122015111102imgfamily00134170810526.jpg" },
                new Picture { Id = new Guid("d03e6a0f-45f0-4ac4-af8a-e00ec7f5d2e7"), AlbumId = new Guid("456671cb-bec1-4192-840c-0d12622b2341"), ImgUrl = "https://www.j-dphoto.com/images/news/04122015111102imgfamily00134170810526.jpg" },
                new Picture { Id = new Guid("6dbf8f73-54fd-4e56-b51f-4ad99b4b0183"), AlbumId = new Guid("456671cb-bec1-4192-840c-0d12622b2341"), ImgUrl = "https://www.j-dphoto.com/images/news/04122015111102imgfamily00134170810526.jpg" },
                new Picture { Id = new Guid("70d63ad3-e751-47f3-94ec-da29ccd41b06"), AlbumId = new Guid("0b341388-15b5-49b6-a1dc-838199038a3f"), ImgUrl = "https://www.j-dphoto.com/images/news/04122015111102imgfamily00134170810526.jpg" },
                new Picture { Id = new Guid("6c270284-b086-47fb-a84c-e6938116329b"), AlbumId = new Guid("0b341388-15b5-49b6-a1dc-838199038a3f"), ImgUrl = "https://img.freepik.com/free-photo/sports-tools_53876-138077.jpg" },
                new Picture { Id = new Guid("bd0b93ea-95a8-4a49-bb61-084c738b9c60"), AlbumId = new Guid("0b341388-15b5-49b6-a1dc-838199038a3f"), ImgUrl = "https://st4.depositphotos.com/1005563/25369/i/450/depositphotos_253697550-stock-photo-award-winning-championship-concept-trophy.jpg" },
                new Picture { Id = new Guid("13523610-c5f4-48f6-886c-5ff622311599"), AlbumId = new Guid("bb7357f7-6a3e-4b27-a027-26e9ca140563"), ImgUrl = "https://img.freepik.com/free-photo/wide-angle-shot-single-tree-growing-clouded-sky-during-sunset-surrounded-by-grass_181624-22807.jpg" },
                new Picture { Id = new Guid("13523610-c5f4-48f6-886c-5ff622311598"), AlbumId = new Guid("e1541da6-4614-449a-b43c-7b70b905cb90"), ImgUrl = "https://media.wired.com/photos/593261cab8eb31692072f129/master/pass/85120553.jpg" },                
                new Picture { Id = new Guid("13523610-c5f4-48f6-886c-5ff622311597"), AlbumId = new Guid("e1541da6-4614-449a-b43c-7b70b905cb90"), ImgUrl = "https://cdn.firstcry.com/education/2022/12/09170530/Herbivores-Carnivores-And-Omnivores-Animals-For-Kids.jpg" }, 
                new Picture { Id = new Guid("13523610-c5f4-48f6-886c-5ff622311596"), AlbumId = new Guid("e1541da6-4614-449a-b43c-7b70b905cb90"), ImgUrl = "https://imageio.forbes.com/specials-images/imageserve/5faad4255239c9448d6c7bcd/Best-Animal-Photos-Contest--Close-Up-Of-baby-monkey/960x0.jpg?format=jpg&width=960" },
                new Picture { Id = new Guid("13523610-c5f4-48f6-886c-5ff622311595"), AlbumId = new Guid("6011954d-12b7-4d95-9859-de453ac27f88"), ImgUrl = "https://imageio.forbes.com/specials-images/imageserve/5faad4255239c9448d6c7bcd/Best-Animal-Photos-Contest--Close-Up-Of-baby-monkey/960x0.jpg?format=jpg&width=960" },
                new Picture { Id = new Guid("13523610-c5f4-48f6-886c-5ff622311594"), AlbumId = new Guid("6011954d-12b7-4d95-9859-de453ac27f88"), ImgUrl = "https://www.foodiesfeed.com/wp-content/uploads/2023/06/burger-with-melted-cheese.jpg" },
                new Picture { Id = new Guid("13523610-c5f4-48f6-886c-5ff622311593"), AlbumId = new Guid("6011954d-12b7-4d95-9859-de453ac27f88"), ImgUrl = "https://media.istockphoto.com/id/1457889029/photo/group-of-food-with-high-content-of-dietary-fiber-arranged-side-by-side.jpg?s=612x612&w=0&k=20&c=SEyObHsbBsrd1XZlgEg389VT86BMFKZKfKReKyVPAk4=" },                
                new Picture { Id = new Guid("13523610-c5f4-48f6-886c-5ff622311592"), AlbumId = new Guid("6758f828-de3f-4a34-96dd-578b0b5f5a27"), ImgUrl = "https://upload.wikimedia.org/wikipedia/commons/4/43/Music_.jpg" },                
                new Picture { Id = new Guid("13523610-c5f4-48f6-886c-5ff622311591"), AlbumId = new Guid("6758f828-de3f-4a34-96dd-578b0b5f5a27"), ImgUrl = "https://upload.wikimedia.org/wikipedia/commons/e/e5/Creating_music.jpg" },                
                new Picture { Id = new Guid("bf1b7ff8-2c5b-4082-90ff-06a3229e265c"), AlbumId = new Guid("6758f828-de3f-4a34-96dd-578b0b5f5a27"), ImgUrl = "https://png.pngtree.com/thumb_back/fh260/background/20230612/pngtree-art-music-background-image_2928765.jpg" },
                new Picture { Id = new Guid("952aa442-d4dd-4042-a077-0b4199b4b191"), AlbumId = new Guid("084075da-4814-4d6c-8dbf-d90629de3dc8"), ImgUrl = "https://thumbs.dreamstime.com/b/portrait-four-member-happy-family-posing-together-parents-wi-kids-93774342.jpg" },
                new Picture { Id = new Guid("418ad749-8629-4e0d-9ac2-ad98075a5c2e"), AlbumId = new Guid("084075da-4814-4d6c-8dbf-d90629de3dc8"), ImgUrl = "https://www.recordnet.com/gcdn/presto/2021/03/22/NRCD/9d9dd9e4-e84a-402e-ba8f-daa659e6e6c5-PhotoWord_003.JPG?width=660&height=425&fit=crop&format=pjpg&auto=web" },
                new Picture { Id = new Guid("fa0fb6e2-3db5-4130-8c05-2515bc18f10e"), AlbumId = new Guid("084075da-4814-4d6c-8dbf-d90629de3dc8"), ImgUrl = "https://bambiniphoto.sg/wp-content/uploads/family-photography-bambini-025.jpg" },
                new Picture { Id = new Guid("43427eee-ebb2-4f00-9e15-a639f7321cc8"), AlbumId = new Guid("084075da-4814-4d6c-8dbf-d90629de3dc8"), ImgUrl = "https://i0.wp.com/www.rebeccadanzenbaker.com/wp-content/uploads/2022/02/perfect-family-photo-session-by-rebecca-danzenbaker.jpg?fit=2000%2C1333&ssl=1" },
                new Picture { Id = new Guid("58608d3f-ae58-4377-ab4f-f4284fb6f24a"), AlbumId = new Guid("084075da-4814-4d6c-8dbf-d90629de3dc8"), ImgUrl = "https://inhisimagephotography.com/wp-content/uploads/2023/07/dawayne-mcIntosh-family-0007-NR-retouched-portfolio-1200px.jpg" },                
                new Picture { Id = new Guid("d53c1e32-dd6b-4760-ae29-255ae8e44955"), AlbumId = new Guid("2ed99df9-d497-42a0-823a-1fb7b2361e80"), ImgUrl = "https://img.freepik.com/free-photo/wide-angle-shot-single-tree-growing-clouded-sky-during-sunset-surrounded-by-grass_181624-22807.jpg" },
                new Picture { Id = new Guid("010b060a-9cf6-4d43-ab32-a8297c09431c"), AlbumId = new Guid("2ed99df9-d497-42a0-823a-1fb7b2361e80"), ImgUrl = "https://i0.wp.com/www.rebeccadanzenbaker.com/wp-content/uploads/2022/02/perfect-family-photo-session-by-rebecca-danzenbaker.jpg?fit=2000%2C1333&ssl=1" },
                new Picture { Id = new Guid("dba95707-4f3c-4c17-952b-922d582d969a"), AlbumId = new Guid("2ed99df9-d497-42a0-823a-1fb7b2361e80"), ImgUrl = "https://inhisimagephotography.com/wp-content/uploads/2023/07/dawayne-mcIntosh-family-0007-NR-retouched-portfolio-1200px.jpg" },
                new Picture { Id = new Guid("73e0d3cb-196f-4e58-bd3a-811702ca6427"), AlbumId = new Guid("6011954d-12b7-4d95-9859-de453ac27f88"), ImgUrl = "https://img.freepik.com/free-photo/fresh-pasta-with-hearty-bolognese-parmesan-cheese-generated-by-ai_188544-9469.jpg" });




        }
    }



}
