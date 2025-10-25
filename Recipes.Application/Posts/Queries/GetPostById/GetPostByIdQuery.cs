using MediatR;
using Recipes.Application.Posts.Dtos;

namespace Recipes.Application.Posts.Queries.GetPostById;
public class GetPostByIdQuery(int id) : IRequest<PostDetailsDto>
{
    public int Id { get; } = id;
}
