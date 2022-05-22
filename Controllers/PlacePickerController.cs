using Microsoft.AspNetCore.Mvc;

namespace TicketsShop.Controllers
{
    public class PlacePickerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
