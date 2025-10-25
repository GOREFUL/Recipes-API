namespace Recipes.Application.Macronutrients.Dtos;
public class CreateMacronutrientsDto
{
    public short? Kcal { get; set; }
    public float? SaturatedFat { get; set; }
    public float? TransFat { get; set; }
    public float? Sugars { get; set; }
    public float? Fiber { get; set; }
    public float? Protein { get; set; }
    public float? Salt { get; set; }
}
