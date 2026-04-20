namespace Cognilingo.Domain.Simulations.Entities;

public sealed class Situation : BaseEntity, ITranslatable<SituationTranslation>
{
    public Guid CategoryId { get; private set; }

    private readonly List<SituationTranslation> _translations = new();
    public IReadOnlyCollection<SituationTranslation> Translations => _translations;
}

public sealed class SituationTranslation : TranslationBase
{
    public string Name { get; private set; }
    public string Description { get; private set; }
}