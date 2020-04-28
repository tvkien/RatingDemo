using FluentValidation;
using RatingDemo.BackendApi.Models;

namespace RatingDemo.BackendApi.FluentValidation
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(x => x.Passcode)
                .NotEmpty().WithMessage("Passcode is required")
                .MinimumLength(6).WithMessage("Passcode is at least 6 characters");
        }
    }
}