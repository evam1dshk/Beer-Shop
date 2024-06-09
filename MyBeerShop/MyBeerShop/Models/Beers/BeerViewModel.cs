using MyBeerShop.Data.Entities;

namespace MyBeerShop.Models.Beers
{
    public class BeerViewModel
    {
        public int Id { get; set; }
        public string BeerName { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public decimal Price { get; set; }
        public string Producer { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string CriticScore { get; set; } = null!;
        public string AlcoholBV { get; set; } = null!;
        public string TestingNotes { get; set; } = null!;
        public string Packaging { get; set; } = null!;
        public int BeerTypeId { get; set; }
        public IEnumerable<BeerType> BeerTypes { get; set; } = new List<BeerType>();

    }
}
