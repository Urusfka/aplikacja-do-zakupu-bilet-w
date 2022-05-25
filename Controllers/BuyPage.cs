using Microsoft.AspNetCore.Mvc;

namespace TicketsShop.Controllers
{
    public class BuyPage : Controller
    {
        public IActionResult Index()
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
