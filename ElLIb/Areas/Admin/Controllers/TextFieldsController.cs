using ElLIb.Domain;
using ElLIb.Domain.Entities;
using ElLIb.Domain.Interfaces;
using ElLIb.Service;
using Microsoft.AspNetCore.Mvc;

namespace ElLIb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TextFieldsController : Controller
    {
        private readonly IRepository<TextField> textFieldRepository;
        public TextFieldsController(IRepository<TextField> textFieldRepository)
        {
            this.textFieldRepository = textFieldRepository;
        }
        public IActionResult Edit(string codeWord)
        {
            var entity = textFieldRepository.GetByCodeWord(codeWord);
            return View(entity);
        }
        [HttpPost]
        public IActionResult Edit(TextField model)
        {
            if (ModelState.IsValid)
            {
                textFieldRepository.Save(model);
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
            }
            return View(model);
        }
    }
}
