namespace Cognilingo.Domain.Simulations.Entities;

public sealed class SituationVariantObjective : BaseEntity, ITranslatable<SituationVariantObjectiveTranslation>
{
    public Guid SituationVariantId { get; private set; }

    private readonly List<SituationVariantObjectiveTranslation> _translations = new();
    public IReadOnlyCollection<SituationVariantObjectiveTranslation> Translations => _translations;
}

public sealed class SituationVariantObjectiveTranslation : TranslationBase
{
    public string Name { get; private set; }
}