using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TicketsShop.Models;

namespace TicketsShop.Controllers
{
    public class PlacePickerController : Controller
    {
        private ApplicationContext _db;
        public PlacePickerController(ApplicationContext db)
        {
            _db = db;
        }

        public IActionResult GetPlaces(Guid id)
        {
            var @event = _db.Events.FirstOrDefault(x => x.Id == id);

            return View("Places",@event);
        }
    }
}
