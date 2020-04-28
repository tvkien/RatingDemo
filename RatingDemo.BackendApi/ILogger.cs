using RatingDemo.Data.Entities;
using System.Threading.Tasks;

namespace RatingDemo.BackendApi
{
    public interface ILogger
    {
        Task LoggingAsync(EventAuditDetail eventAudit);
    }
}