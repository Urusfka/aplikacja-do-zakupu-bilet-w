using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TIcketsShop.Controllers
{
    public class FilterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ByType(string type)
        {
            ViewData["FilterName"] = type;
            return View("Index");
        }

        public IActionResult ByCity(string name)
        {
            ViewData["FilterName"] = name;

            return View("Index");
        }
    }
}
