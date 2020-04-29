using RatingDemo.WebApp.Domains;

namespace RatingDemo.WebApp.Models
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