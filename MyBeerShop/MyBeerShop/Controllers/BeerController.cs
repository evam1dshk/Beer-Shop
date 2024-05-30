using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyBeerShop.Data;
using MyBeerShop.Models.Beers;

namespace MyBeerShop.Controllers
{
    public class BeerController : Controller
    {
        private readonly MyBeerShopDbContext _context;

        public BeerController(MyBeerShopDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var beers = await _context.Beers.ToListAsync();
            var viewModel = beers.Select(b => new BeerViewModel
            {
                Id = b.Id,
                BeerName = b.BeerName,
                ImageUrl = b.ImageUrl,
                Price = b.Price
            }).ToList();

            return View(viewModel);
        }


    }
}
