using AutoMapper;
using MediatR;
using Recipes.Application.Planing.Dtos;
using Recipes.Domain.Abstractions;
using Recipes.Domain.Repositories.Business.Cooking;

namespace Recipes.Application.Planing.Queries.GetPlansRange;
public class GetPlansRangeQueryHandler(
    ICurrentUser current,
    IPlanRepository repo,
    IMapper mapper
) : IRequestHandler<GetPlansRangeQuery, IReadOnlyList<PlanListItemDto>>
{
    public async Task<IReadOnlyList<PlanListItemDto>> Handle(GetPlansRangeQuery q, CancellationToken ct)
    {
        var items = await repo.GetRangeAsync(current.UserId!.Value, q.From, q.To, ct);
        return items.Select(mapper.Map<PlanListItemDto>).ToList();
    }
}