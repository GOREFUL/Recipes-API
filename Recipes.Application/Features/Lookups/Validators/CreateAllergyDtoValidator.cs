using FluentValidation;
using Recipes.Application.Features.Lookups.Dto.CreateDtos;

namespace Recipes.Application.Features.Lookups.Validators;
public class CreateAllergyDtoValidator : AbstractValidator<CreateAllergyDto>
{
    public CreateAllergyDtoValidator() => RuleFor(x => x.Name).NotEmpty().MaximumLength(64);
}
