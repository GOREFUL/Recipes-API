using MediatR;
using Recipes.Application.Features.Lookups.Dto.CreateDtos;

namespace Recipes.Application.Features.Lookups.Commands.CreateCommand.CreateMeasureUnit;
public class CreateMeasureUnitCommand(CreateMeasureUnitDto Dto) : IRequest<int>
{
    public CreateMeasureUnitDto dto { get; } = Dto;
}
