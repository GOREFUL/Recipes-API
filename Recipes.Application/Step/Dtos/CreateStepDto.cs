namespace Recipes.Application.Step.Dtos;
public class CreateStepDto
{
    public byte Number { get; set; }
    public string ShortDescription { get; set; } = default!;
    public string FullDescription { get; set; } = default!;
}
