﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using MMS.Data.Services;
using MMS.Web.Models;
using MMS.Web;


namespace MMS.Web.Controllers
{
    public class UserController : BaseController
    {
        private readonly IPatientService svc;

        // Configured via DI
        public UserController(IPatientService ps)
        {
            svc = ps;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("Email,Password")] UserLoginViewModel m)
        {
            // call service to Authenticate User
            var user = svc.Authenticate(m.Email, m.Password);
            if (user == null)
            {
                ModelState.AddModelError("Email", "Invalid Login Credentials");
                ModelState.AddModelError("Password", "Invalid Login Credentials");
                return View(m);
            }

            // sign user in using cookie authentication
            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                AuthBuilder.BuildClaimsPrincipal(user)
                );

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register([Bind("Name, Email, Password,PasswordConfirm,Role")]UserRegisterViewModel m)
        {
            if (!ModelState.IsValid)
            {
                return View(m);
            }

            var user = svc.Register(m.Name, m.Email, m.Password, m.Role);

            // check if email address is unique
            if (user == null)
            {
                ModelState.AddModelError("Email", "Email address is already in use. Choose another.");
                return View(m);
            }

            // registration successful now redirect to login page
            Alert("Registration Successful - Now Login", AlertType.Info);
            return RedirectToAction(nameof(Login));
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(Login));
        }

        public IActionResult ErrorNotAuthorised()
        {
            Alert("Not Authorised", AlertType.Warning);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult ErrorNotAuthenticated()
        {
            Alert("Not Authenticated", AlertType.Warning);
            return RedirectToAction("Login", "User");
        }

        [AcceptVerbs("GET", "POST")]
        public IActionResult VerifyEmailAddress(string email)
        {
            if (svc.GetUserByEmail(email) != null)
            {
                return Json($"Email Address {email} is already in use. Choose another.");
            }
            return Json(true);
        }

    }
}
