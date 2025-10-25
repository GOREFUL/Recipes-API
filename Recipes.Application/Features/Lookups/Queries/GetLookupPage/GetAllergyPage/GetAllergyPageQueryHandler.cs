using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Recipes.Application.Features.Lookups.Dto.Lookup;
using Recipes.Application.Features.Lookups.Queries.GetLookupPage.GetIngredientsPage;
using Recipes.Domain.Repositories.Business.Enumerations;

namespace Recipes.Application.Features.Lookups.Queries.GetLookupPage.GetAllergyPage;
public class GetAllergyPageQueryHandler
    (ILogger<GetAllergyPageQueryHandler> logger, IAllergyRepository repo, IMapper mapper)
    : IRequestHandler<GetAllergyPageQuery, Paged<LookupItemDto>>
{
    public async Task<Paged<LookupItemDto>> Handle(GetAllergyPageQuery r, CancellationToken ct)
    {
        logger.LogInformation("Getting allergies page {Page} with page size {PageSize} " +
            "and search query {Q}", r.Page, r.PageSize, r.Q ?? "null");
        var (items, total) = await repo.GetPageAsync(r.Q, r.Page, r.PageSize, ct);
        return new Paged<LookupItemDto>(mapper
            .Map<IReadOnlyList<LookupItemDto>>(items), total, r.Page, r.PageSize);
    }
}
