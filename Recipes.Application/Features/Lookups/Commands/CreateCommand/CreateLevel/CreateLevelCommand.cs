using MediatR;
using Recipes.Application.Features.Lookups.Dto.CreateDtos;

namespace Recipes.Application.Features.Lookups.Commands.CreateCommand.CreateLevel;
public class CreateLevelCommand(CreateLevelDto Dto) : IRequest<int>
{
    public CreateLevelDto Dto { get; } = Dto;
}
