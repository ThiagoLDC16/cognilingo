namespace Cognilingo.Application.Simulations.Queries.ListSituationVariants;

public sealed class ListSituationVariantsQueryHandler(
    IAppDbContext context
) : IRequestHandler<ListSituationVariantsQuery, Response<IEnumerable<ListSituationVariantDto>>>
{
    public async Task<Response<IEnumerable<ListSituationVariantDto>>> Handle(
        ListSituationVariantsQuery request,
        CancellationToken cancellationToken
    )
    {
        var languageCode = request.LanguageCode;

        var variants = await context.SituationVariants
            .AsNoTracking()
            .Where(v => v.SituationId == request.SituationId)
            .Select(v => new ListSituationVariantDto
            {
                Id = v.Id,
                Name = v.Translations
                    .Where(t => t.LanguageCode == languageCode)
                    .Select(t => t.Name)
                    .FirstOrDefault()!,
                UserContext = v.Translations
                    .Where(t => t.LanguageCode == languageCode)
                    .Select(t => t.UserContext)
                    .FirstOrDefault()!,
                LanguageCode = languageCode,
                Objectives = v.Objectives
                    .SelectMany(o => o.Translations)
                    .Where(t => t.LanguageCode == languageCode)
                    .Select(t => t.Name)
            })
            .ToListAsync(cancellationToken);

        return new OkResponse<IEnumerable<ListSituationVariantDto>>(variants);
    }
}