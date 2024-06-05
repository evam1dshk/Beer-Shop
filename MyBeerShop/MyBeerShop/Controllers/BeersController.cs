using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyBeerShop.Data;
using MyBeerShop.Data.Entities;
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

        [HttpGet]
        public IActionResult Add()
        {
            var model = new BeerViewModel
            {
                BeerTypes = _context.BeerTypes.ToList()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(BeerViewModel model)
        {
            if (ModelState.IsValid)
            {
                var beer = new Beer
                {
                    BeerName = model.BeerName,
                    Producer = model.Producer,
                    ImageUrl = model.ImageUrl,
                    AlcoholBV = model.AlcoholBV,
                    CriticScore = model.CriticScore,
                    Description = model.Description,
                    TestingNotes = model.TestingNotes,
                    Packaging = model.Packaging,
                    BeerTypeId = model.BeerTypeId,
                    Price = model.Price
                };

                _context.Beers.Add(beer);
                _context.SaveChanges();

                return RedirectToAction("All");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var beer = _context.Beers.Find(id);
            if (beer == null)
            {
                return NotFound();
            }

            var model = new BeerViewModel
            {
                Id = beer.Id,
                BeerName = beer.BeerName,
                Producer = beer.Producer,
                ImageUrl = beer.ImageUrl,
                Price = beer.Price,
                CriticScore = beer.CriticScore,
                AlcoholBV = beer.AlcoholBV,
                Description = beer.Description,
                TestingNotes = beer.TestingNotes,
                Packaging = beer.Packaging,
                BeerTypeId = beer.BeerTypeId,
                BeerTypes = _context.BeerTypes.ToList()
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(BeerViewModel model)
        {
            if (ModelState.IsValid)
            {
                var beer = _context.Beers.Find(model.Id);
                if (beer == null)
                {
                    return NotFound();
                }

                beer.BeerName = model.BeerName;
                beer.Producer = model.Producer;
                beer.ImageUrl = model.ImageUrl;
                beer.AlcoholBV = model.AlcoholBV;
                beer.CriticScore = model.CriticScore;
                beer.Description = model.Description;
                beer.TestingNotes = model.TestingNotes;
                beer.Packaging = model.Packaging;
                beer.BeerTypeId = model.BeerTypeId;
                beer.Price = model.Price;

                _context.SaveChanges();

                return RedirectToAction("All");
            }

            model.BeerTypes = _context.BeerTypes.ToList();
            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var beer = _context.Beers
                .Where(b => b.Id == id)
                .Select(b => new BeerViewModel
                {
                    Id = b.Id,
                    BeerName = b.BeerName,
                    Producer = b.Producer,
                    ImageUrl = b.ImageUrl,
                    Price = b.Price,
                    CriticScore = b.CriticScore,
                    AlcoholBV = b.AlcoholBV,
                    Description = b.Description,
                    TestingNotes = b.TestingNotes,
                    Packaging = b.Packaging
                })
                .FirstOrDefault();

            if (beer == null)
            {
                return NotFound();
            }

            return View(beer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var beer = _context.Beers.Find(id);
            if (beer == null)
            {
                return NotFound();
            }

            _context.Beers.Remove(beer);
            _context.SaveChanges();

            return RedirectToAction(nameof(All));
        }


        public IActionResult All()
        {
            var beers = _context.Beers.Select(b => new BeerViewModel
            {
                Id = b.Id,
                BeerName = b.BeerName,
                Producer = b.Producer,
                ImageUrl = b.ImageUrl,
                Price = b.Price
            }).ToList();

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
