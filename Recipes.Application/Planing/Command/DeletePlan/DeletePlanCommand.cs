using MediatR;

namespace Recipes.Application.Planing.Command.DeletePlan;
public class DeletePlanCommand(long Id) : IRequest
{
    public long Id { get; set; } = Id;
}
