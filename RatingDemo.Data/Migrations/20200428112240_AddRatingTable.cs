using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RatingDemo.Data.Migrations
{
    public partial class AddRatingTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("313c8543-92b3-4ef9-8e3d-525d810e9780"));

            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("3c152f91-6241-4758-9fb0-31dec637a02a"));

            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("9b81ea9a-0e67-48e8-be97-406b1873468d"));

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("01cf24f0-de37-4094-bf4a-8248d475775b"), new Guid("3c152f91-6241-4758-9fb0-31dec637a02a") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("4be5f5c0-6355-47b7-aaf2-3d43d4ddaf16"), new Guid("313c8543-92b3-4ef9-8e3d-525d810e9780") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("4be5f5c0-6355-47b7-aaf2-3d43d4ddaf16"), new Guid("3c152f91-6241-4758-9fb0-31dec637a02a") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("4be5f5c0-6355-47b7-aaf2-3d43d4ddaf16"), new Guid("9b81ea9a-0e67-48e8-be97-406b1873468d") });

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("01cf24f0-de37-4094-bf4a-8248d475775b"));

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("4be5f5c0-6355-47b7-aaf2-3d43d4ddaf16"));

            migrationBuilder.CreateTable(
                name: "EventAuditDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Passcode = table.Column<string>(nullable: false),
                    EventType = table.Column<int>(nullable: false, defaultValue: 0),
                    ServiceType = table.Column<int>(nullable: false, defaultValue: 0),
                    EventMessage = table.Column<string>(nullable: true),
                    OccurredAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventAuditDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RatingInformations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionId = table.Column<int>(nullable: false, defaultValue: 0),
                    ServiceType = table.Column<int>(nullable: false, defaultValue: 0),
                    Scored = table.Column<int>(nullable: false, defaultValue: 0),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RatingInformations", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("4494005f-d9df-47e4-aa49-4cba65b80acc"), "ad392410-9275-424f-a5fb-2c1e918849a7", "Vệ sinh văn phòng", "Clean", "Clean" },
                    { new Guid("4e0e48c7-28cf-4f6e-8edd-c6b07b29d528"), "55fade7e-1876-4a46-921f-fc50cf992b5b", "Bảo vệ văn phòng", "Security", "Security" },
                    { new Guid("3d28407d-ad54-4366-b16e-636646fd1bd8"), "2199a8fd-6650-41e6-a639-7b360ef4ad99", "Chăm sóc học viên", "Care of student", "Care of student" }
                });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("5f022730-0e8e-41db-a8f9-471ada506f66"), new Guid("4494005f-d9df-47e4-aa49-4cba65b80acc") },
                    { new Guid("5f022730-0e8e-41db-a8f9-471ada506f66"), new Guid("4e0e48c7-28cf-4f6e-8edd-c6b07b29d528") },
                    { new Guid("5f022730-0e8e-41db-a8f9-471ada506f66"), new Guid("3d28407d-ad54-4366-b16e-636646fd1bd8") },
                    { new Guid("0fb1aaca-f876-49d7-8155-9a7ee767b493"), new Guid("4494005f-d9df-47e4-aa49-4cba65b80acc") }
                });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("5f022730-0e8e-41db-a8f9-471ada506f66"), 0, "3117d1ca-2573-4878-ad70-2a0c91f34dd5", "tvkien1992@gmail.com", true, false, null, "tvkien1992@gmail.com", "admin", "AQAAAAEAACcQAAAAEAHYlxY/SaQ6rsfd1BcxgHRKeoF5mHJLeoqDFiXM5RhrWuEZxBt65haTXmG5dj6Neg==", null, false, "", false, "admin" },
                    { new Guid("0fb1aaca-f876-49d7-8155-9a7ee767b493"), 0, "5bad5dd7-b73a-492e-9917-4a660b20e717", "tvkien1992@gmail.com", true, false, null, "tvkien1992@gmail.com", "guest", "AQAAAAEAACcQAAAAEJghMXhchr5oXUyjTizcPy4MtlrRqayG5vIdFB6uO2WgStPg0A2nab11StzACy/k3g==", null, false, "", false, "guest" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventAuditDetails");

            migrationBuilder.DropTable(
                name: "RatingInformations");

            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("3d28407d-ad54-4366-b16e-636646fd1bd8"));

            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("4494005f-d9df-47e4-aa49-4cba65b80acc"));

            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("4e0e48c7-28cf-4f6e-8edd-c6b07b29d528"));

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("0fb1aaca-f876-49d7-8155-9a7ee767b493"), new Guid("4494005f-d9df-47e4-aa49-4cba65b80acc") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("5f022730-0e8e-41db-a8f9-471ada506f66"), new Guid("3d28407d-ad54-4366-b16e-636646fd1bd8") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("5f022730-0e8e-41db-a8f9-471ada506f66"), new Guid("4494005f-d9df-47e4-aa49-4cba65b80acc") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("5f022730-0e8e-41db-a8f9-471ada506f66"), new Guid("4e0e48c7-28cf-4f6e-8edd-c6b07b29d528") });

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("0fb1aaca-f876-49d7-8155-9a7ee767b493"));

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("5f022730-0e8e-41db-a8f9-471ada506f66"));

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
    }
}
