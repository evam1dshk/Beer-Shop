using Microsoft.EntityFrameworkCore;
using MyBeerShop.Data;
using MyBeerShop.Data.Entities;
using MyBeerShop.Data.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBeerShop.Services
{
    public class OrderService : IOrderService
    {
        private readonly MyBeerShopDbContext _context;

        public OrderService(MyBeerShopDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> GetOrdersByCustomerAsync(string customerId)
        {
            return await _context.Orders
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.Beer)
                    .Include(o => o.Customer)
                .Where(o => o.CustomerId == customerId)
                .ToListAsync();
        }

        public async Task<Order> GetOrderByIdAsync(int orderId)
        {
            return await _context.Orders
                 .Include(o => o.OrderItems)
                     .ThenInclude(oi => oi.Beer)
                 .Include(o => o.Customer)
                 .FirstOrDefaultAsync(o => o.Id == orderId);
        }

        public async Task<Order> CreateOrderAsync(string customerId, string shippingAddress, string billingAddress, string paymentMethod)
        {
            var order = new Order
            {
                CustomerId = customerId,
                ShippingAddress = shippingAddress,
                BillingAddress = billingAddress,
                PaymentMethod = paymentMethod,
                OrderDate = DateTime.UtcNow,
                Status = OrderStatus.Pending,
                PaymentStatus = PaymentStatus.Pending
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return order;
        }

        public async Task<Order> ProcessPaymentAsync(int orderId, string paymentMethod)
        {
            var order = await _context.Orders
                .FirstOrDefaultAsync(o => o.Id == orderId);

            if (order == null)
                throw new InvalidOperationException("Order not found.");

            order.PaymentMethod = paymentMethod;
            order.PaymentStatus = PaymentStatus.Paid;
            order.PaymentDate = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return order;
        }

        public async Task<List<Order>> GetAllOrdersAsync()
        {
            return await _context.Orders
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.Beer)
                .Include(o => o.Customer)
                .ToListAsync();
        }

        public async Task<bool> UpdateOrderStatusAsync(int orderId, OrderStatus status)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(o => o.Id == orderId);
            if (order == null)
                return false;

            order.Status = status;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
