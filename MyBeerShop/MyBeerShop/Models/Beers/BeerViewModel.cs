namespace MyBeerShop.Models.Beers
{
    public class BeerViewModel
    {
        public int Id { get; set; }
        public string BeerName { get; set; } = null!;
        public string Producer { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;
        public decimal Price { get; set; }

    }
}
