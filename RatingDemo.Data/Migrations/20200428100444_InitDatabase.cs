using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RatingDemo.Data.Migrations
{
    public partial class InitDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRoleClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    NormalizedName = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Description = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUserLogins",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: true),
                    ProviderKey = table.Column<string>(nullable: true),
                    ProviderDisplayName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserLogins", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "AppUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserRoles", x => new { x.UserId, x.RoleId });
                });

            migrationBuilder.CreateTable(
                name: "AppUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserTokens", x => x.UserId);
                });

            migrationBuilder.InsertData(
                table: "AppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("3c152f91-6241-4758-9fb0-31dec637a02a"), "0eb1b097-ddfe-4a78-9878-906db5480a6e", "Vệ sinh văn phòng", "Clean", "Clean" },
                    { new Guid("313c8543-92b3-4ef9-8e3d-525d810e9780"), "82c3c148-5afb-423c-b0cc-70537e704d41", "Bảo vệ văn phòng", "Security", "Security" },
                    { new Guid("9b81ea9a-0e67-48e8-be97-406b1873468d"), "eacdaee0-b2db-44dd-bdd2-6c907e94a5eb", "Chăm sóc học viên", "Care of student", "Care of student" }
                });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("4be5f5c0-6355-47b7-aaf2-3d43d4ddaf16"), new Guid("3c152f91-6241-4758-9fb0-31dec637a02a") },
                    { new Guid("4be5f5c0-6355-47b7-aaf2-3d43d4ddaf16"), new Guid("313c8543-92b3-4ef9-8e3d-525d810e9780") },
                    { new Guid("4be5f5c0-6355-47b7-aaf2-3d43d4ddaf16"), new Guid("9b81ea9a-0e67-48e8-be97-406b1873468d") },
                    { new Guid("01cf24f0-de37-4094-bf4a-8248d475775b"), new Guid("3c152f91-6241-4758-9fb0-31dec637a02a") }
                });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("4be5f5c0-6355-47b7-aaf2-3d43d4ddaf16"), 0, "3b5daff5-e410-46cc-8767-298f80e0bbe0", "tvkien1992@gmail.com", true, false, null, "tvkien1992@gmail.com", "admin", "AQAAAAEAACcQAAAAELk9Ie/JQKxsdlPbcGGusIMkSZQPsYW6YdolvD3kpbdsbNNYQbFXDe79Arpm9zM/mA==", null, false, "", false, "admin" },
                    { new Guid("01cf24f0-de37-4094-bf4a-8248d475775b"), 0, "123d7696-e6ab-4e38-b497-8ebfca163c78", "tvkien1992@gmail.com", true, false, null, "tvkien1992@gmail.com", "guest", "AQAAAAEAACcQAAAAEHv6V+01fpwSjhKU8ZTogHykQtZ3a9vbEuG3jVthQZWZKI29reIXi+5MsZMSKKhdMw==", null, false, "", false, "guest" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppRoleClaims");

            migrationBuilder.DropTable(
                name: "AppRoles");

            migrationBuilder.DropTable(
                name: "AppUserClaims");

            migrationBuilder.DropTable(
                name: "AppUserLogins");

            migrationBuilder.DropTable(
                name: "AppUserRoles");

            migrationBuilder.DropTable(
                name: "AppUsers");

            migrationBuilder.DropTable(
                name: "AppUserTokens");
        }
    }
}
