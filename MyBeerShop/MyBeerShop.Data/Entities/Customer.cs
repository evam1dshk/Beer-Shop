using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MyBeerShop.Data.Entities
{
    public class Customer : IdentityUser
    {
        public ICollection<Cart> Carts { get; set; } = new List<Cart>();
    }
}
