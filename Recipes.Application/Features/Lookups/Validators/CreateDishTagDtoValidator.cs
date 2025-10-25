using FluentValidation;
using Recipes.Application.Features.Lookups.Dto;

namespace Recipes.Application.Features.Lookups.Validators;
public class CreateDishTagDtoValidator : AbstractValidator<CreateDishTagDto>
{
    public CreateDishTagDtoValidator() => RuleFor(x => x.Name).NotEmpty().MaximumLength(64);
}
