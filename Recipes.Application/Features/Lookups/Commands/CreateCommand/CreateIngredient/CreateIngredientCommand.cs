using MediatR;
using Recipes.Application.Features.Lookups.Dto;

namespace Recipes.Application.Features.Lookups.Commands.CreateCommand.CreateIngredient;
public class CreateIngredientCommand(CreateIngredientDto Dto) : IRequest<int>
{
    public CreateIngredientDto dto { get; } = Dto;
}
