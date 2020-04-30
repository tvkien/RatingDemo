using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RatingDemo.BackendApi.Businesses;
using RatingDemo.BackendApi.Models;

namespace RatingDemo.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService) 
            => this.usersService = usersService;

        [HttpPost("authenticate")]
        public async Task<IActionResult> AuthenticateAsync([FromBody]LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var resultToken = await usersService.AuthenticateAsync(request);

            if (string.IsNullOrEmpty(resultToken))
            {
                return BadRequest(new AuthenticateResponse
                {
                    IsSucceed = false,
                    ErrorMessage = "Passcode is incorrect. Please try again."
                });
            }

            return Ok(new AuthenticateResponse
            {
                IsSucceed = true,
                Tokens = resultToken
            });
        }
    }
}