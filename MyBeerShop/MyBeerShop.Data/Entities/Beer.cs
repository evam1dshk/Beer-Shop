using System.ComponentModel.DataAnnotations;

namespace MyBeerShop.Data.Entities
{
    public class Beer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string BeerName { get; set; } = null!;


        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        public string Description { get; set; } = null!;

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string Producer { get; set; } = null!;

        [Required]
        public string CriticScore { get; set; } = null!;

        [Required]
        public string AlcoholBV { get; set; } = null!;

        [Required]
        public string TestingNotes { get; set; } = null!;

        [Required]
        public string Packaging { get; set; } = null!;

        [Required]
        public int BeerTypeId { get; set; }

        public BeerType BeerType { get; set; } = null!;

        public ICollection<Cart> Carts { get; set; } = new List<Cart>();
    }
  }
