using Microsoft.AspNetCore.Mvc;

namespace AthMan.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}