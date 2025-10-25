using MediatR;
using Recipes.Domain.Abstractions;
using Recipes.Domain.Repositories.Business.Cooking;

namespace Recipes.Application.Dish.Commands.AddFavoriteDish;
public sealed class AddFavoriteDishCommandHandler
    (ICurrentUser current, IUnitOfWork uow, IDishRepository repo)
    : IRequestHandler<AddFavoriteDishCommand>
{
    public async Task Handle(AddFavoriteDishCommand r, CancellationToken token)
    {
        if (!current.UserId.HasValue) throw new UnauthorizedAccessException();

        var dish = await repo.GetByIdAsync(r.DishId, token);
        if (dish is null) throw new KeyNotFoundException($"Dish {r.DishId} not found");

        await uow.BeginAsync(token);
        try
        {
            await repo.AddFavoriteAsync(current.UserId.Value, dish.Id, token);
            await uow.SaveChangesAsync(token);
            await uow.CommitAsync(token);
        }
        catch
        {
            await uow.RollbackAsync(token);
            throw;
        }
    }
}
