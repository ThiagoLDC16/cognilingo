namespace Cognilingo.Domain.Simulations.Entities;

public sealed class Situation : BaseEntity, ITranslatable<SituationTranslation>
{
    public Guid CategoryId;
    
    private readonly List<SituationTranslation> _translations = new();
    public IReadOnlyCollection<SituationTranslation> Translations => _translations.AsReadOnly();
}

public sealed class SituationTranslation : TranslationBase
{
    public string Name;
    public string Description;
}