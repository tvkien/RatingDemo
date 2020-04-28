using RatingDemo.BackendApi.Models;
using System.Threading.Tasks;

namespace RatingDemo.BackendApi
{
    public interface IUsersService
    {
        Task<string> AuthenticateAsync(LoginRequest request);
    }
}