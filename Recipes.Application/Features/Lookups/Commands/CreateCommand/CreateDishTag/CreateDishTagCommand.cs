using MediatR;
using Recipes.Application.Features.Lookups.Dto;

namespace Recipes.Application.Features.Lookups.Commands.CreateCommand.CreateDishTag;
public class CreateDishTagCommand(CreateDishTagDto Dto) : IRequest<int>
{
    public CreateDishTagDto Dto { get; } = Dto;
}
