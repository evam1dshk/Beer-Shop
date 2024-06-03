using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBeerShop.Data.Migrations
{
    public partial class Third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BeerTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Beers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AlcoholBV", "BeerName", "Description", "ImageUrl", "Price", "Producer", "TestingNotes" },
                values: new object[] { "9.30%", "Hornbeer", "Dark beer", "https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcQyol6lKtIlDnBU7UYll0IzynwyWMQ5LAubMwiBALqqTtL2lmB1", 8.0m, "HornBeer", "\r\nBrown, full-bodied, cloudy, very strongly hopped, caramel malt notes, grapefruity, dried fruits, syrupy, light cocoa notes, spicy" });

            migrationBuilder.UpdateData(
                table: "Beers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AlcoholBV", "BeerName", "CriticScore", "ImageUrl", "Price", "Producer", "TestingNotes" },
                values: new object[] { "6.60%", "Pohjoisen panimo Maistila", "68/100", "https://winevybe.com/wp-content/uploads/Pohjoisen-panimo-Maistila-Maistila-Aprikoi-Saison.png", 4.0m, "Pohjoisen panimo Maistila", "Orange-yellow, medium-bodied, cloudy, with a rich head, mildly hopped, apricot notes, fruity" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BeerTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "" });

            migrationBuilder.UpdateData(
                table: "Beers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AlcoholBV", "BeerName", "Description", "ImageUrl", "Price", "Producer", "TestingNotes" },
                values: new object[] { "6.20%", "Omnipollo", "Citrus beer", "image_url", 5.0m, "Producer A", "Lemon-yellow, full-bodied, cloudy, very strongly hopped, citrus notes, pomelo notes, currant leaf notes, light grassy notes, fresh, refreshing" });

            migrationBuilder.UpdateData(
                table: "Beers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AlcoholBV", "BeerName", "CriticScore", "ImageUrl", "Price", "Producer", "TestingNotes" },
                values: new object[] { "6.0%", "Ale Beer", "66/100", "image_url", 6.0m, "Producer B", "Golden-yellow, full-bodied, strongly hopped, ripe fruit notes, malt biscuit notes, light grapefruit notes, herbal notes, balanced" });
        }
    }
}
