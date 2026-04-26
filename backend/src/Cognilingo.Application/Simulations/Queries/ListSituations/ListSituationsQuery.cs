namespace Cognilingo.Application.Simulations.Queries.ListSituations;

public sealed record ListSituationsQuery(
    Guid CategoryId,
    string LanguageCode
) : IRequest<Response<IEnumerable<ListSituationDto>>>;