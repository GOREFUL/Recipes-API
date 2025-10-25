using Recipes.Domain.Entities.Business.Cooking.Advanced;
using Recipes.Domain.Entities.Business.Enumerations;
using System.Reflection.Emit;

namespace Recipes.Domain.Entities.Business.Cooking;
public class DishInfo
{
    public int Id { get; set; }

    #region attributes
    public TimeSpan Time { get; set; }
    public byte Yield { get; set; }
    public short ServingSize { get; set; }
    public string Note { get; set; } = string.Empty;
    #endregion

    #region foreign keys
    public int DishId { get; set; }
    public int LevelId { get; set; }
    #endregion

    #region one-to-one
    public Dish Dish { get; set; } = null!;
    public Macronutrients Macronutrients { get; set; } = null!;
    public Micronutrients Micronutrients { get; set; } = null!;
    #endregion

    #region many-to-one
    public Level Level { get; set; } = null!;
    #endregion

    #region one-to-many
    public ICollection<Image> Images { get; set; }
        = new List<Image>();
    public ICollection<IngredientUnit> IngredientUnits { get; set; }
        = new List<IngredientUnit>();
    public ICollection<Allergy> Allergies { get; set; }
    = new List<Allergy>();
    public ICollection<Cuisine> Cuisines { get; set; }
        = new List<Cuisine>();

    #endregion

}
