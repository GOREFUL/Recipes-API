using MediatR;
using Recipes.Application.Planing.Dtos;

namespace Recipes.Application.Planing.Queries.GetPlanByIdWithDish;
public class GetPlanByIdWithDishQuery(long Id) : IRequest<PlanDto>
{
    public long Id { get; } = Id;
}
