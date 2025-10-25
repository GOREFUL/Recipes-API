using MediatR;
using Recipes.Application.Planing.Dtos;

namespace Recipes.Application.Planing.Command.UpdatePlan;
public class UpdatePlanCommand(long Id, UpdatePlanDto Dto) : IRequest
{
    public long Id { get; } = Id;
    public UpdatePlanDto Dto { get; } = Dto;
}
