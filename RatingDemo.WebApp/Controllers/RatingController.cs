using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RatingDemo.WebApp.Businesses;
using RatingDemo.WebApp.Models;
using System.Threading.Tasks;

namespace RatingDemo.WebApp.Controllers
{
    [Authorize]
    public class RatingController : Controller
    {
        private readonly IRatingHandlers ratingHandlers;

        public RatingController(IRatingHandlers ratingHandlers)
        {
            this.ratingHandlers = ratingHandlers;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(RatingInfoRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            request.Passcode = HttpContext.User.GetPasscode();
            await ratingHandlers.SaveRating(request);

            return RedirectToAction("ResultRating", "Rating");
        }

        [HttpGet]
        public IActionResult ResultRating()
        {
            return View();
        }
    }
}