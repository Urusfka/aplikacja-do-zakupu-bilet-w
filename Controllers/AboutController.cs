using Microsoft.AspNetCore.Mvc;

namespace TicketsShop.Controllers
{
    public class AboutController : Controller
    {
        [ActionName("Performance")]
        public IActionResult GetPerformancePage()
        {
            return View();
        }
    }
}
