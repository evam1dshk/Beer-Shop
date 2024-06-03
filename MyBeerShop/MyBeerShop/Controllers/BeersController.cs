using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyBeerShop.Data;
using MyBeerShop.Models.Beers;

namespace MyBeerShop.Controllers
{
    public class BeersController : Controller
    {
        private readonly MyBeerShopDbContext _context;

        public BeersController(MyBeerShopDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> All()
        {

            var beers = _context.Beers
                .Select(b => new BeerViewModel
                {
                    Id = b.Id,
                    BeerName = b.BeerName,
                    ImageUrl = b.ImageUrl,
                    Price = b.Price
                })
                .ToList();

            return View(beers);
        }
    }
}
