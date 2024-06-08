using MyBeerShop.Data.Entities;
using MyBeerShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyBeerShop.Data.Enums;

namespace MyBeerShop.Services
{
    public class OrderService : IOrderService
    {
        private readonly MyBeerShopDbContext _context;

        public OrderService(MyBeerShopDbContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetAllOrdersAsync()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<bool> UpdateOrderStatusAsync(int orderId, string status)
        {

            var order = await _context.Orders.FindAsync(orderId);
            if (order == null) return false;

            order.Status = Enum.Parse<OrderStatus>("Confirmed");
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Order>> GetOrdersByCustomerAsync(string customerId)
        {
            return await _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Beer)
                .Where(o => o.CustomerId == customerId)
                .ToListAsync();
        }

        public async Task<Order> GetOrderByIdAsync(int orderId)
        {
            return await _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Beer)
                .FirstOrDefaultAsync(o => o.Id == orderId);
        }
        public async Task<Order> CreateOrderAsync(string customerId, string shippingAddress, string billingAddress, string paymentMethod)
        {
            var cart = await _context.Carts
                .Include(c => c.Items)
                .ThenInclude(i => i.Beer)
                .FirstOrDefaultAsync(c => c.CustomerId == customerId);

            if (cart == null || !cart.Items.Any())
            {
                throw new InvalidOperationException("Cart is empty or not found.");
            }

            var order = new Order
            {
                CustomerId = customerId,
                OrderDate = DateTime.UtcNow,
                TotalAmount = cart.Items.Sum(i => i.Quantity * i.Beer.Price),
                ShippingAddress = shippingAddress,
                BillingAddress = billingAddress,
                PaymentMethod = paymentMethod,
                PaymentDate = DateTime.UtcNow,
                PaymentStatus = PaymentStatus.Pending,
                Status = OrderStatus.Pending
            };

            foreach (var item in cart.Items)
            {
                order.OrderItems.Add(new OrderItem
                {
                    BeerId = item.BeerId,
                    Quantity = item.Quantity,
                    Price = item.Beer.Price
                });
            }

            _context.Orders.Add(order);
            _context.Carts.Remove(cart); // Clear the cart after order creation
            await _context.SaveChangesAsync();

            return order;
    }

        public async Task<IEnumerable<Order>> GetOrdersByCustomerIdAsync(string customerId)
        {
            return await _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Beer)
                .Where(o => o.CustomerId == customerId)
                .ToListAsync();
        }
        public async Task<Order> ProcessPaymentAsync(int orderId, string paymentMethod)
        {
            var order = await _context.Orders.FindAsync(orderId);
            if (order == null)
            {
                throw new InvalidOperationException("Order not found.");
            }

            order.PaymentMethod = paymentMethod;
            order.PaymentDate = DateTime.UtcNow;
            order.PaymentStatus = PaymentStatus.Completed;
            order.Status = OrderStatus.Confirmed;

            _context.Orders.Update(order);
            await _context.SaveChangesAsync();

            return order;
        }
    }
}
