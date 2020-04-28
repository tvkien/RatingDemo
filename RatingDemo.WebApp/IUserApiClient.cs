using RatingDemo.WebApp.Models;
using System.Threading.Tasks;

namespace RatingDemo.WebApp
{
    public interface IUserApiClient
    {
        Task<string> Authenticate(LoginRequest request);
    }
}
