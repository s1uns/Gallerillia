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
                new Album { Id = new Guid("88888888-8888-8888-8888-888888888888"), AuthorId = new Guid("22222222-2222-2222-2222-222222222222"), Title = "Something", ImgUrl = "https://www.imgacademy.com/sites/default/files/img-academy-organization-schema.jpg" },
                new Album { Id = new Guid("2ed99df9-d497-42a0-823a-1fb7b2361e80"), AuthorId = new Guid("33333333-3333-3333-3333-333333333333"), Title = "Nature" },
                new Album { Id = new Guid("084075da-4814-4d6c-8dbf-d90629de3dc8"), AuthorId = new Guid("33333333-3333-3333-3333-333333333333"), Title = "Family" },
                new Album { Id = new Guid("183dbb6c-4465-47e3-8097-78b75744c7cf"), AuthorId = new Guid("33333333-3333-3333-3333-333333333333"), Title = "Something" }
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
                new Picture { Id = new Guid("09b0ce84-1a29-424d-a149-47daf09a9adb"), AlbumId = new Guid("88888888-8888-8888-8888-888888888888"), ImgUrl = "https://img.freepik.com/free-photo/wide-angle-shot-single-tree-growing-clouded-sky-during-sunset-surrounded-by-grass_181624-22807.jpg" }

                );




        }
    }



}
