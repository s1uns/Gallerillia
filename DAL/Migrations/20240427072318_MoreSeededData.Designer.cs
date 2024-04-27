﻿// <auto-generated />
using System;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240427072318_MoreSeededData")]
    partial class MoreSeededData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Core.Models.Album", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("char(36)");

                    b.Property<string>("ImgUrl")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Albums");

                    b.HasData(
                        new
                        {
                            Id = new Guid("11111111-1111-1111-1111-111111111111"),
                            AuthorId = new Guid("11111111-1111-1111-1111-111111111111"),
                            ImgUrl = "https://www.imgacademy.com/sites/default/files/img-academy-organization-schema.jpg",
                            Title = "Nature"
                        },
                        new
                        {
                            Id = new Guid("22222222-2222-2222-2222-222222222222"),
                            AuthorId = new Guid("11111111-1111-1111-1111-111111111111"),
                            ImgUrl = "https://www.imgacademy.com/sites/default/files/img-academy-organization-schema.jpg",
                            Title = "Family"
                        },
                        new
                        {
                            Id = new Guid("33333333-3333-3333-3333-333333333333"),
                            AuthorId = new Guid("11111111-1111-1111-1111-111111111111"),
                            ImgUrl = "https://www.imgacademy.com/sites/default/files/img-academy-organization-schema.jpg",
                            Title = "Travel"
                        },
                        new
                        {
                            Id = new Guid("66666666-6666-6666-6666-666666666666"),
                            AuthorId = new Guid("22222222-2222-2222-2222-222222222222"),
                            ImgUrl = "https://www.imgacademy.com/sites/default/files/img-academy-organization-schema.jpg",
                            Title = "Nature"
                        },
                        new
                        {
                            Id = new Guid("77777777-7777-7777-7777-777777777777"),
                            AuthorId = new Guid("22222222-2222-2222-2222-222222222222"),
                            ImgUrl = "",
                            Title = "Family"
                        },
                        new
                        {
                            Id = new Guid("88888888-8888-8888-8888-888888888888"),
                            AuthorId = new Guid("22222222-2222-2222-2222-222222222222"),
                            ImgUrl = "https://www.imgacademy.com/sites/default/files/img-academy-organization-schema.jpg",
                            Title = "Something"
                        },
                        new
                        {
                            Id = new Guid("2ed99df9-d497-42a0-823a-1fb7b2361e80"),
                            AuthorId = new Guid("33333333-3333-3333-3333-333333333333"),
                            ImgUrl = "",
                            Title = "Nature"
                        },
                        new
                        {
                            Id = new Guid("084075da-4814-4d6c-8dbf-d90629de3dc8"),
                            AuthorId = new Guid("33333333-3333-3333-3333-333333333333"),
                            ImgUrl = "",
                            Title = "Family"
                        },
                        new
                        {
                            Id = new Guid("183dbb6c-4465-47e3-8097-78b75744c7cf"),
                            AuthorId = new Guid("33333333-3333-3333-3333-333333333333"),
                            ImgUrl = "",
                            Title = "Something"
                        });
                });

            modelBuilder.Entity("Core.Models.Picture", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("AlbumId")
                        .HasColumnType("char(36)");

                    b.Property<string>("ImgUrl")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("AlbumId");

                    b.ToTable("Pictures");

                    b.HasData(
                        new
                        {
                            Id = new Guid("11111111-1111-1111-1111-111111111111"),
                            AlbumId = new Guid("11111111-1111-1111-1111-111111111111"),
                            ImgUrl = "https://www.imgacademy.com/sites/default/files/img-academy-organization-schema.jpg"
                        },
                        new
                        {
                            Id = new Guid("22222222-2222-2222-2222-222222222222"),
                            AlbumId = new Guid("11111111-1111-1111-1111-111111111111"),
                            ImgUrl = "https://img.freepik.com/free-photo/wide-angle-shot-single-tree-growing-clouded-sky-during-sunset-surrounded-by-grass_181624-22807.jpg"
                        },
                        new
                        {
                            Id = new Guid("55555555-5555-5555-5555-555555555555"),
                            AlbumId = new Guid("11111111-1111-1111-1111-111111111111"),
                            ImgUrl = "https://www.imgacademy.com/sites/default/files/img-academy-organization-schema.jpg"
                        },
                        new
                        {
                            Id = new Guid("66666666-6666-6666-6666-666666666666"),
                            AlbumId = new Guid("22222222-2222-2222-2222-222222222222"),
                            ImgUrl = "https://www.imgacademy.com/sites/default/files/img-academy-organization-schema.jpg"
                        },
                        new
                        {
                            Id = new Guid("44444444-4444-4444-4444-444444444444"),
                            AlbumId = new Guid("22222222-2222-2222-2222-222222222222"),
                            ImgUrl = "https://www.imgacademy.com/sites/default/files/img-academy-organization-schema.jpg"
                        },
                        new
                        {
                            Id = new Guid("77777777-7777-7777-7777-777777777777"),
                            AlbumId = new Guid("22222222-2222-2222-2222-222222222222"),
                            ImgUrl = "https://img.freepik.com/free-photo/wide-angle-shot-single-tree-growing-clouded-sky-during-sunset-surrounded-by-grass_181624-22807.jpg"
                        },
                        new
                        {
                            Id = new Guid("88888888-8888-8888-8888-888888888888"),
                            AlbumId = new Guid("33333333-3333-3333-3333-333333333333"),
                            ImgUrl = "https://www.imgacademy.com/sites/default/files/img-academy-organization-schema.jpg"
                        },
                        new
                        {
                            Id = new Guid("99999999-9999-9999-9999-999999999999"),
                            AlbumId = new Guid("33333333-3333-3333-3333-333333333333"),
                            ImgUrl = "https://img.freepik.com/free-photo/wide-angle-shot-single-tree-growing-clouded-sky-during-sunset-surrounded-by-grass_181624-22807.jpg"
                        },
                        new
                        {
                            Id = new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                            AlbumId = new Guid("88888888-8888-8888-8888-888888888888"),
                            ImgUrl = "https://www.imgacademy.com/sites/default/files/img-academy-organization-schema.jpg"
                        },
                        new
                        {
                            Id = new Guid("afad7ba2-98aa-4010-b965-0c5c223eace3"),
                            AlbumId = new Guid("88888888-8888-8888-8888-888888888888"),
                            ImgUrl = "https://www.imgacademy.com/sites/default/files/img-academy-organization-schema.jpg"
                        },
                        new
                        {
                            Id = new Guid("462ba917-573f-4e76-8f6c-a1d9323c1b3b"),
                            AlbumId = new Guid("66666666-6666-6666-6666-666666666666"),
                            ImgUrl = "https://www.imgacademy.com/sites/default/files/img-academy-organization-schema.jpg"
                        },
                        new
                        {
                            Id = new Guid("60ca3fde-6539-4651-8e1a-0fd6e116d41f"),
                            AlbumId = new Guid("66666666-6666-6666-6666-666666666666"),
                            ImgUrl = "https://www.imgacademy.com/sites/default/files/img-academy-organization-schema.jpg"
                        },
                        new
                        {
                            Id = new Guid("c263fcb6-4360-416d-8274-b6c1cbed34eb"),
                            AlbumId = new Guid("66666666-6666-6666-6666-666666666666"),
                            ImgUrl = "https://img.freepik.com/free-photo/wide-angle-shot-single-tree-growing-clouded-sky-during-sunset-surrounded-by-grass_181624-22807.jpg"
                        },
                        new
                        {
                            Id = new Guid("da743ff3-7330-4c10-aa7b-44eee6bfa727"),
                            AlbumId = new Guid("66666666-6666-6666-6666-666666666666"),
                            ImgUrl = "https://img.freepik.com/free-photo/wide-angle-shot-single-tree-growing-clouded-sky-during-sunset-surrounded-by-grass_181624-22807.jpg"
                        },
                        new
                        {
                            Id = new Guid("09b0ce84-1a29-424d-a149-47daf09a9adb"),
                            AlbumId = new Guid("88888888-8888-8888-8888-888888888888"),
                            ImgUrl = "https://img.freepik.com/free-photo/wide-angle-shot-single-tree-growing-clouded-sky-during-sunset-surrounded-by-grass_181624-22807.jpg"
                        });
                });

            modelBuilder.Entity("Core.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("OrdinaryUsers");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a18be9c0-aa65-4af8-bd17-00bd9344e575"),
                            Email = "illiateliuk@gmail.com"
                        },
                        new
                        {
                            Id = new Guid("11111111-1111-1111-1111-111111111111"),
                            Email = "user1@example.com"
                        },
                        new
                        {
                            Id = new Guid("22222222-2222-2222-2222-222222222222"),
                            Email = "user2@example.com"
                        },
                        new
                        {
                            Id = new Guid("33333333-3333-3333-3333-333333333333"),
                            Email = "user3@example.com"
                        });
                });

            modelBuilder.Entity("Core.Models.Vote", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool>("IsPositive")
                        .HasColumnType("tinyint(1)");

                    b.Property<Guid>("PictureId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("PictureId");

                    b.HasIndex("UserId");

                    b.ToTable("Votes");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "ad376a8f-9eab-4bb9-9fca-30b01540f445",
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "69c82957-43ea-4f23-9efc-0eac834e3486",
                            Email = "illiateliuk@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "ILLIATELIUK@GMAIL.COM",
                            NormalizedUserName = "illiateliuk@gmail.com",
                            PasswordHash = "AQAAAAIAAYagAAAAEGR2sBH6VLnYUbFK6Sdqzpgt1SllzXdh+JGXyiaOwugXOoGKqDn8GJJz1ZGA2yFEtw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UserName = "illiateliuk@gmail.com"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                            RoleId = "ad376a8f-9eab-4bb9-9fca-30b01540f445"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Core.Models.Album", b =>
                {
                    b.HasOne("Core.Models.User", "Author")
                        .WithMany("Albums")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("Core.Models.Picture", b =>
                {
                    b.HasOne("Core.Models.Album", "Album")
                        .WithMany("Pictures")
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Album");
                });

            modelBuilder.Entity("Core.Models.Vote", b =>
                {
                    b.HasOne("Core.Models.Picture", "Picture")
                        .WithMany("Votes")
                        .HasForeignKey("PictureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Models.User", "User")
                        .WithMany("Votes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Picture");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Core.Models.Album", b =>
                {
                    b.Navigation("Pictures");
                });

            modelBuilder.Entity("Core.Models.Picture", b =>
                {
                    b.Navigation("Votes");
                });

            modelBuilder.Entity("Core.Models.User", b =>
                {
                    b.Navigation("Albums");

                    b.Navigation("Votes");
                });
#pragma warning restore 612, 618
        }
    }
}
