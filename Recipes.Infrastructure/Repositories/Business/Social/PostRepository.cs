using Microsoft.EntityFrameworkCore;
using Recipes.Domain.Entities.Business.Social;
using Recipes.Domain.Repositories.Business.Social;
using Recipes.Infrastructure.Persistance;

namespace Recipes.Infrastructure.Repositories.Business.Social;
public class PostRepository : EfRepositoryBase<Post>, IPostRepository
{
    public PostRepository(RecipesDbContext db) : base(db) { }
    public async Task AddAsync(Post post, CancellationToken token)
        => await Set.AddAsync(post, token);

    public Task<bool> DishExistsAsync(int dishId, CancellationToken token)
        => Db.Dishes.AnyAsync(d => d.Id == dishId, token);

    public Task<Post?> GetByIdAsync(int id, CancellationToken token)
        => Set.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id, token);

    public async Task<Post?> GetByIdWithAllAsync(int id, CancellationToken token)
    => await Set.AsNoTracking()
          .Include(p => p.SocialData)
          .Include(p => p.MediaUnit)
          .AsSplitQuery()
          .FirstOrDefaultAsync(p => p.Id == id, token);

    public async Task<IReadOnlyList<Post>> GetByUserWithAllAsync(Guid userId, int page, int pageSize, CancellationToken token)
        => await Set.AsNoTracking()
              .Where(p => p.UserId == userId)
              .OrderByDescending(p => p.CreatedAt)
              .Include(p => p.SocialData)
              .Include(p => p.MediaUnit)
              .AsSplitQuery()
              .Skip((page - 1) * pageSize)
              .Take(pageSize)
              .ToListAsync(token);

    public async Task<IReadOnlyList<Post>> GetFreshWithAllAsync(DateTime sinceUtc, int page, int pageSize, CancellationToken token)
        => await Set.AsNoTracking()
              .Where(p => p.CreatedAt >= sinceUtc)
              .OrderByDescending(p => p.CreatedAt)
              .Include(p => p.SocialData)
              .Include(p => p.MediaUnit)
              .AsSplitQuery()
              .Skip((page - 1) * pageSize)
              .Take(pageSize)
              .ToListAsync(token);
}
