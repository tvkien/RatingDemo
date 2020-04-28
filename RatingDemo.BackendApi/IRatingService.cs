using RatingDemo.BackendApi.Models;
using System.Threading.Tasks;

namespace RatingDemo.BackendApi
{
    public interface IRatingService
    {
        Task SaveRatingInformationAsync(RatingInfoRequest request);
    }
}