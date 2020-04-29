using Microsoft.AspNetCore.Mvc;
using RatingDemo.WebApp.Businesses;
using RatingDemo.WebApp.Domains;
using RatingDemo.WebApp.Models;
using System.Threading.Tasks;

namespace RatingDemo.WebApp.Controllers
{
    public class RatingController : Controller
    {
        private readonly IRatingHandlers ratingHandlers;

        public RatingController(IRatingHandlers ratingHandlers)
        {
            this.ratingHandlers = ratingHandlers;
        }

        [HttpGet]
        public IActionResult Index(ServiceType ServiceType)
        {
            ViewBag.ServiceType = ServiceType;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(RatingInfoRequest request)
        {
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