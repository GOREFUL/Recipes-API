using MediatR;

namespace Recipes.Application.Dish.Commands.AddFavoriteDish;
public class AddFavoriteDishCommand(int DishId) : IRequest
{
    public int DishId { get; } = DishId;
}
