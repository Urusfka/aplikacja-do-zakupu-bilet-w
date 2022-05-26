using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicketsShop.Models;

namespace TicketsShop.Controllers
{
    public class SearchController : Controller
    {
        private ApplicationContext _db;
        public SearchController(ApplicationContext db)
        {
            _db = db;
        }

        public IActionResult ByType(string type)
        {
            var events = _db.Events.Where(x => x.Type == type).Include(x=>x.City).ToList();

            ViewData["SearchName"] = type;

            return View("Search", events);
        }

        public IActionResult ByCity(string name)
        {
            var events = _db.Events.Where(x => x.City.Name == name).Include(x => x.City).ToList();

            ViewData["SearchName"] = name;

            return View("Search", events);
        }
    }
}
