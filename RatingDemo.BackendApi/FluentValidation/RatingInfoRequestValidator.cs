using FluentValidation;
using RatingDemo.BackendApi.Models;

namespace RatingDemo.BackendApi.FluentValidation
{
    public class RatingInfoRequestValidator : AbstractValidator<RatingInfoRequest>
    {
        public RatingInfoRequestValidator()
        {
            RuleFor(x => x.Passcode)
                .NotEmpty().WithMessage("Passcode is required")
                .MinimumLength(6).WithMessage("Passcode is at least 4 characters");
            RuleFor(x => x.Scored).GreaterThan(0).WithMessage("Sored is required");
        }
    }
}