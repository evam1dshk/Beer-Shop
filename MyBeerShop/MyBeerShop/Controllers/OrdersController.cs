using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBeerShop.Data.Entities;
using MyBeerShop.Services;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MyBeerShop.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly UserManager<Customer> _userManager;

        public OrdersController(IOrderService orderService, UserManager<Customer> userManager)
        {
            _orderService = orderService;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Checkout(string shippingAddress, string billingAddress, string paymentMethod)
        {
            if (string.IsNullOrWhiteSpace(shippingAddress) || string.IsNullOrWhiteSpace(billingAddress) || string.IsNullOrWhiteSpace(paymentMethod))
            {
                ModelState.AddModelError("", "All fields are required.");
                return View();
            }

            var customerId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            try
            {
                var order = await _orderService.CreateOrderAsync(customerId, shippingAddress, billingAddress, paymentMethod);
                return RedirectToAction("OrderSuccess", new { orderId = order.Id });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var customerId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var orders = await _orderService.GetOrdersByCustomerAsync(customerId);
            return View(orders);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var order = await _orderService.GetOrderByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        [HttpGet]
        public async Task<IActionResult> Payment(int orderId)
        {
            var order = await _orderService.GetOrderByIdAsync(orderId);
            if (order == null || order.CustomerId != User.FindFirstValue(ClaimTypes.NameIdentifier))
            {
                return NotFound();
            }

            return View(order);
        }

        [HttpPost]
        public async Task<IActionResult> Payment(int orderId, string paymentMethod)
        {
            var order = await _orderService.GetOrderByIdAsync(orderId);
            if (order == null || order.CustomerId != User.FindFirstValue(ClaimTypes.NameIdentifier))
            {
                return NotFound();
            }

            try
            {
                var updatedOrder = await _orderService.ProcessPaymentAsync(orderId, paymentMethod);
                return RedirectToAction("OrderDetails", new { orderId = updatedOrder.Id });
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(order);
            }
        }

        public async Task<IActionResult> OrderDetails(int orderId)
        {
            var order = await _orderService.GetOrderByIdAsync(orderId);
            if (order == null || order.CustomerId != User.FindFirstValue(ClaimTypes.NameIdentifier))
            {
                return NotFound();
            }

            return View(order);
        }

        public IActionResult OrderSuccess(int orderId)
        {
            ViewData["OrderId"] = orderId;
            return View();
        }
    }
}
