using FluentValidation;
using RatingDemo.WebApp.Domains;
using RatingDemo.WebApp.Models;

namespace RatingDemo.WebApp.FluentValidation
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(x => x.Passcode)
                .NotEmpty().WithMessage("Passcode is required")
                .MinimumLength(4).WithMessage("Passcode is at least 4 characters");

            RuleFor(x => x.Service).Custom((type, context) =>
            {
                if (type == ServiceType.None)
                {
                    context.AddFailure("Please choose the service type.");
                }
            });
        }
    }
}