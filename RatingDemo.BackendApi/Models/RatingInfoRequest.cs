using RatingDemo.Data.Enums;

namespace RatingDemo.BackendApi.Models
{
    public class RatingInfoRequest
    {
        public string Passcode { get; set; }
        public int QuestionId { get; set; }
        public ServiceType ServiceType { get; set; }
        public int Scored { get; set; }
        public string Description { get; set; }
    }
}