using MediatR;
using Recipes.Application.Planing.Dtos;

namespace Recipes.Application.Planing.Command.CreatePlan;
public class CreatePlanCommand(CreatePlanDto Dto) : IRequest<PlanDto>
{
    public CreatePlanDto Dto { get; } = Dto;
}
