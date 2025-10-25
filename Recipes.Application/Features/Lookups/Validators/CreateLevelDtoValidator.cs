using FluentValidation;
using Recipes.Application.Features.Lookups.Dto;

namespace Recipes.Application.Features.Lookups.Validators;
public class CreateLevelDtoValidator : AbstractValidator<CreateLevelDto>
{
    public CreateLevelDtoValidator() => RuleFor(x => x.Name).NotEmpty().MaximumLength(128);
}
