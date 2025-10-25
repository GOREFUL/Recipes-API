namespace Recipes.Application.IngredientUnit.Dtos;
public class CreateIngredientUnitDto
{
    public int IngredientId { get; set; }
    public int MeasureUnitId { get; set; }
    public float Value { get; set; }
}
