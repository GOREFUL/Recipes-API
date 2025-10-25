using FluentValidation;

namespace Recipes.Application.Users.Commands.CreateUser;
public class CreateUserCommandValidator
    : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(x => x.Payload.Email)
            .NotEmpty()
            .EmailAddress()
            .MaximumLength(256);
        RuleFor(x => x.Payload.Password)
            .NotEmpty()
            .MinimumLength(8);
        RuleFor(x => x.Payload.DisplayName)
            .NotEmpty()
            .MaximumLength(64);
    }
}
