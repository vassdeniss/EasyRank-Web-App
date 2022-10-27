﻿// <auto-generated />
using System;
using EasyRank.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EasyRank.Infrastructure.Data.Migrations
{
    [DbContext(typeof(EasyRankDbContext))]
    partial class EasyRankDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                            Id = new Guid("9ff24061-b984-4be1-a40a-d9235017619c"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "5cfc5275-059d-4c0f-95e1-d13e91636355",
                            Email = "guest@mail.com",
                            EmailConfirmed = true,
                            FirstName = "Guest",
                            LastName = "User",
                            LockoutEnabled = false,
                            NormalizedEmail = "GUEST@MAIL.COM",
                            NormalizedUserName = "GUEST",
                            PasswordHash = "AQAAAAEAACcQAAAAELt/8OSuBVNMvyzj/5Y/vhtmPPIG/6iHs0uPUMzsojv67pm3SAdL6AGafME0mXw46w==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "f5a49fe9-631a-4f8a-bc4b-74855287d8e9",
                            TwoFactorEnabled = false,
                            UserName = "guest"
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
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
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
                            Id = new Guid("9c774152-d29d-41bf-bf68-dd970de2fa3d"),
                            Description = "Good stuff",
                            Placement = 10,
                            RankPageId = new Guid("add9e3e3-d51c-431c-ab91-2c6ce70db5da"),
                            Title = "Star Wars"
                        },
                        new
                        {
                            Id = new Guid("9f78c718-c581-40cf-a1ae-f11ffe06bf31"),
                            Description = "Good stuff again",
                            Placement = 9,
                            RankPageId = new Guid("add9e3e3-d51c-431c-ab91-2c6ce70db5da"),
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
                            Id = new Guid("add9e3e3-d51c-431c-ab91-2c6ce70db5da"),
                            CreatedByUserId = new Guid("9ff24061-b984-4be1-a40a-d9235017619c"),
                            CreatedOn = new DateTime(2022, 10, 27, 0, 0, 0, 0, DateTimeKind.Local),
                            RankingTitle = "Top 10 Best Movies of 2022"
                        },
                        new
                        {
                            Id = new Guid("c40570a9-7133-411a-aeaa-b8b288de2986"),
                            CreatedByUserId = new Guid("9ff24061-b984-4be1-a40a-d9235017619c"),
                            CreatedOn = new DateTime(2022, 10, 27, 0, 0, 0, 0, DateTimeKind.Local),
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
