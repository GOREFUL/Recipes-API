using MediatR;
using Recipes.Application.Features.Lookups.Dto;

namespace Recipes.Application.Features.Lookups.Commands.CreateCommand.CreateAllergy;
public class CreateAllergyCommand(CreateAllergyDto Dto) : IRequest<int>
{
    public CreateAllergyDto Dto { get; } = Dto;
}
