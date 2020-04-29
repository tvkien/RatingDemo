using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RatingDemo.BackendApi.Businesses;
using RatingDemo.BackendApi.Models;

namespace RatingDemo.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly IRatingService ratingService;

        public RatingController(IRatingService ratingService) 
            => this.ratingService = ratingService;

        [HttpPost("save-rating")]
        public async Task<IActionResult> SaveRatingAsync([FromBody]RatingInfoRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await ratingService.SaveRatingInformationAsync(request);

            return Ok();
        }
    }
}