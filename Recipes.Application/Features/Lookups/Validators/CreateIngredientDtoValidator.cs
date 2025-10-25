using FluentValidation;
using Recipes.Application.Features.Lookups.Dto.CreateDtos;

namespace Recipes.Application.Features.Lookups.Validators;
public class CreateIngredientDtoValidator : AbstractValidator<CreateIngredientDto>
{
    public CreateIngredientDtoValidator() => RuleFor(x => x.Name).NotEmpty().MaximumLength(128);
}
