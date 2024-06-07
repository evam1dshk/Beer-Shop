using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBeerShop.Data.Entities;
using MyBeerShop.Services;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MyBeerShop.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly UserManager<Customer> _userManager;

        public CartController(ICartService cartService, UserManager<Customer> userManager)
        {
            _cartService = cartService;
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var customerId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var cart = await _cartService.GetCartAsync(customerId);
            return View(cart?.Items ?? new List<CartItem>());
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(int beerId, int quantity)
        {
            var customerId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await _cartService.AddToCartAsync(customerId, beerId, quantity);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCart(int beerId)
        {
            var customerId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await _cartService.RemoveFromCartAsync(customerId, beerId);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> ClearCart()
        {
            var customerId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await _cartService.ClearCartAsync(customerId);
            return RedirectToAction("Index");
        }
    }
}
