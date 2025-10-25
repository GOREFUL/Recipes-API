using Microsoft.EntityFrameworkCore.Storage;
using Recipes.Domain.Abstractions;
using Recipes.Infrastructure.Persistance;

namespace Recipes.Infrastructure.UnitOfWork;
public class EfUnitOfWork : IUnitOfWork, IAsyncDisposable
{
    private readonly RecipesDbContext db;
    private IDbContextTransaction? tx;

    public EfUnitOfWork(RecipesDbContext _db)
    {
        db = _db ?? throw new ArgumentNullException(nameof(_db));
        tx = null;
    }

    public async Task BeginAsync(CancellationToken token)
    {
        if (tx is not null)
            return;
        tx = await db.Database.BeginTransactionAsync(token);
    }

    public async Task CommitAsync(CancellationToken token)
    {
        if (tx is null)
            return;
        await tx.CommitAsync(token);
        await tx.DisposeAsync();
        tx = null;
    }

    public async ValueTask DisposeAsync()
    {
        if (tx is not null)
            await tx.DisposeAsync();
    }

    public async Task RollbackAsync(CancellationToken token)
    {
        if (tx is null)
            return;
        await tx.RollbackAsync(token);
        await tx.DisposeAsync();
        tx = null;
    }

    public async Task<int> SaveChangesAsync(CancellationToken token)
        => await db.SaveChangesAsync(token);
}
