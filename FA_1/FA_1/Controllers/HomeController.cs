using Microsoft.AspNetCore.Mvc;

namespace FA_1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}