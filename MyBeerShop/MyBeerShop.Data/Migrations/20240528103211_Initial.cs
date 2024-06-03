using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBeerShop.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BeerTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeerTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Beers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BeerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Producer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CriticScore = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlcoholBV = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TestingNotes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Packaging = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BeerTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Beers_BeerTypes_BeerTypeId",
                        column: x => x.BeerTypeId,
                        principalTable: "BeerTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BeerId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    FinalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_AspNetUsers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Carts_Beers_BeerId",
                        column: x => x.BeerId,
                        principalTable: "Beers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "5F23C81D-9B0C-48BD-AC91-DDD4FB6D2DDA", 0, "0254e2c8-dadf-45a3-a7f5-acdd658c8474", "admin@gmail.com", false, false, null, "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAEKauE5U19hXfRvC287+CIV0Ll2EEGclwDMu9Rc1Y/57xD10yBYBtFgTl9gf6gr66pw==", null, false, "3eab93d0-9e92-4316-a45f-dda7620aeeab", false, "admin" },
                    { "BC4219EA-6BE7-47E2-8D2C-A0740BED3151", 0, "e940f7f6-e429-4362-aa68-76854ecd3e38", "guest@gmail.com", false, false, null, "GUEST@GMAIL.COM", "GUEST", "AQAAAAEAACcQAAAAEOc4kLVR/rO3gf80LkHgp+RuML5v7HRnlyq7YSqvrIWLZEMhW/+Idul/EaQqg1L4ug==", null, false, "ea9573af-b8bc-407d-9436-f8b30c5fff6a", false, "guest" }
                });

            migrationBuilder.InsertData(
                table: "BeerTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Omnipollo" },
                    { 2, "Ale" },
                    { 3, "" }
                });

            migrationBuilder.InsertData(
                table: "Beers",
                columns: new[] { "Id", "AlcoholBV", "BeerName", "BeerTypeId", "CriticScore", "Description", "ImageUrl", "Packaging", "Price", "Producer", "TestingNotes" },
                values: new object[] { 1, "6.20%", "Omnipollo", 1, "71/100", "Citrus beer", "image_url", "Bottle", 5.0m, "Producer A", "Lemon-yellow, full-bodied, cloudy, very strongly hopped, citrus notes, pomelo notes, currant leaf notes, light grassy notes, fresh, refreshing" });

            migrationBuilder.InsertData(
                table: "Beers",
                columns: new[] { "Id", "AlcoholBV", "BeerName", "BeerTypeId", "CriticScore", "Description", "ImageUrl", "Packaging", "Price", "Producer", "TestingNotes" },
                values: new object[] { 2, "6.0%", "Ale Beer", 2, "66/100", "A strong beer.", "image_url", "Bottle", 6.0m, "Producer B", "Golden-yellow, full-bodied, strongly hopped, ripe fruit notes, malt biscuit notes, light grapefruit notes, herbal notes, balanced" });

            migrationBuilder.CreateIndex(
                name: "IX_Beers_BeerTypeId",
                table: "Beers",
                column: "BeerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_BeerId",
                table: "Carts",
                column: "BeerId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_CustomerId",
                table: "Carts",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Beers");

            migrationBuilder.DropTable(
                name: "BeerTypes");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5F23C81D-9B0C-48BD-AC91-DDD4FB6D2DDA");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "BC4219EA-6BE7-47E2-8D2C-A0740BED3151");
        }
    }
}
