namespace Recipes.Domain.Abstractions;

public interface ICurrentUser
{
    Guid? UserId { get; }
    bool IsInRole(string role);
}
