using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Recipes.Application.Posts.Commands.Create;
using Recipes.Application.Posts.Commands.UpdateDislikes;
using Recipes.Application.Posts.Commands.UpdateLikes;
using Recipes.Application.Posts.Dtos;
using Recipes.Application.Posts.Queries.GetFreshPosts;
using Recipes.Application.Posts.Queries.GetPostById;
using Recipes.Application.Posts.Queries.GetPostsByUser;

namespace Recipes.API.Controllers;

[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
[ApiController]
[Route("api/[controller]")]
public class PostsController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
    public async Task<IActionResult> Create([FromBody] CreatePostDto dto, CancellationToken token)
    {
        var id = await mediator.Send(new CreatePostCommand(dto), token);
        return CreatedAtAction(nameof(Create), new { id }, id);
    }

    [HttpGet("by-user/{userId:guid}")]
    [ProducesResponseType(typeof(IReadOnlyList<PostDetailsDto>), StatusCodes.Status200OK)]
    public Task<IReadOnlyList<PostDetailsDto>> ByUser(Guid userId, [FromQuery] int page = 1, [FromQuery] int pageSize = 20,
        CancellationToken token = default)
        => mediator.Send(new GetPostsByUserQuery(userId, page, pageSize), token);

    [HttpGet("fresh")]
    [ProducesResponseType(typeof(IReadOnlyList<PostDetailsDto>), StatusCodes.Status200OK)]
    public Task<IReadOnlyList<PostDetailsDto>> Fresh([FromQuery] DateTime? sinceUtc, [FromQuery] int page = 1,
        [FromQuery] int pageSize = 20, CancellationToken token = default)
        => mediator.Send(new GetFreshPostsQuery(sinceUtc, page, pageSize), token);

    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(PostDetailsDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public Task<PostDetailsDto> GetById(int id, CancellationToken token)
        => mediator.Send(new GetPostByIdQuery(id), token);

    [HttpPut("{postId:int}/likes")]
    [ProducesResponseType(typeof(SocialDataDto), StatusCodes.Status200OK)]
    public Task<SocialDataDto> UpdateLikes(int postId, [FromQuery] int delta = 1, CancellationToken token = default)
        => mediator.Send(new UpdateLikesCommand(postId, delta), token);

    [HttpPut("{postId:int}/dislikes")]
    [ProducesResponseType(typeof(SocialDataDto), StatusCodes.Status200OK)]
    public Task<SocialDataDto> UpdateDislikes(int postId, [FromQuery] int delta = 1, CancellationToken token = default)
        => mediator.Send(new UpdateDislikesCommand(postId, delta), token);
}
