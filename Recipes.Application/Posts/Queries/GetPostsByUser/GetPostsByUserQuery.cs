using MediatR;
using Recipes.Application.Posts.Dtos;

namespace Recipes.Application.Posts.Queries.GetPostsByUser;
public class GetPostsByUserQuery(Guid UserId, int Page = 1, int PageSize = 20)
    : IRequest<IReadOnlyList<PostDetailsDto>>
{
    public Guid UserId { get; } = UserId;
    public int Page { get; } = Page;
    public int PageSize { get; } = PageSize;
}
