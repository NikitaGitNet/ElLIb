using ElLIb.Domain.Entities;
using ElLIb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using System.Linq;
using ElLIb.Domain;
using System.Collections.Generic;

namespace ElLIb.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly DataManager dataManager;
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, DataManager dataManager)
        {
            this.dataManager = dataManager;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View(new LoginViewModel());
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = await userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    await signInManager.SignOutAsync();
                    Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
                    if (result.Succeeded)
                    {
                        return Redirect(returnUrl ?? "/");
                    }
                }
                ModelState.AddModelError(nameof(LoginViewModel.Email),"Неверный email или пароль");
            }
            return View(model);
        }
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View(new RegisterViewModel());
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            
            if (ModelState.IsValid)
            {
                model.MaxLengthName = false;
                model.UniqueName = false;
                IEnumerable<ApplicationUser> users = dataManager.ApplicationUser.GetApplicationUsers();
                var sortUsers = from u in users where u.UserName == model.UserName select u;
                if (sortUsers.Any())
                {
                    model.UniqueName = true;
                    return View(model);
                }
                if (model.UserName.Length > 20)
                {
                    model.MaxLengthName = true;
                    return View(model);
                }
                ApplicationUser user = new() { UserName = model.UserName, Email = model.Email, CreateOn = DateTime.Now};
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }
    }
}
