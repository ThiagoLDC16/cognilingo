namespace Cognilingo.Domain.Simulations.Entities;

public sealed class SituationVariant : BaseEntity, ITranslatable<SituationVariantTranslation>
{
    public Guid SituationId { get; private set; }
    public string LearningLanguage { get; private set; }
    public string PromptInstructions { get; private set; }
    public string InitialMessage { get; private set; }

    private readonly List<SituationVariantTranslation> _translations = new();
    public IReadOnlyCollection<SituationVariantTranslation> Translations => _translations;
}

public sealed class SituationVariantTranslation : TranslationBase
{
    public string Name { get; private set; }
    public string UserContext { get; private set; }
}