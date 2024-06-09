using MyBeerShop.Data.Entities;
using MyBeerShop.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBeerShop.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetOrdersByCustomerAsync(string customerId);
        Task<Order> GetOrderByIdAsync(int orderId);
        Task<Order> CreateOrderAsync(string customerId, string shippingAddress, string billingAddress, string paymentMethod);
        Task<Order> ProcessPaymentAsync(int orderId, string paymentMethod);
        Task<bool> UpdateOrderStatusAsync(int orderId, OrderStatus status);
        Task<List<Order>> GetAllOrdersAsync();
    }
}
