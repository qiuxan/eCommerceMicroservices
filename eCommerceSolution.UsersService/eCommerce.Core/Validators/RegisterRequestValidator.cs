
using eCommerce.Core.DTO;
using FluentValidation;

namespace eCommerce.Core.Validators;
public class RegisterRequestValidator: AbstractValidator<RegisterRequest>
{
    public RegisterRequestValidator()
    {

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Invalid email address");
        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required")
            .MinimumLength(6).WithMessage("Password must be at least 6 characters");
        RuleFor(x => x.PersonName)
            .NotEmpty().WithMessage("Person name is required")
            .Length(1, 50).WithMessage("Person Name should be 1 to 50 characters long");

        RuleFor(request => request.Gender)
            .IsInEnum().WithMessage("Invalid gender option");
    }
}
