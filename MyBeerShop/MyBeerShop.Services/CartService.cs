using Microsoft.EntityFrameworkCore;
using MyBeerShop.Data;
using MyBeerShop.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBeerShop.Services
{
    public class CartService : ICartService
    {
        private readonly MyBeerShopDbContext _context;

        public CartService(MyBeerShopDbContext context)
        {
            _context = context;
        }

        public async Task<Cart> GetCartAsync(string customerId)
        {
            return await _context.Carts
                .Include(c => c.Items)
                .ThenInclude(ci => ci.Beer)
                .FirstOrDefaultAsync(c => c.CustomerId == customerId);
        }

        public async Task AddToCartAsync(string customerId, int beerId, int quantity)
        {
            var cart = await GetCartAsync(customerId);

            if (cart == null)
            {
                cart = new Cart { CustomerId = customerId };
                _context.Carts.Add(cart);
            }

            var cartItem = cart.Items.FirstOrDefault(ci => ci.BeerId == beerId);
            if (cartItem != null)
            {
                cartItem.Quantity += quantity;
            }
            else
            {
                cartItem = new CartItem { CartId = cart.Id, BeerId = beerId, Quantity = quantity };
                cart.Items.Add(cartItem);
            }

            await _context.SaveChangesAsync();
        }

        public async Task RemoveFromCartAsync(string customerId, int beerId)
        {
            var cart = await _context.Carts
                .Include(c => c.Items)
                .FirstOrDefaultAsync(c => c.CustomerId == customerId);

            if (cart == null) return;

            var cartItem = cart.Items.FirstOrDefault(i => i.BeerId == beerId);
            if (cartItem != null)
            {
                cart.Items.Remove(cartItem);
                _context.CartItems.Remove(cartItem);
                await _context.SaveChangesAsync();
            }
        }

        public async Task ClearCartAsync(string customerId)
        {
            var cart = await _context.Carts
                .Include(c => c.Items)
                .FirstOrDefaultAsync(c => c.CustomerId == customerId);

            if (cart == null) return;

            _context.CartItems.RemoveRange(cart.Items);
            cart.Items.Clear();
            await _context.SaveChangesAsync();
        }
        public async Task<Order> CreateOrderAsync(string customerId)
        {
            var cart = await _context.Carts
                .Include(c => c.Items)
                .ThenInclude(i => i.Beer)
                .FirstOrDefaultAsync(c => c.CustomerId == customerId);

            if (cart == null || !cart.Items.Any())
            {
                return null;
            }

            var order = new Order
            {
                CustomerId = customerId,
                OrderDate = DateTime.Now,
                OrderItems = cart.Items.Select(i => new OrderItem
                {
                    BeerId = i.BeerId,
                    Quantity = i.Quantity,
                    Price = i.Beer.Price
                }).ToList()
            };

            _context.Orders.Add(order);
            _context.Carts.Remove(cart);

            await _context.SaveChangesAsync();

            return order;
        }
    }
}

