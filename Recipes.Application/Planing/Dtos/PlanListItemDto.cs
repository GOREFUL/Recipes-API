namespace Recipes.Application.Planing.Dtos;
public class PlanListItemDto(long Id, int DishId, string DishName, DateOnly Date, TimeSpan TimePoint, byte Yield)
{
    public long Id { get; } = Id;
    public int DishId { get; } = DishId;
    public string DishName { get; } = DishName;
    public DateOnly Date { get; } = Date;
    public TimeSpan TimePoint { get; } = TimePoint;
    public byte Yield { get; } = Yield;
}
