using MediatR;
using Recipes.Application.Planing.Dtos;

namespace Recipes.Application.Planing.Queries.GetPlanById;
public class GetPlanByIdQuery(long Id) : IRequest<PlanListItemDto>
{
    public long Id { get; } = Id;
}
