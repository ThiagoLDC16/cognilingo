namespace Cognilingo.Application.Simulations.Queries.ListCategories;

public sealed record ListCategoryDto
{
    public required Guid Id { get; init; }
    public required string? ImageUrl { get; init; }
    public required string Name { get; init; }
    public required string LanguageCode { get; init; }
};