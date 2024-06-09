using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBeerShop.Data.Entities;
using MyBeerShop.Data.Enums;
using MyBeerShop.Services;
using System.Threading.Tasks;

namespace MyBeerShop.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly UserManager<Customer> _userManager;

        public AdminController(IOrderService orderService, UserManager<Customer> userManager)
        {
            _orderService = orderService;
            _userManager = userManager;
        }

        public async Task<IActionResult> AdminPanel()
        {
            var orders = await _orderService.GetAllOrdersAsync();
            return View(orders);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateOrderStatus(int orderId, OrderStatus status)
        {
            var result = await _orderService.UpdateOrderStatusAsync(orderId, status);
            if (result)
            {
                return RedirectToAction("AdminPanel");
            }

            ModelState.AddModelError("", "Failed to update order status.");
            return RedirectToAction("AdminPanel");
    }
    }
}
