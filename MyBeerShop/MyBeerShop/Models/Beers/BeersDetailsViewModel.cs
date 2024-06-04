using System.ComponentModel.DataAnnotations;

namespace MyBeerShop.Models.Beers
{
    public class BeersDetailsViewModel
    {
        public int Id { get; set; } 
        public string BeerName { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public string Description { get; set; } = null!;

        public decimal Price { get; set; }

        public string Producer { get; set; } = null!;

        public string CriticScore { get; set; } = null!;

        public string AlcoholBV { get; set; } = null!;

        public string TestingNotes { get; set; } = null!;

        public string Packaging { get; set; } = null!;
    }
}
