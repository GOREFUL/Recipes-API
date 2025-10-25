using FluentValidation;

namespace Recipes.Application.Users.Commands.Login;
public class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(x => x.Payload.Email).NotEmpty()
            .EmailAddress().MaximumLength(256);
        RuleFor(x => x.Payload.Password).NotEmpty().MinimumLength(8);
    }
}
