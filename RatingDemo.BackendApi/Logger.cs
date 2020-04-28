using RatingDemo.Data.Entities;
using RatingDemo.Data.EntityFramework;
using System.Threading.Tasks;

namespace RatingDemo.BackendApi
{
    public class Logger : ILogger
    {
        private readonly RatingDBContext ratingDBContext;

        public Logger(RatingDBContext ratingDBContext)
        {
            this.ratingDBContext = ratingDBContext;
        }
        public async Task LoggingAsync(EventAuditDetail eventAudit)
        {
            ratingDBContext.EventAuditDetails.Add(eventAudit);
            await ratingDBContext.SaveChangesAsync();
        }
    }
}