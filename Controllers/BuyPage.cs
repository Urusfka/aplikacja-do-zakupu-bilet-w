using System;
using Microsoft.AspNetCore.Mvc;
using TicketsShop.Models;

namespace TicketsShop.Controllers
{
    public class BuyPage : Controller
    {
        private ApplicationContext _db;

        public BuyPage(ApplicationContext db)
        {
            _db = db;
        }

        public IActionResult Index(Guid id)
        {
            return View();
        }
        public IActionResult Blik()
        {
            return View("Blik");
        }

        public IActionResult Mastercard()
        {
            return View("Mastercard");
        }
    }
}
