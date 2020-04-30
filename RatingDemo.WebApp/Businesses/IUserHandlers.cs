using RatingDemo.WebApp.Domains;
using RatingDemo.WebApp.Models;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RatingDemo.WebApp.Businesses
{
    public interface IUserHandlers
    {
        Task<AuthenticateResponse> Authenticate(LoginRequest request);
        ClaimsPrincipal ValidateToken(string jwtToken);
    }
}