using Microsoft.EntityFrameworkCore;
using Recipes.Infrastructure.Persistance;

namespace Recipes.Infrastructure.Repositories;
public abstract class EfRepositoryBase<TEntity> where TEntity : class
{
    protected readonly RecipesDbContext Db;
    protected EfRepositoryBase(RecipesDbContext db) => Db = db;
    protected DbSet<TEntity> Set => Db.Set<TEntity>();
}
