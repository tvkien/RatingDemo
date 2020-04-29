using RatingDemo.WebApp.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace RatingDemo.WebApp.Businesses
{
    public class RatingApiClient : IRatingApiClient
    {
        private readonly IHttpClientFactory httpClientFactory;

        public RatingApiClient(IHttpClientFactory httpClientFactory)
            => this.httpClientFactory = httpClientFactory;

        public async Task<string> AuthenticateAsync(LoginRequest request)
        {
            var client = httpClientFactory.CreateClient(HttpClientName.BackendApi);
            var result = await client.PostAsJsonAsync("api/users/authenticate", request);

            return await result.Content.ReadAsStringAsync();
        }

        public async Task SaveRatingAsync(RatingInfoRequest request)
        {
            var client = httpClientFactory.CreateClient(HttpClientName.BackendApi);
            await client.PostAsJsonAsync("api/rating/save-rating", request);
        }
    }
}