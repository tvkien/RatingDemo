using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RatingDemo.Data.Configurations;
using RatingDemo.Data.Entities;
using RatingDemo.Data.Extensions;
using System;

namespace RatingDemo.Data.EntityFramework
{
    public class RatingDBContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public DbSet<EventAuditDetail> EventAuditDetails { get; set; }
        public DbSet<RatingInformation> RatingInformations { get; set; }

        public RatingDBContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EventAuditDetailConfiguration());
            modelBuilder.ApplyConfiguration(new RatingInformationConfiguration());
            
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            modelBuilder.ApplyConfiguration(new AppRoleConfiguration());

            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClaims");
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRoles").HasKey(x => new { x.UserId, x.RoleId });
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUserLogins").HasKey(x => x.UserId);

            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppRoleClaims");
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("AppUserTokens").HasKey(x => x.UserId);

            modelBuilder.Seed();
        }
    }
}