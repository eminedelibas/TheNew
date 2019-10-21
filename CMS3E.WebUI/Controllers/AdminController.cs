using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CMS.WebUI.Controllers
{
    public class AdminController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private IPasswordValidator<ApplicationUser> _passwordValidator;
        private IPasswordHasher<ApplicationUser> _passwordHasher;

        public AdminController(UserManager<ApplicationUser> userManager, IPasswordValidator<ApplicationUser> passwordValidator, IPasswordHasher<ApplicationUser> passwordHasher)
        {
            _userManager = userManager;
            _passwordValidator = passwordValidator;
            _passwordHasher = passwordHasher;
        }
        public IActionResult Index()
        {
            return View(_userManager.Users);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user= new ApplicationUser();
                user.UserName = model.UserName;
                user.Email = model.Email;

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("",item.Description);
                    }
                }
            }
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string Id)
        {
            var user = await _userManager.FindByIdAsync(Id);

            if (user != null)
            {
                var result = await _userManager.DeleteAsync(user);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("",item.Description);
                    }
                }
            }
            else
            {
                ModelState.AddModelError("","user not found");
            }

            return View("Index", _userManager.Users);
        }

        [HttpGet]
        public async Task<IActionResult> Update(string Id)
        {
            var user = await _userManager.FindByIdAsync(Id);

            if (user != null)
            {
                return View(user);
            }
            else
            {
                return RedirectToAction("Index");
            }

        }
        [HttpPost]
        public async Task<IActionResult> Update(string Id,string Password,string Email)
        {
            var user = await _userManager.FindByIdAsync(Id);

            if (user != null)
            {
                user.Email = Email;

                IdentityResult validPass = null;

                if (!string.IsNullOrEmpty(Password))
                {
                    validPass = await _passwordValidator.ValidateAsync(_userManager, user, Password);

                    if (validPass.Succeeded)
                    {
                        user.PasswordHash = _passwordHasher.HashPassword(user, Password);
                    }
                    else
                    {
                        foreach (var item in validPass.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                        }
                    }
                }

                if (validPass.Succeeded)
                {
                    var result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        foreach (var item in result.Errors)
                        {
                            ModelState.AddModelError("",item.Description);
                        }
                    }
                }
            }
            else
            {
                ModelState.AddModelError("","User Not Found");
            }

            return View(user);

        }
    }
}