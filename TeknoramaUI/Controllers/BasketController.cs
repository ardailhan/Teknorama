using Microsoft.AspNetCore.Mvc;

namespace TeknoramaUI.Controllers
{
    public class BasketController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
