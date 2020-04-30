using RatingDemo.WebApp.Domains;
using RatingDemo.WebApp.Models;
using System.Threading.Tasks;

namespace RatingDemo.WebApp.Businesses
{
    public interface IRatingApiClient
    {
        Task<AuthenticateResponse> AuthenticateAsync(LoginRequest request);

        Task SaveRatingAsync(RatingInfoRequest request);
    }
}