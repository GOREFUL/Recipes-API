namespace Recipes.Application.Planing.Dtos;
public class UpdatePlanDto
{
    public DateOnly Date { get; set; }
    public TimeSpan TimePoint { get; set; }
    public byte Yield { get; set; }
    public string? Note { get; set; }
}
