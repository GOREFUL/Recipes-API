using MediatR;
using Microsoft.Extensions.Logging;
using Recipes.Application.Posts.Dtos;
using Recipes.Domain.Abstractions;
using Recipes.Domain.Repositories.Business.Social;

namespace Recipes.Application.Posts.Commands.UpdateDislikes;
public sealed class UpdateDislikesCommandHandler
    (ILogger<UpdateDislikesCommandHandler> logger,
     IUnitOfWork uow,
     ISocialDataRepository socialRepo)
    : IRequestHandler<UpdateDislikesCommand, SocialDataDto>
{
    public async Task<SocialDataDto> Handle(UpdateDislikesCommand r, CancellationToken ct)
    {
        var sd = await socialRepo.GetByPostIdAsync(r.PostId, ct)
                 ?? throw new KeyNotFoundException($"SocialData for post {r.PostId} not found");

        var newDislikes = sd.Dislikes + r.Delta;
        if (newDislikes < 0) newDislikes = 0;
        sd.Dislikes = newDislikes;

        await uow.BeginAsync(ct);
        try
        {
            await socialRepo.UpdateAsync(sd, ct);
            await uow.SaveChangesAsync(ct);
            await uow.CommitAsync(ct);
            logger.LogInformation("Updated Dislikes for Post {PostId} by {Delta} -> {Dislikes}", r.PostId, r.Delta, sd.Dislikes);
            return new SocialDataDto(sd.Likes, sd.Dislikes);
        }
        catch
        {
            await uow.RollbackAsync(ct);
            throw;
        }
    }
}