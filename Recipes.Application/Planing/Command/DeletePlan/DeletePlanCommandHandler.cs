using MediatR;
using Recipes.Domain.Abstractions;
using Recipes.Domain.Exceptions;
using Recipes.Domain.Repositories.Business.Cooking;

namespace Recipes.Application.Planing.Command.DeletePlan;
public class DeletePlanCommandHandler(
    ICurrentUser current,
    IPlanRepository repo,
    IUnitOfWork uow
) : IRequestHandler<DeletePlanCommand>
{
    public async Task Handle(DeletePlanCommand q, CancellationToken ct)
    {
        var plan = await repo.GetByIdAsync(q.Id, current.UserId!.Value, ct)
                   ?? throw new NotFoundException("Plan", q.Id.ToString());

        await repo.DeleteAsync(plan, ct);
        await uow.SaveChangesAsync(ct);
    }
}
