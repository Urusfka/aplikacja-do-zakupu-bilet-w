using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicketsShop.Models;

namespace TicketsShop.Controllers
{
    public class AboutController : Controller
    {
        private ApplicationContext _db;
        public AboutController(ApplicationContext db)
        {
            _db = db;
        }

        public IActionResult GetAboutPage(string name)
        {
            var @events = _db.Events.Where(e => e.Name == name).Include(x => x.City).ToList();

            return View("About", @events);
        }
    }
}
