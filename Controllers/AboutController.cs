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

        public IActionResult GetAboutPage(Guid id)
        {
            var @events = _db.Events.Include(x=>x.City).Where(e => e.Id == id).ToList();

            return View("About", @events);
        }
    }
}
