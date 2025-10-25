using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Recipes.Domain.Abstractions;
using Recipes.Domain.Entities.Business.Social;
using Recipes.Domain.Exceptions;
using Recipes.Domain.Repositories.Business.Social;

namespace Recipes.Application.Posts.Commands.Create;
public class CreatePostCommandHandler
    (ILogger<CreatePostCommandHandler> logger, IUnitOfWork uow, IPostRepository posts,
    IMediaUnitRepository medias, ISocialDataRepository socials, IMapper mapper)
    : IRequestHandler<CreatePostCommand, int>
{
    public async Task<int> Handle(CreatePostCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating a new post");
        if (!await posts.DishExistsAsync(request.Dto.DishId, cancellationToken))
            throw new NotFoundException("Dish", request.Dto.DishId.ToString());

        await uow.BeginAsync(cancellationToken);

        try
        {
            var post = mapper.Map<Post>(request.Dto);
            var social = post.SocialData;
            var media = post.MediaUnit;

            await posts.AddAsync(post, cancellationToken);

            if (social != null) await socials.AddAsync(social, cancellationToken);
            if(media != null) await medias.AddAsync(media, cancellationToken);

            await uow.SaveChangesAsync(cancellationToken);
            await uow.CommitAsync(cancellationToken);

            return post.Id;
        }
        catch
        {
            await uow.RollbackAsync(cancellationToken);
            logger.LogError("Error occurred while creating a new post");
            throw;
        }
    }
}
