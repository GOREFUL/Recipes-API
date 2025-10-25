namespace Recipes.Domain.Abstractions;

public interface IUnitOfWork
{
    Task BeginAsync(CancellationToken token);
    Task CommitAsync(CancellationToken token);
    Task RollbackAsync(CancellationToken token);
    Task<int> SaveChangesAsync(CancellationToken token);
}
