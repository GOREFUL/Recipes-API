using FluentValidation;
using Recipes.Application.Features.Lookups.Dto;

namespace Recipes.Application.Features.Lookups.Validators;
public class CreateMeasureUnitDtoValidator : AbstractValidator<CreateMeasureUnitDto>
{
    public CreateMeasureUnitDtoValidator() => RuleFor(x => x.Name).NotEmpty().MaximumLength(64);
}
