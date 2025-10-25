using AutoMapper;
using MediatR;
using Recipes.Application.Planing.Dtos;
using Recipes.Domain.Abstractions;
using Recipes.Domain.Exceptions;
using Recipes.Domain.Repositories.Business.Cooking;

namespace Recipes.Application.Planing.Queries.GetPlanById;
public class GetPlanByIdQueryHandler(
    ICurrentUser current,
    IPlanRepository repo,
    IMapper mapper
) : IRequestHandler<GetPlanByIdQuery, PlanListItemDto>
{
    public async Task<PlanListItemDto> Handle(GetPlanByIdQuery q, CancellationToken ct)
    {
        var plan = await repo.GetByIdWithDishAsync(q.Id, current.UserId!.Value, ct)
                   ?? throw new NotFoundException("Plan", q.Id.ToString());

        return mapper.Map<PlanListItemDto>(plan);
    }
}