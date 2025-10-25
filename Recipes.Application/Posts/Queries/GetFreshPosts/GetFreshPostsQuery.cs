using MediatR;
using Recipes.Application.Posts.Dtos;

namespace Recipes.Application.Posts.Queries.GetFreshPosts;
public class GetFreshPostsQuery(DateTime? SinceUtc = null, int Page = 1, int PageSize = 20) : IRequest<IReadOnlyList<PostDetailsDto>>
{
    public DateTime SinceUtc { get; } = SinceUtc ?? DateTime.UtcNow.AddDays(-7);
    public int Page { get; } = Page;
    public int PageSize { get; } = PageSize;
}
