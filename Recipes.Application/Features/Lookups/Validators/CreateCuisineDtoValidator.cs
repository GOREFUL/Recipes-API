using FluentValidation;
using Recipes.Application.Features.Lookups.Dto;

namespace Recipes.Application.Features.Lookups.Validators;
public class CreateCuisineDtoValidator : AbstractValidator<CreateCuisineDto>
{
    public CreateCuisineDtoValidator() => RuleFor(x => x.Name).NotEmpty().MaximumLength(64);
}
