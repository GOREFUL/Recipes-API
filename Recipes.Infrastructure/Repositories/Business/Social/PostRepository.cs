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
}
