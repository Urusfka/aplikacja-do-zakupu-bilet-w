using Microsoft.AspNetCore.Mvc;

namespace TicketsShop.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
