using Microsoft.AspNetCore.Mvc;

namespace RatingDemo.WebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}