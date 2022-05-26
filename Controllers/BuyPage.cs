using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
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
            var @event = _db.Events.Include(x => x.City).FirstOrDefault(x => x.Id == id);

            return View(@event);
        }
        public IActionResult Blik(Guid id)
        {
            var @event = _db.Events.Include(x => x.City).FirstOrDefault(x => x.Id == id);

            return View("Blik", @event);
        }

        public IActionResult Mastercard(Guid id)
        {
            var @event = _db.Events.Include(x => x.City).FirstOrDefault(x => x.Id == id);

            return View("Mastercard", @event);
        }

        public IActionResult Status(Guid id)
        {
            var @event = _db.Events.Include(x => x.City).FirstOrDefault(x => x.Id == id);

            @event.TicketsNumber--;

            _db.SaveChanges();

            return View("Status", @event);
        }
    }
}
