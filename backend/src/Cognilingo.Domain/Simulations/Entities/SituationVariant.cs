namespace Cognilingo.Domain.Simulations.Entities;

public sealed class SituationVariant : BaseEntity, ITranslatable<SituationVariantTranslation>
{
    public Guid SituationId;
    public string Context;
    
    private readonly List<SituationVariantTranslation> _translations = new();
    public IReadOnlyCollection<SituationVariantTranslation> Translations => _translations.AsReadOnly();
}

public sealed class SituationVariantTranslation : TranslationBase
{
    public string Name;
    public string Description;
}