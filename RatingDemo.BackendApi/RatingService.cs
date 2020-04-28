using RatingDemo.BackendApi.Models;
using RatingDemo.Data.Entities;
using RatingDemo.Data.EntityFramework;
using System;
using System.Threading.Tasks;

namespace RatingDemo.BackendApi
{
    public class RatingService : IRatingService
    {
        private readonly RatingDBContext ratingDBContext;
        private readonly ILogger logger;

        public RatingService(RatingDBContext ratingDBContext, ILogger logger)
        {
            this.ratingDBContext = ratingDBContext;
            this.logger = logger;
        }

        public async Task SaveRatingInformationAsync(RatingInfoRequest request)
        {
            ratingDBContext.RatingInformations.Add(new RatingInformation
            {
                QuestionId = request.QuestionId,
                Scored = request.Scored,
                Description = request.Description,
                ServiceType = request.ServiceType
            });

            await ratingDBContext.SaveChangesAsync();

            await logger.LoggingAsync(new EventAuditDetail
            {
                Passcode = request.Passcode,
                ServiceType = request.ServiceType,
                EventType = Data.Enums.EventTypes.RaiseService,
                EventMessage = $"The {request.Passcode} has been raise the {request.ServiceType} service with description below: {request.Description}",
                OccurredAt = DateTime.Now
            });
        }
    }
}