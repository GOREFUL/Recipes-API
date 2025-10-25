using MediatR;
using Recipes.Application.Planing.Dtos;

namespace Recipes.Application.Planing.Queries.GetPlansRange;
public class GetPlansRangeQuery(DateOnly From, DateOnly To) : IRequest<IReadOnlyList<PlanListItemDto>>
{
    public DateOnly From { get; } = From;
    public DateOnly To { get; } = To;
}
