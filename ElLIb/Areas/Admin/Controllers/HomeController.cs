using ElLIb.Domain;
using ElLIb.Models.Book;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;
using System;
using ElLIb.Models.Genre;
using ElLIb.Models.Author;
using ElLIb.Areas.Admin.Models;

namespace ElLIb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly DataManager dataManager;
        public HomeController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public IActionResult Index(UsersListViewModel usersList)
        {
            return View();
        }
    }
}
