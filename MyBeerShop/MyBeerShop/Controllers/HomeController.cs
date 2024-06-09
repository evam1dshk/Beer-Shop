using Microsoft.AspNetCore.Mvc;
using MyBeerShop.Models;
using System.Diagnostics;

namespace MyBeerShop.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

     
        public IActionResult Error(int statusCode)
        {
            if(statusCode == 400 || statusCode == 404)
            {
                return View("Error400");
            }

            if(statusCode == 401)
            {
                return View("Error401");
            }

            return View();
        }
    }
}