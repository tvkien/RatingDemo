using RatingDemo.Data.Entities;
using System.Threading.Tasks;

namespace RatingDemo.BackendApi.Businesses
{
    public interface ILogger
    {
        Task LoggingAsync(EventAuditDetail eventAudit);
    }
}