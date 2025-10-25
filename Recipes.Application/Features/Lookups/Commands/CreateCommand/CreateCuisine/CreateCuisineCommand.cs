using MediatR;
using Recipes.Application.Features.Lookups.Dto;

namespace Recipes.Application.Features.Lookups.Commands.CreateCommand.CreateCuisine;
public class CreateCuisineCommand(CreateCuisineDto Dto) : IRequest<int>
{
    public CreateCuisineDto Dto { get; } = Dto;
}
