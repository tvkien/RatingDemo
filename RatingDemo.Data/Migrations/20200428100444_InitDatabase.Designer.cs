﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RatingDemo.Data.EntityFramework;

namespace RatingDemo.Data.Migrations
{
    [DbContext(typeof(RatingDBContext))]
    [Migration("20200428100444_InitDatabase")]
    partial class InitDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("AppRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("AppUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("AppUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.ToTable("AppUserRoles");

                    b.HasData(
                        new
                        {
                            UserId = new Guid("4be5f5c0-6355-47b7-aaf2-3d43d4ddaf16"),
                            RoleId = new Guid("3c152f91-6241-4758-9fb0-31dec637a02a")
                        },
                        new
                        {
                            UserId = new Guid("4be5f5c0-6355-47b7-aaf2-3d43d4ddaf16"),
                            RoleId = new Guid("313c8543-92b3-4ef9-8e3d-525d810e9780")
                        },
                        new
                        {
                            UserId = new Guid("4be5f5c0-6355-47b7-aaf2-3d43d4ddaf16"),
                            RoleId = new Guid("9b81ea9a-0e67-48e8-be97-406b1873468d")
                        },
                        new
                        {
                            UserId = new Guid("01cf24f0-de37-4094-bf4a-8248d475775b"),
                            RoleId = new Guid("3c152f91-6241-4758-9fb0-31dec637a02a")
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("AppUserTokens");
                });

            modelBuilder.Entity("RatingDemo.Data.Entities.AppRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AppRoles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("3c152f91-6241-4758-9fb0-31dec637a02a"),
                            ConcurrencyStamp = "0eb1b097-ddfe-4a78-9878-906db5480a6e",
                            Description = "Vệ sinh văn phòng",
                            Name = "Clean",
                            NormalizedName = "Clean"
                        },
                        new
                        {
                            Id = new Guid("313c8543-92b3-4ef9-8e3d-525d810e9780"),
                            ConcurrencyStamp = "82c3c148-5afb-423c-b0cc-70537e704d41",
                            Description = "Bảo vệ văn phòng",
                            Name = "Security",
                            NormalizedName = "Security"
                        },
                        new
                        {
                            Id = new Guid("9b81ea9a-0e67-48e8-be97-406b1873468d"),
                            ConcurrencyStamp = "eacdaee0-b2db-44dd-bdd2-6c907e94a5eb",
                            Description = "Chăm sóc học viên",
                            Name = "Care of student",
                            NormalizedName = "Care of student"
                        });
                });

            modelBuilder.Entity("RatingDemo.Data.Entities.AppUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

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
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AppUsers");

                    b.HasData(
                        new
                        {
                            Id = new Guid("4be5f5c0-6355-47b7-aaf2-3d43d4ddaf16"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "3b5daff5-e410-46cc-8767-298f80e0bbe0",
                            Email = "tvkien1992@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "tvkien1992@gmail.com",
                            NormalizedUserName = "admin",
                            PasswordHash = "AQAAAAEAACcQAAAAELk9Ie/JQKxsdlPbcGGusIMkSZQPsYW6YdolvD3kpbdsbNNYQbFXDe79Arpm9zM/mA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UserName = "admin"
                        },
                        new
                        {
                            Id = new Guid("01cf24f0-de37-4094-bf4a-8248d475775b"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "123d7696-e6ab-4e38-b497-8ebfca163c78",
                            Email = "tvkien1992@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "tvkien1992@gmail.com",
                            NormalizedUserName = "guest",
                            PasswordHash = "AQAAAAEAACcQAAAAEHv6V+01fpwSjhKU8ZTogHykQtZ3a9vbEuG3jVthQZWZKI29reIXi+5MsZMSKKhdMw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UserName = "guest"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
