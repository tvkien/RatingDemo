using FluentValidation;
using RatingDemo.WebApp.Models;

namespace RatingDemo.BackendApi.FluentValidation
{
    public class RatingInfoRequestValidator : AbstractValidator<RatingInfoRequest>
    {
        public RatingInfoRequestValidator()
        {
            RuleFor(x => x.Scored).GreaterThan(0).WithMessage("Vui lòng lựa chọn xếp hạng.");
        }
    }
}