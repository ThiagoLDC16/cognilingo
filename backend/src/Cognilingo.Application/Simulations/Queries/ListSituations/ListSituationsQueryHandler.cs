namespace Cognilingo.Application.Simulations.Queries.ListSituations;

public sealed class ListSituationsQueryHandler(
    IAppDbContext context
) : IRequestHandler<ListSituationsQuery, Response<IEnumerable<ListSituationDto>>>
{
    public async Task<Response<IEnumerable<ListSituationDto>>> Handle(
        ListSituationsQuery request,
        CancellationToken cancellationToken
    )
    {
        var languageCode = request.LanguageCode;

        var situations = await context.Situations
            .AsNoTracking()
            .Where(s => s.CategoryId == request.CategoryId)
            .Select(s => new ListSituationDto
            {
                Id = s.Id,
                Name = s.Translations
                    .Where(t => t.LanguageCode == languageCode)
                    .Select(t => t.Name)
                    .FirstOrDefault()!,
                Description = s.Translations
                    .Where(t => t.LanguageCode == languageCode)
                    .Select(t => t.Description)
                    .FirstOrDefault()!,
                LanguageCode = languageCode
            })
            .ToListAsync(cancellationToken: cancellationToken);

        return new OkResponse<IEnumerable<ListSituationDto>>(situations);
    }
}