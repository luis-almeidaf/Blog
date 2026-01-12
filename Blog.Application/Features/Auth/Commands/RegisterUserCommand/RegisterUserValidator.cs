using FluentValidation;

namespace Blog.Application.Features.Auth.Commands.RegisterUserCommand;

public class RegisterUserValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserValidator()
    {
        RuleFor(user => user.Email)
            .NotEmpty()
            .WithMessage("Email is required")
            .EmailAddress()
            .When(user => !string.IsNullOrWhiteSpace(user.Email), ApplyConditionTo.CurrentValidator)
            .WithMessage("Email invalid");
    }
}