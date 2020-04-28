using RatingDemo.WebApp.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace RatingDemo.WebApp
{
    public class UserApiClient : IUserApiClient
    {
        private readonly IHttpClientFactory httpClientFactory;

        public UserApiClient(IHttpClientFactory httpClientFactory) 
            => this.httpClientFactory = httpClientFactory;

        public async Task<string> Authenticate(LoginRequest request)
        {
            var client = httpClientFactory.CreateClient(HttpClientName.BackendApi);
            var result = await client.PostAsJsonAsync("api/users/authenticate", request);

            return await result.Content.ReadAsStringAsync();
        }
    }
}