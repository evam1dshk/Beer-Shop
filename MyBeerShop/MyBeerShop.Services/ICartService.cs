using MyBeerShop.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBeerShop.Services
{
    public interface ICartService
    {
        Task<Cart> GetCartAsync(string customerId);
        Task AddToCartAsync(string customerId, int beerId, int quantity);
        Task RemoveFromCartAsync(string customerId, int cartItemId);
        Task ClearCartAsync(string customerId);
        Task<Order> CreateOrderAsync(string customerId);
    }
}
