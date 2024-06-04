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

        public IActionResult Details(int id)
        {
            var beer = _context.Beers
                .Where(b => b.Id == id)
                .Select(b => new BeersDetailsViewModel
                {
                    BeerName = b.BeerName,
                    ImageUrl = b.ImageUrl,
                    Description = b.Description,
                    Price = b.Price,
                    Producer = b.Producer,
                    CriticScore = b.CriticScore,
                    AlcoholBV = b.AlcoholBV,
                    TestingNotes = b.TestingNotes,
                    Packaging = b.Packaging
                }).FirstOrDefault();

            if (beer == null)
            {
                return NotFound();
            }

            return View(beer);
        }
    }
}
