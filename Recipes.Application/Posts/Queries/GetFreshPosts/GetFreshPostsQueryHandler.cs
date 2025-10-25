using MediatR;
using Microsoft.Extensions.Logging;
using Recipes.Application.Posts.Dtos;
using Recipes.Domain.Repositories.Business.Social;

namespace Recipes.Application.Posts.Queries.GetFreshPosts;
public class GetFreshPostsQueryHandler
    (ILogger<GetFreshPostsQueryHandler> logger, IPostRepository posts)
    : IRequestHandler<GetFreshPostsQuery, IReadOnlyList<PostDetailsDto>>
{
    public async Task<IReadOnlyList<PostDetailsDto>> Handle(GetFreshPostsQuery r, CancellationToken ct)
    {
        var since = r.SinceUtc is DateTime s && s != default
            ? s : DateTime.UtcNow.AddDays(-7);

        logger.LogInformation("Get fresh posts since {SinceUtc}, page {Page}/{PageSize}", since, r.Page, r.PageSize);

        var items = await posts.GetFreshWithAllAsync(since, r.Page, r.PageSize, ct);

        return items.Select(p => new PostDetailsDto
        {
            Id = p.Id,
            UserId = p.UserId,
            DishId = p.DishId,
            Name = p.Name,
            Description = p.Description,
            CreatedAt = p.CreatedAt,
            MediaUrl = p.MediaUnit?.Url,
            Likes = p.SocialData?.Likes ?? 0,
            Dislikes = p.SocialData?.Dislikes ?? 0
        }).ToList();
    }
}
