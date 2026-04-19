namespace Cognilingo.Domain.Common.Base;

public abstract class TranslationBase : BaseEntity
{
    public Guid EntityId { get; protected set; }
    public string Language { get; protected set; } = null!;
}