using MediatR;
using Recipes.Application.Dish.Commands.AddFavoriteDish;
using Recipes.Domain.Abstractions;
using Recipes.Domain.Repositories.Business.Cooking;

namespace Recipes.Application.Dish.Commands.RemoveFavoriteDish;
public class RemoveFavoriteDishCommandHandler
    (ICurrentUser current, IUnitOfWork uow, IDishRepository repo)
    : IRequestHandler<RemoveFavoriteDishCommand>
{
    public Task Handle(RemoveFavoriteDishCommand request, CancellationToken cancellationToken)
    {
        if (!current.UserId.HasValue)
            throw new UnauthorizedAccessException("User is not authenticated");
        return repo.RemoveFavoriteAsync(current.UserId.Value, request.DishId, cancellationToken);
    }
}
