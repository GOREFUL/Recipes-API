using MediatR;
using Recipes.Domain.Abstractions;
using Recipes.Domain.Exceptions;
using Recipes.Domain.Repositories.Business.Cooking;

namespace Recipes.Application.Planing.Command.UpdatePlan;
public class UpdatePlanCommandHandler(
    ICurrentUser current,
    IPlanRepository repo,
    IUnitOfWork uow
) : IRequestHandler<UpdatePlanCommand>
{
    public async Task Handle(UpdatePlanCommand q, CancellationToken ct)
    {
        var plan = await repo.GetByIdAsync(q.Id, current.UserId!.Value, ct)
                   ?? throw new NotFoundException("Plan", "Plan not found.");

        if ((plan.Date != q.Dto.Date || plan.TimePoint != q.Dto.TimePoint) &&
            await repo.ExistsSlotAsync(current.UserId!.Value, q.Dto.Date, q.Dto.TimePoint, ct))
        {
            throw new InvalidOperationException("A plan already exists for the specified date and time point.");
        }

        plan.Date = q.Dto.Date;
        plan.TimePoint = q.Dto.TimePoint;
        plan.Yield = q.Dto.Yield;
        plan.Note = q.Dto.Note;

        await repo.UpdateAsync(plan, ct);
        await uow.SaveChangesAsync(ct);
    }
}
