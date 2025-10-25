namespace Recipes.Application.Planing.Dtos;
public class PlanDto(long Id, Guid UserId, int DishId, DateOnly Date, TimeSpan TimePoint, byte Yield,
    string? Note, string DishName)
{
    public long Id { get; } = Id;
    public Guid UserId { get; } = UserId;
    public int DishId { get; } = DishId;
    public DateOnly Date { get; } = Date;
    public TimeSpan TimePoint { get; } = TimePoint;
    public byte Yield { get; } = Yield;
    public string? Note { get; } = Note;
    public string DishName { get; } = DishName;

}
