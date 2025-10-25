using MediatR;
using Recipes.Application.Posts.Dtos;

namespace Recipes.Application.Posts.Commands.Create;
public class CreatePostCommand(CreatePostDto dto) : IRequest<int>
{
    public CreatePostDto Dto { get; } = dto;
}
