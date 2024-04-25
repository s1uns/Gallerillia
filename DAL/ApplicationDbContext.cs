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
        }
    }



}
