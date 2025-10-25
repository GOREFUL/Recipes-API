using MediatR;
using Microsoft.Extensions.Logging;
using Recipes.Application.Posts.Dtos;
using Recipes.Domain.Repositories.Business.Social;

namespace Recipes.Application.Posts.Queries.GetPostsByUser;
public class GetPostsByUserQueryHandler
    (ILogger<GetPostsByUserQueryHandler> logger, IPostRepository posts)
    : IRequestHandler<GetPostsByUserQuery, IReadOnlyList<PostDetailsDto>>
{
    public async Task<IReadOnlyList<PostDetailsDto>> Handle(GetPostsByUserQuery r, CancellationToken token)
    {
        logger.LogInformation("Get posts by user {UserId}, page {Page}/{PageSize}", r.UserId, r.Page, r.PageSize);
        var items = await posts.GetByUserWithAllAsync(r.UserId, r.Page, r.PageSize, token);

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
