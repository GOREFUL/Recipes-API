using MediatR;
using Recipes.Application.Posts.Dtos;
using Recipes.Domain.Exceptions;
using Recipes.Domain.Repositories.Business.Social;

namespace Recipes.Application.Posts.Queries.GetPostById;
public sealed class GetPostByIdQueryHandler
    (IPostRepository posts)
    : IRequestHandler<GetPostByIdQuery, PostDetailsDto>
{
    public async Task<PostDetailsDto> Handle(GetPostByIdQuery r, CancellationToken token)
    {
        var p = await posts.GetByIdWithAllAsync(r.Id, token);
        if (p is null)
            throw new NotFoundException("Post", r.Id.ToString());

        return new PostDetailsDto
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
        };
    }
}