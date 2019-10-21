using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CMS.WebUI.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signinManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signinManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signinManager = signinManager;
        }

        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model,string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    await _signinManager.SignOutAsync();
                    var result = await _signinManager.PasswordSignInAsync(user, model.Password, false, false);
                    if (result.Succeeded)
                    {
                        //var roles = await _userManager.GetRolesAsync(user);


                        //if (roles?.FirstOrDefault() == "Admin")
                        //{
                        //    return RedirectToAction("Admin", "Home");
                        //}
                        //else
                        //{
                        //    return RedirectToAction("UserPage", "Home");
                        //}
                        return Redirect(returnUrl);

                    }
                }
                ModelState.AddModelError("Email","Invalid Email or Password");
            }

            return View(model);
        }

        public async Task<RedirectToActionResult> Logout()
        {
            await _signinManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }


    }
}