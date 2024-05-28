using System.ComponentModel.DataAnnotations;

namespace MyBeerShop.Data.Entities
{
    public class BeerType
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        public ICollection<Beer> Beers { get; set; } = null!;
    }
}
