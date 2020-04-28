using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RatingDemo.Data.Entities;
using System;

namespace RatingDemo.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var roleCleanId = Guid.NewGuid();
            modelBuilder.Entity<AppRole>().HasData(new AppRole
            {
                Id = roleCleanId,
                Name = "Clean",
                NormalizedName = "Clean",
                Description = "Vệ sinh văn phòng"
            });

            var roleSecurityId = Guid.NewGuid();
            modelBuilder.Entity<AppRole>().HasData(new AppRole
            {
                Id = roleSecurityId,
                Name = "Security",
                NormalizedName = "Security",
                Description = "Bảo vệ văn phòng"
            });

            var roleCareId = Guid.NewGuid();
            modelBuilder.Entity<AppRole>().HasData(new AppRole
            {
                Id = roleCareId,
                Name = "Care of student",
                NormalizedName = "Care of student",
                Description = "Chăm sóc học viên"
            });

            var adminId = Guid.NewGuid();
            modelBuilder.Entity<AppUser>().HasData(new AppUser
            {
                Id = adminId,
                UserName = "admin",
                NormalizedUserName = "admin",
                Email = "tvkien1992@gmail.com",
                NormalizedEmail = "tvkien1992@gmail.com",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<AppUser>().HashPassword(null, "admin"),
                SecurityStamp = string.Empty,
            });

            var guestId = Guid.NewGuid();
            modelBuilder.Entity<AppUser>().HasData(new AppUser
            {
                Id = guestId,
                UserName = "guest",
                NormalizedUserName = "guest",
                Email = "tvkien1992@gmail.com",
                NormalizedEmail = "tvkien1992@gmail.com",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<AppUser>().HashPassword(null, "guest"),
                SecurityStamp = string.Empty,
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(
                new IdentityUserRole<Guid>
                {
                    RoleId = roleCleanId,
                    UserId = adminId
                },
                 new IdentityUserRole<Guid>
                 {
                     RoleId = roleSecurityId,
                     UserId = adminId
                 },
                 new IdentityUserRole<Guid>
                 {
                     RoleId = roleCareId,
                     UserId = adminId
                 },
                 new IdentityUserRole<Guid>
                 {
                     RoleId = roleCleanId,
                     UserId = guestId
                 });
        }
    }
}