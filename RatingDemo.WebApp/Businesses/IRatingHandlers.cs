using RatingDemo.WebApp.Models;
using System.Threading.Tasks;

namespace RatingDemo.WebApp.Businesses
{
    public interface IRatingHandlers
    {
        Task SaveRating(RatingInfoRequest request);
    }
}