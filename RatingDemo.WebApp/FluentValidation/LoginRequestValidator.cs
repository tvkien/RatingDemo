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
                .NotEmpty().WithMessage("Vui lòng nhập thông tin Passcode.")
                .MinimumLength(4).WithMessage("Passcode ít nhất phải có 4 ký tự.");
        }
    }
}