using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TicketsShop.Models;

namespace TicketsShop.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationContext _db;

        public HomeController(ApplicationContext context)
        {
            _db = context;
        }

        public IActionResult Index()
        {
            return View("Home", _db.Events.ToList());
        }
    }
}
