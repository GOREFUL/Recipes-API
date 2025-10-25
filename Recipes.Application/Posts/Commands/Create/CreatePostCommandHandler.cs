using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Recipes.Domain.Abstractions;
using Recipes.Domain.Entities.Business.Social;
using Recipes.Domain.Exceptions;
using Recipes.Domain.Repositories.Business.Social;

namespace Recipes.Application.Posts.Commands.Create;
public class CreatePostCommandHandler
    (ILogger<CreatePostCommandHandler> logger,
     IUnitOfWork uow,
     IPostRepository posts,
     IMediaUnitRepository medias,  
     ISocialDataRepository socials,
     ICurrentUser current)         
    : IRequestHandler<CreatePostCommand, int>
{
    public async Task<int> Handle(CreatePostCommand request, CancellationToken ct)
    {
        logger.LogInformation("Creating a new post");

        if (!current.UserId.HasValue)
            throw new UnauthorizedAccessException("User is not authenticated");

        if (!await posts.DishExistsAsync(request.Dto.DishId, ct))
            throw new NotFoundException("Dish", request.Dto.DishId.ToString());

        await uow.BeginAsync(ct);
        try
        {
            var post = new Post
            {
                Name = request.Dto.Name.Trim(),
                Description = request.Dto.Description?.Trim() ?? string.Empty,
                DishId = request.Dto.DishId,
                UserId = current.UserId.Value,
                SocialData = new SocialData(),
                MediaUnit = new MediaUnit { Url = request.Dto.Url.Trim() }
            };

            await posts.AddAsync(post, ct);
            await uow.SaveChangesAsync(ct);
            await uow.CommitAsync(ct);

            return post.Id;
        }
        catch
        {
            await uow.RollbackAsync(ct);
            logger.LogError("Error occurred while creating a new post");
            throw;
        }
    }
}