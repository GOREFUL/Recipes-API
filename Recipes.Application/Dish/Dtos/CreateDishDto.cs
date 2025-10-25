using Recipes.Application.DishInfo.Dtos;
using Recipes.Application.Images.Dtos;
using Recipes.Application.IngredientUnit.Dtos;
using Recipes.Application.Users.Dtos;

namespace Recipes.Application.Dish.Dtos;
public class CreateDishDto
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public CreateDishInfoDto Info { get; set; } = default!;
    public List<CreateIngredientUnitDto> Ingredients { get; set; } = new();
    public List<CreateImageDto> ImageUrls { get; set; } = new();
    public List<int> AllergyIds { get; set; } = new();
    public List<int> CuisineIds { get; set; } = new();
}
