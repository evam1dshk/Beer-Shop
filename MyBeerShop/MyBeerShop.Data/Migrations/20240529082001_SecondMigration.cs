using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBeerShop.Data.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5F23C81D-9B0C-48BD-AC91-DDD4FB6D2DDA");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "BC4219EA-6BE7-47E2-8D2C-A0740BED3151");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "5F23C81D-9B0C-48BD-AC91-DDD4FB6D2DDA", 0, "0254e2c8-dadf-45a3-a7f5-acdd658c8474", "admin@gmail.com", false, false, null, "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAEKauE5U19hXfRvC287+CIV0Ll2EEGclwDMu9Rc1Y/57xD10yBYBtFgTl9gf6gr66pw==", null, false, "3eab93d0-9e92-4316-a45f-dda7620aeeab", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "BC4219EA-6BE7-47E2-8D2C-A0740BED3151", 0, "e940f7f6-e429-4362-aa68-76854ecd3e38", "guest@gmail.com", false, false, null, "GUEST@GMAIL.COM", "GUEST", "AQAAAAEAACcQAAAAEOc4kLVR/rO3gf80LkHgp+RuML5v7HRnlyq7YSqvrIWLZEMhW/+Idul/EaQqg1L4ug==", null, false, "ea9573af-b8bc-407d-9436-f8b30c5fff6a", false, "guest" });
        }
    }
}
