namespace Recipes.Application.Features.Lookups.Dto.Lookup;
public class LookupItemDto 
{ 
    public int Id { get; set; } 
    public string Name { get; set; } = string.Empty; 
}
public record Paged<T>(IReadOnlyList<T> Items, int Total, int Page, int PageSize);
