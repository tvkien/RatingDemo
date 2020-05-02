using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
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

            var authenticateResponse = await userHandler.Authenticate(request);

            if (!authenticateResponse.IsSucceed)
            {
                ModelState.AddModelError(nameof(request.Passcode), authenticateResponse.ErrorMessage);
                return View();
            }

            var claimsPrincipal = userHandler.ValidateToken(authenticateResponse.Tokens);
            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                IsPersistent = false
            };
            HttpContext.Session.SetServiceType(request.Service);

            await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        claimsPrincipal,
                        authProperties);

            return RedirectToAction("Index", "Rating", new { ServiceType = request.Service });
        }

        [HttpGet]
        public IActionResult Logout()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logout(LoginRequest request)
        {
            ClearModelError(nameof(request.Service));
            if (!ModelState.IsValid)
            {
                return PartialView("_ExitModal", request);
            }

            if (request.Passcode != HttpContext.User.GetPasscode())
            {
                ModelState.AddModelError(nameof(request.Passcode), "Nhập sai passcode. Vui lòng nhập lại.");
                return PartialView("_ExitModal", request);
            }

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Json(new { redirectToUrl = Url.Action("Index", "Home") });
        }

        [HttpPost]
        public IActionResult ChangeService(LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("_ChangeServiceModal", request);
            }

            if (request.Passcode != HttpContext.User.GetPasscode())
            {
                ModelState.AddModelError(nameof(request.Passcode), "Nhập sai passcode. Vui lòng nhập lại.");
                return PartialView("_ChangeServiceModal", request);
            }

            HttpContext.Session.SetServiceType(request.Service);

            return Json(new { redirectToUrl = Url.Action("Index", "Rating") });
        }

        private void ClearModelError(string key)
        {
            if (ModelState.ContainsKey(key))
            {
                ModelState[key].Errors.Clear();
            }
        }
    }
}