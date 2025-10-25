namespace Recipes.Application.Planing.Dtos;
public class CreatePlanDto
{
    public int DishId { get; set; }
    public DateOnly Date { get; set; }
    public TimeSpan TimePoint { get; set; }
    public byte Yield { get; set; } = 1;
    public string? Note { get; set; }
}
