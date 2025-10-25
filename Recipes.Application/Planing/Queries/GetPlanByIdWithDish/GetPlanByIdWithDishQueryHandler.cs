using AutoMapper;
using MediatR;
using Recipes.Application.Planing.Dtos;
using Recipes.Domain.Abstractions;
using Recipes.Domain.Exceptions;
using Recipes.Domain.Repositories.Business.Cooking;

namespace Recipes.Application.Planing.Queries.GetPlanByIdWithDish;
public class GetPlanByIdWithDishQueryHandler(
    ICurrentUser current,
    IPlanRepository repo,
    IMapper mapper
) : IRequestHandler<GetPlanByIdWithDishQuery, PlanDto>
{
    public async Task<PlanDto> Handle(GetPlanByIdWithDishQuery q, CancellationToken ct)
    {
        var plan = await repo.GetByIdWithDishAsync(q.Id, current.UserId!.Value, ct)
                   ?? throw new NotFoundException("Plan", q.Id.ToString());
        return mapper.Map<PlanDto>(plan);
    }
}