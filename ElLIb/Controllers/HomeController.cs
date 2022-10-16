using ElLIb.Domain;
using ElLIb.Domain.Entities;
using ElLIb.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ElLIb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<TextField> textFieldRepository;
        public HomeController(IRepository<TextField> textFieldRepository)
        {
            this.textFieldRepository = textFieldRepository;
        }
        public IActionResult Index()
        {
            return View(textFieldRepository.GetByCodeWord("PageIndex"));
        }
        public IActionResult Contacts()
        {
            return View(textFieldRepository.GetByCodeWord("PageContacts"));
        }
        public IActionResult MobileHeader()
        {
            return View();
        }
    }
}
