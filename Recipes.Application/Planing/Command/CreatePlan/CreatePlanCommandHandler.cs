using AutoMapper;
using MediatR;
using Recipes.Application.Planing.Dtos;
using Recipes.Domain.Abstractions;
using Recipes.Domain.Repositories.Business.Cooking;

namespace Recipes.Application.Planing.Command.CreatePlan;
public class CreatePlanCommandHandler(
    ICurrentUser current,
    IPlanRepository repo,
    IMapper mapper,
    IUnitOfWork uow
) : IRequestHandler<CreatePlanCommand, PlanDto>
{
    public async Task<PlanDto> Handle(CreatePlanCommand q, CancellationToken ct)
    {
        // (опційно) перевірка слотів
        if (await repo.ExistsSlotAsync(current.UserId!.Value, q.Dto.Date, q.Dto.TimePoint, ct))
            throw new InvalidOperationException("A plan already exists for the specified date and time point.");

        var entity = mapper.Map<Recipes.Domain.Entities.Business.Cooking.Plan>(q.Dto);
        entity.UserId = current.UserId!.Value;

        await repo.AddAsync(entity, ct);
        await uow.SaveChangesAsync(ct);

        var created = await repo.GetByIdWithDishAsync(entity.Id, current.UserId!.Value, ct)
                     ?? throw new InvalidOperationException("Plan not found after create.");
        return mapper.Map<PlanDto>(created);
    }
}
