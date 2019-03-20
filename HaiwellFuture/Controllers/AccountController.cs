using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HaiwellFuture.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

namespace HaiwellFuture.Controllers
{
    public class AccountController:Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return this.View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(loginViewModel);
            }
            var user = await this.userManager.FindByNameAsync(loginViewModel.Name);
            if(user != null)
            {
                var result = await this.signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, false);
                if (result.Succeeded)
                {
                    return this.RedirectToAction("Index", "Home");
                }
            }
            this.ModelState.AddModelError(string.Empty, "用户名/密码错误");
            return this.View(loginViewModel);
        }
        [HttpGet]
        public IActionResult Register()
        {
            return this.View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(registerViewModel);
            }
            IdentityUser user = new IdentityUser(registerViewModel.Name);
            var result = await this.userManager.CreateAsync(user, registerViewModel.Password);
            if (result.Succeeded)
            {
                return this.RedirectToAction("Index", "Home");
            }
            foreach(var item in result.Errors)
            {
                this.ModelState.AddModelError(string.Empty, item.Description);
            }
            return this.View(registerViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await this.signInManager.SignOutAsync();
            return this.RedirectToAction("Index", "Home");
        }
    }
}
