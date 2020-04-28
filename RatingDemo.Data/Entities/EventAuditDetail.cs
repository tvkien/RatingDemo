using RatingDemo.Data.Enums;
using System;

namespace RatingDemo.Data.Entities
{
    public class EventAuditDetail
    {
        public int Id { get; set; }
        public string Passcode { get; set; }
        public EventTypes EventType { get; set; }
        public ServiceType ServiceType { get; set; }
        public string EventMessage { get; set; }
        public DateTime OccurredAt { get; set; }
    }
}