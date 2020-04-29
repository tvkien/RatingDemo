using RatingDemo.WebApp.Models;
using System.Threading.Tasks;

namespace RatingDemo.WebApp.Businesses
{
    public class RatingHandlers : IRatingHandlers
    {
        private readonly IRatingApiClient ratingApiClient;

        public RatingHandlers(IRatingApiClient ratingApiClient)
        {
            this.ratingApiClient = ratingApiClient;
        }

        public async Task SaveRating(RatingInfoRequest request)
        {
            await ratingApiClient.SaveRatingAsync(request);
        }
    }
}