﻿using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tutorial.Repository;
using Tutorial.Models;

namespace Tutorial.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [Route("signup")]
        public IActionResult Signup()
        {
            return View();
        }

        [Route("signup")]
        [HttpPost]
        public async Task<IActionResult> Signup(SignUpUserModel userModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountRepository.CreateUserAsync(userModel);
                // Check the result of the operation. Since identity core
                // is doing the validation it may be unsuccessfull if
                // the given emails is already exist, or password doesn't
                // match with the validations. It is important to know that
                // those settings can be changed/updated, still some of them
                // are provided as default.
                if (!result.Succeeded)
                {
                    foreach (var errorMessage in result.Errors)
                    {
                        ModelState.AddModelError("", errorMessage.Description);
                    }

                    return View(userModel);
                }

                ModelState.Clear();
                return View();
            }
            return View(userModel);
        }

        [Route("signin")]
        public IActionResult Signin()
        {
            return View();
        }

        [Route("signin")]
        [HttpPost]
        public async Task<IActionResult> Signin(SignInUserModel userModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountRepository.PasswordSignInAsync(userModel);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return LocalRedirect(returnUrl);
                    }
                    return RedirectToAction("Index", "Home");
                }

                if (result.IsNotAllowed)
                    ModelState.AddModelError("", "Not allowed to login");
                else
                    ModelState.AddModelError("", "Invalid credentials");
            }

            return View();
        }

        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            await _accountRepository.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [Route("change-password")]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [Route("change-password")]
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountRepository.ChangePasswordAsync(model);
                if (result.Succeeded)
                {
                    ViewBag.IsSuccess = true;
                    ModelState.Clear();
                    return View();
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }

    }
}
