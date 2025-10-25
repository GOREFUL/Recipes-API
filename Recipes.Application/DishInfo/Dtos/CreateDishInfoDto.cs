using Recipes.Application.Macronutrients.Dtos;
using Recipes.Application.Micronutrients.Dtos;

namespace Recipes.Application.DishInfo.Dtos;
public class CreateDishInfoDto
{
    public int LevelId { get; set; }
    public TimeSpan Time { get; set; }
    public byte Yield { get; set; }
    public short ServingSize { get; set; }
    public string? Note { get; set; }
    public CreateMacronutrientsDto? Macros { get; set; }
    public CreateMicronutrientsDto? Micros { get; set; }
}
