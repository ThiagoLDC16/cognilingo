namespace Cognilingo.Domain.Simulations.Entities;

public sealed class Category : BaseEntity, ITranslatable<CategoryTranslation>
{
    public string? ImageUrl { get; private set; }
    
    private readonly List<CategoryTranslation> _translations = new();
    public IReadOnlyCollection<CategoryTranslation> Translations => _translations;
}

public sealed class CategoryTranslation : TranslationBase
{
    public string Name;
} 