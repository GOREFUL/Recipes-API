using MediatR;

namespace Recipes.Application.Dish.Commands.DeleteDish;
public class DeleteDishCommand(int Id) : IRequest
{
    public int Id { get; } = Id;
}
