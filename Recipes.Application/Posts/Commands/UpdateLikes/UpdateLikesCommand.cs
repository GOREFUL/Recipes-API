using MediatR;
using Recipes.Application.Posts.Dtos;

namespace Recipes.Application.Posts.Commands.UpdateLikes;
public class UpdateLikesCommand(int PostId, int Delta) : IRequest<SocialDataDto>
{
    public int PostId { get; } = PostId;
    public int Delta { get; } = Delta;
}
