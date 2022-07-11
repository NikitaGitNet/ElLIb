using Microsoft.AspNetCore.Mvc;

namespace ElLIb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
