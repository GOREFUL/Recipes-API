using MediatR;
using Recipes.Domain.Abstractions;
using Recipes.Domain.Repositories.Business.Cooking;

namespace Recipes.Application.Dish.Commands.DeleteDish;
public sealed class DeleteDishCommandHandler
    (ICurrentUser current, IUnitOfWork uow, IDishRepository repo)
    : IRequestHandler<DeleteDishCommand>
{
    public async Task Handle(DeleteDishCommand r, CancellationToken ct)
    {
        if (!current.UserId.HasValue) throw new UnauthorizedAccessException();

        var dish = await repo.GetByIdAsync(r.Id, ct);
        if (dish is null) throw new KeyNotFoundException($"Dish {r.Id} not found");
        if (dish.CookId != current.UserId.Value)
            throw new UnauthorizedAccessException("You cannot delete others' dishes");

        await uow.BeginAsync(ct);
        try
        {
            await repo.DeleteAsync(dish, ct);
            await uow.SaveChangesAsync(ct);
            await uow.CommitAsync(ct);
        }
        catch
        {
            await uow.RollbackAsync(ct);
            throw;
        }
    }
}
