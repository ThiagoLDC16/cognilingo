namespace Cognilingo.Domain.Simulations.Entities;

public sealed class SituationVariant : BaseEntity, ITranslatable<SituationVariantTranslation>
{
    public Guid SituationId { get; private set; }
    public string Context { get; private set; }

    private readonly List<SituationVariantTranslation> _translations = new();
    public IReadOnlyCollection<SituationVariantTranslation> Translations => _translations;
}

public sealed class SituationVariantTranslation : TranslationBase
{
    public string Name { get; private set; }
    public string Description { get; private set; }
}