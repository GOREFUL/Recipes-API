using MediatR;
using Microsoft.Extensions.Logging;
using Recipes.Application.Posts.Dtos;
using Recipes.Domain.Abstractions;
using Recipes.Domain.Repositories.Business.Social;

namespace Recipes.Application.Posts.Commands.UpdateLikes;
public sealed class UpdateLikesCommandHandler
    (ILogger<UpdateLikesCommandHandler> logger,
     IUnitOfWork uow,
     ISocialDataRepository socialRepo)
    : IRequestHandler<UpdateLikesCommand, SocialDataDto>
{
    public async Task<SocialDataDto> Handle(UpdateLikesCommand r, CancellationToken ct)
    {
        var sd = await socialRepo.GetByPostIdAsync(r.PostId, ct)
                 ?? throw new KeyNotFoundException($"SocialData for post {r.PostId} not found");

        var newLikes = sd.Likes + r.Delta;
        if (newLikes < 0) newLikes = 0;
        sd.Likes = newLikes;

        await uow.BeginAsync(ct);
        try
        {
            await socialRepo.UpdateAsync(sd, ct);
            await uow.SaveChangesAsync(ct);
            await uow.CommitAsync(ct);
            logger.LogInformation("Updated Likes for Post {PostId} by {Delta} -> {Likes}", r.PostId, r.Delta, sd.Likes);
            return new SocialDataDto(sd.Likes, sd.Dislikes);
        }
        catch
        {
            await uow.RollbackAsync(ct);
            throw;
        }
    }
}
