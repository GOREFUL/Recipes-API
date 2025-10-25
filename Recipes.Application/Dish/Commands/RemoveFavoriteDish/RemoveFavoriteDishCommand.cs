using MediatR;

namespace Recipes.Application.Dish.Commands.RemoveFavoriteDish;
public class RemoveFavoriteDishCommand(int DishId) : IRequest
{
    public int DishId { get; } = DishId;
}
