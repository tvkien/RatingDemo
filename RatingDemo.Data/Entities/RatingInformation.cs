using RatingDemo.Data.Enums;

namespace RatingDemo.Data.Entities
{
    public class RatingInformation
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public ServiceType ServiceType { get; set; }
        public int Scored { get; set; }
        public string Description { get; set; }
    }
}