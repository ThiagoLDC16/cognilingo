namespace Cognilingo.Domain.Simulations.Entities;

public sealed class Category : BaseEntity, ITranslatable<CategoryTranslation>
{
    public string? ImageUrl;
    
    private readonly List<CategoryTranslation> _translations = new();
    public IReadOnlyCollection<CategoryTranslation> Translations => _translations.AsReadOnly();
}

public sealed class CategoryTranslation : TranslationBase
{
    public string Name;
} 