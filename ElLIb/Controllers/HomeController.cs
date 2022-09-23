using ElLIb.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ElLIb.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataManager dataManager;
        public HomeController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public IActionResult Index()
        {
            return View(dataManager.TextFields.GetTextFieldByCodeWord("PageIndex"));
        }
        public IActionResult Contacts()
        {
            return View(dataManager.TextFields.GetTextFieldByCodeWord("PageContacts"));
        }
        public IActionResult MobileHeader()
        {
            return View();
        }
    }
}
