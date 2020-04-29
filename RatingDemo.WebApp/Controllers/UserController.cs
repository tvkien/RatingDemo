using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using RatingDemo.WebApp.Businesses;
using RatingDemo.WebApp.Models;
using System;
using System.Threading.Tasks;

namespace RatingDemo.WebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserHandlers userHandler;

        public UserController(IUserHandlers userHandler)
        {
            this.userHandler = userHandler;
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var token = await userHandler.Authenticate(request);
            var claimsPrincipal = userHandler.ValidateToken(token);
            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                IsPersistent = false
            };

            await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        claimsPrincipal,
                        authProperties);

            return RedirectToAction("Index", "Rating", new { ServiceType = request.Service});
        }

        [HttpGet]
        public IActionResult Logout()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logout(LoginRequest request)
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}