using RatingDemo.BackendApi.Models;
using System.Threading.Tasks;

namespace RatingDemo.BackendApi.Businesses
{
    public interface IRatingService
    {
        Task SaveRatingInformationAsync(RatingInfoRequest request);
    }
}