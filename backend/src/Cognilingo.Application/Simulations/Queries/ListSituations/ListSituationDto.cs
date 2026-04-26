namespace Cognilingo.Application.Simulations.Queries.ListSituations;

public sealed record ListSituationDto
{
    public required Guid Id { get; init; }
    public required string Name { get; init; }
    public required string Description { get; init; }
    public required string LanguageCode { get; init; }
};