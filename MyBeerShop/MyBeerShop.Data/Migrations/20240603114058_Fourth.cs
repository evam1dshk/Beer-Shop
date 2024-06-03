using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBeerShop.Data.Migrations
{
    public partial class Fourth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Beers",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://winevybe.com/wp-content/uploads/Hornbeer-Hornbeer-Happy-Hoppy-Viking.png");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Beers",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcQyol6lKtIlDnBU7UYll0IzynwyWMQ5LAubMwiBALqqTtL2lmB1");
        }
    }
}
