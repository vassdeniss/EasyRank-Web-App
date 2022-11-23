﻿// <auto-generated />
using System;
using EasyRank.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EasyRank.Infrastructure.Data.Migrations
{
    [DbContext(typeof(EasyRankDbContext))]
    [Migration("20221115164040_EditedCommentSeed")]
    partial class EditedCommentSeed
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EasyRank.Infrastructure.Models.Accounts.EasyRankUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)")
                        .HasComment("Gets or sets the first name for a user.");

                    b.Property<string>("LastName")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasComment("Gets or sets the last name for a user.");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<byte[]>("ProfilePicture")
                        .HasColumnType("varbinary(max)")
                        .HasComment("Gets or sets the profile picture of the user.");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasComment("The 'EasyRankUser' model for the database.");

                    b.HasData(
                        new
                        {
                            Id = new Guid("51424a7b-466c-4f48-ab75-0488714314da"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "492cb73a-d07d-4dff-91f2-d0c31ee26145",
                            Email = "guest@mail.com",
                            EmailConfirmed = true,
                            FirstName = "Guest",
                            LastName = "User",
                            LockoutEnabled = false,
                            NormalizedEmail = "GUEST@MAIL.COM",
                            NormalizedUserName = "GUEST",
                            PasswordHash = "AQAAAAEAACcQAAAAEAUftOZDvmVJ6EjQ7mRDe4CqfDSEXn2r7CkoDsiJf6P2O8q6jbntvAbgdPxVUCk3YA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "a55f52d9-5f67-4060-9933-15e2e6f5933b",
                            TwoFactorEnabled = false,
                            UserName = "guest"
                        },
                        new
                        {
                            Id = new Guid("62f0c7a6-b499-474b-938d-accace47926c"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "07f49c44-0931-4b22-8973-f7b24d3dd6af",
                            Email = "guestTwo@mail.com",
                            EmailConfirmed = true,
                            FirstName = "GuestTwo",
                            LastName = "UserTwo",
                            LockoutEnabled = false,
                            NormalizedEmail = "GUESTTWO@MAIL.COM",
                            NormalizedUserName = "GUESTTWO",
                            PasswordHash = "AQAAAAEAACcQAAAAEDQ7oXlHQu3ekaXDa3TU1+U9EUk+AvKYaactAhaRTVmq7QVIBVWL266OitazBkZiUg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "ebb10a03-7c37-4c8d-b6c3-e92ff5cb1a9c",
                            TwoFactorEnabled = false,
                            UserName = "guestTwo"
                        });
                });

            modelBuilder.Entity("EasyRank.Infrastructure.Models.Comment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Gets or sets the unique GUID identifier for a comment.");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)")
                        .HasComment("Gets or sets the content of the comment.");

                    b.Property<Guid>("CreatedByUserId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Gets or sets the guid of the user who created the comment.");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2")
                        .HasComment("Gets or sets the date & time a comment has been created on.");

                    b.Property<Guid>("RankPageId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Gets or sets the guid of the ranking page where the comment was sent.");

                    b.HasKey("Id");

                    b.HasIndex("CreatedByUserId");

                    b.HasIndex("RankPageId");

                    b.ToTable("Comments");

                    b.HasComment("The 'Comment' model for the database.");

                    b.HasData(
                        new
                        {
                            Id = new Guid("0a69c6e2-133a-4a14-8698-ddc063c7b1bb"),
                            Content = "Lorem Ipsum is simply dummy text of the printing and typesetting industry.Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                            CreatedByUserId = new Guid("51424a7b-466c-4f48-ab75-0488714314da"),
                            CreatedOn = new DateTime(2022, 11, 12, 18, 40, 40, 150, DateTimeKind.Local).AddTicks(413),
                            RankPageId = new Guid("3e94c098-eae4-44a7-be18-7b4efb1f759b")
                        },
                        new
                        {
                            Id = new Guid("21c0c8e8-efa2-4215-b67a-0d234baa8760"),
                            Content = "Lorem Ipsum is simply dummy text of the printing and typesetting industry.Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                            CreatedByUserId = new Guid("51424a7b-466c-4f48-ab75-0488714314da"),
                            CreatedOn = new DateTime(2022, 11, 17, 18, 40, 40, 150, DateTimeKind.Local).AddTicks(429),
                            RankPageId = new Guid("3e94c098-eae4-44a7-be18-7b4efb1f759b")
                        },
                        new
                        {
                            Id = new Guid("b1d63def-c2b2-488c-a4ee-cadc583bf6f6"),
                            Content = "Lorem Ipsum is simply dummy text of the printing and typesetting industry.Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                            CreatedByUserId = new Guid("62f0c7a6-b499-474b-938d-accace47926c"),
                            CreatedOn = new DateTime(2022, 11, 5, 18, 40, 40, 150, DateTimeKind.Local).AddTicks(437),
                            RankPageId = new Guid("3e94c098-eae4-44a7-be18-7b4efb1f759b")
                        });
                });

            modelBuilder.Entity("EasyRank.Infrastructure.Models.RankEntry", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Gets or sets the unique GUID identifier for a rank entry.");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)")
                        .HasComment("Gets or sets the description for a rank entry.");

                    b.Property<string>("Image")
                        .HasMaxLength(2048)
                        .IsUnicode(false)
                        .HasColumnType("varchar(2048)")
                        .HasComment("Gets or sets the image link for a rank entry.");

                    b.Property<string>("ImageAlt")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Gets or sets the alternative text if the image is broken.");

                    b.Property<int>("Placement")
                        .HasColumnType("int")
                        .HasComment("Gets or sets the placement in the ranking of the ranking entry.");

                    b.Property<Guid>("RankPageId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Gets or sets the guid of the rank page which the entry belongs to.");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasComment("Gets or sets the title for a rank entry.");

                    b.HasKey("Id");

                    b.HasIndex("RankPageId");

                    b.ToTable("RankEntries");

                    b.HasComment("The 'RankEntry' model for the database.");

                    b.HasData(
                        new
                        {
                            Id = new Guid("12895621-717a-4de7-82db-cc438ec5d97d"),
                            Description = "Good stuff",
                            ImageAlt = "Picture of star wars",
                            Placement = 10,
                            RankPageId = new Guid("3e94c098-eae4-44a7-be18-7b4efb1f759b"),
                            Title = "Star Wars"
                        },
                        new
                        {
                            Id = new Guid("ccd6173f-d4c9-4b4e-a075-9ea741a3cb1c"),
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque interdum iaculis arcu et pellentesque. Aliquam at venenatis libero. Suspendisse non suscipit mi, in ullamcorper magna. Donec imperdiet urna et aliquet placerat. Donec faucibus dolor id velit sagittis congue. In hac habitasse platea dictumst. Suspendisse vitae sodales diam. Mauris in erat magna. Cras molestie lectus felis, eget convallis lectus mollis ac. Proin posuere nec magna at accumsan. Etiam quis magna pulvinar, eleifend purus a, fringilla eros.",
                            Image = "https://images.immediate.co.uk/production/volatile/sites/3/2017/12/yoda-the-empire-strikes-back-28a7558.jpg?quality=90&webp=true&resize=800,534",
                            ImageAlt = "Picture of star wars2",
                            Placement = 9,
                            RankPageId = new Guid("3e94c098-eae4-44a7-be18-7b4efb1f759b"),
                            Title = "Star Wars2"
                        });
                });

            modelBuilder.Entity("EasyRank.Infrastructure.Models.RankPage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Gets or sets the unique GUID identifier for a ranking page.");

                    b.Property<Guid>("CreatedByUserId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Gets or sets the guid of the user who created the ranking page.");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2")
                        .HasComment("Gets or sets the date & time a ranking page has been created on.");

                    b.Property<string>("Image")
                        .HasMaxLength(2048)
                        .IsUnicode(false)
                        .HasColumnType("varchar(2048)")
                        .HasComment("Gets or sets the image link for a rank entry.");

                    b.Property<string>("ImageAlt")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Gets or sets the alternative text if the image is broken.");

                    b.Property<string>("RankingTitle")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasComment("Gets or sets the name of the ranking page.");

                    b.HasKey("Id");

                    b.HasIndex("CreatedByUserId");

                    b.ToTable("RankPages");

                    b.HasComment("The 'RankPage' model for the database.");

                    b.HasData(
                        new
                        {
                            Id = new Guid("3e94c098-eae4-44a7-be18-7b4efb1f759b"),
                            CreatedByUserId = new Guid("51424a7b-466c-4f48-ab75-0488714314da"),
                            CreatedOn = new DateTime(2022, 11, 15, 0, 0, 0, 0, DateTimeKind.Local),
                            Image = "https://images.immediate.co.uk/production/volatile/sites/3/2017/12/yoda-the-empire-strikes-back-28a7558.jpg?quality=90&webp=true&resize=800,534",
                            ImageAlt = "Yoda",
                            RankingTitle = "Top 10 Best Movies of 2022"
                        },
                        new
                        {
                            Id = new Guid("37eb69e3-9034-4361-94a2-47f68b9741de"),
                            CreatedByUserId = new Guid("51424a7b-466c-4f48-ab75-0488714314da"),
                            CreatedOn = new DateTime(2022, 11, 15, 0, 0, 0, 0, DateTimeKind.Local),
                            Image = "https://images.immediate.co.uk/production/volatile/sites/3/2017/12/yoda-the-empire-strikes-back-28a7558.jpg?quality=90&webp=true&resize=800,534",
                            ImageAlt = "Yoda",
                            RankingTitle = "Top 5 Favorite Characters"
                        },
                        new
                        {
                            Id = new Guid("1dbb1259-3078-4896-878e-1038b2d285a8"),
                            CreatedByUserId = new Guid("51424a7b-466c-4f48-ab75-0488714314da"),
                            CreatedOn = new DateTime(2022, 11, 15, 0, 0, 0, 0, DateTimeKind.Local),
                            Image = "https://images.immediate.co.uk/production/volatile/sites/3/2017/12/yoda-the-empire-strikes-back-28a7558.jpg?quality=90&webp=true&resize=800,534",
                            ImageAlt = "Yoda",
                            RankingTitle = "Top 5 Favorite Characters"
                        },
                        new
                        {
                            Id = new Guid("eb39cc37-e8e7-4a9c-8f0f-6410f54db3c1"),
                            CreatedByUserId = new Guid("51424a7b-466c-4f48-ab75-0488714314da"),
                            CreatedOn = new DateTime(2022, 11, 15, 0, 0, 0, 0, DateTimeKind.Local),
                            Image = "https://images.immediate.co.uk/production/volatile/sites/3/2017/12/yoda-the-empire-strikes-back-28a7558.jpg?quality=90&webp=true&resize=800,534",
                            ImageAlt = "Yoda",
                            RankingTitle = "Top 5 Favorite Characters"
                        },
                        new
                        {
                            Id = new Guid("bdfbce24-0b50-4bdb-8dbf-9a99357b261a"),
                            CreatedByUserId = new Guid("51424a7b-466c-4f48-ab75-0488714314da"),
                            CreatedOn = new DateTime(2022, 11, 15, 0, 0, 0, 0, DateTimeKind.Local),
                            Image = "https://images.immediate.co.uk/production/volatile/sites/3/2017/12/yoda-the-empire-strikes-back-28a7558.jpg?quality=90&webp=true&resize=800,534",
                            ImageAlt = "Yoda",
                            RankingTitle = "Top 5 Favorite Characters"
                        },
                        new
                        {
                            Id = new Guid("17d725ec-4975-44c3-8c21-73cfacbf51e5"),
                            CreatedByUserId = new Guid("62f0c7a6-b499-474b-938d-accace47926c"),
                            CreatedOn = new DateTime(2022, 11, 15, 0, 0, 0, 0, DateTimeKind.Local),
                            Image = "https://images.immediate.co.uk/production/volatile/sites/3/2017/12/yoda-the-empire-strikes-back-28a7558.jpg?quality=90&webp=true&resize=800,534",
                            ImageAlt = "Yoda",
                            RankingTitle = "Top 5 Favorite Characters"
                        },
                        new
                        {
                            Id = new Guid("0a5da684-f8aa-4d41-90a7-eae8ec32b5c0"),
                            CreatedByUserId = new Guid("51424a7b-466c-4f48-ab75-0488714314da"),
                            CreatedOn = new DateTime(2022, 11, 15, 0, 0, 0, 0, DateTimeKind.Local),
                            Image = "https://images.immediate.co.uk/production/volatile/sites/3/2017/12/yoda-the-empire-strikes-back-28a7558.jpg?quality=90&webp=true&resize=800,534",
                            ImageAlt = "Yoda",
                            RankingTitle = "Top 5 Favorite Characters"
                        });
                });

            modelBuilder.Entity("EasyRankUserRankPage", b =>
                {
                    b.Property<Guid>("LikedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("LikedRankingsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LikedById", "LikedRankingsId");

                    b.HasIndex("LikedRankingsId");

                    b.ToTable("EasyRankUserRankPage");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("EasyRank.Infrastructure.Models.Comment", b =>
                {
                    b.HasOne("EasyRank.Infrastructure.Models.Accounts.EasyRankUser", "CreatedByUser")
                        .WithMany("UserComments")
                        .HasForeignKey("CreatedByUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("EasyRank.Infrastructure.Models.RankPage", "RankPage")
                        .WithMany("Comments")
                        .HasForeignKey("RankPageId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CreatedByUser");

                    b.Navigation("RankPage");
                });

            modelBuilder.Entity("EasyRank.Infrastructure.Models.RankEntry", b =>
                {
                    b.HasOne("EasyRank.Infrastructure.Models.RankPage", "RankPage")
                        .WithMany("Entries")
                        .HasForeignKey("RankPageId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("RankPage");
                });

            modelBuilder.Entity("EasyRank.Infrastructure.Models.RankPage", b =>
                {
                    b.HasOne("EasyRank.Infrastructure.Models.Accounts.EasyRankUser", "CreatedByUser")
                        .WithMany("UserRankings")
                        .HasForeignKey("CreatedByUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CreatedByUser");
                });

            modelBuilder.Entity("EasyRankUserRankPage", b =>
                {
                    b.HasOne("EasyRank.Infrastructure.Models.Accounts.EasyRankUser", null)
                        .WithMany()
                        .HasForeignKey("LikedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EasyRank.Infrastructure.Models.RankPage", null)
                        .WithMany()
                        .HasForeignKey("LikedRankingsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("EasyRank.Infrastructure.Models.Accounts.EasyRankUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("EasyRank.Infrastructure.Models.Accounts.EasyRankUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EasyRank.Infrastructure.Models.Accounts.EasyRankUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("EasyRank.Infrastructure.Models.Accounts.EasyRankUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EasyRank.Infrastructure.Models.Accounts.EasyRankUser", b =>
                {
                    b.Navigation("UserComments");

                    b.Navigation("UserRankings");
                });

            modelBuilder.Entity("EasyRank.Infrastructure.Models.RankPage", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Entries");
                });
#pragma warning restore 612, 618
        }
    }
}