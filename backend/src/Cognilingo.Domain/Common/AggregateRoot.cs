using System.ComponentModel.DataAnnotations.Schema;

namespace Cognilingo.Domain.Common;

public abstract class AggregateRoot : BaseEntity
{
    private readonly List<BaseDomainEvent> _domainEvents = new();

    [NotMapped] public IReadOnlyCollection<BaseDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    public void AddDomainEvent(BaseDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    public void RemoveDomainEvent(BaseDomainEvent domainEvent)
    {
        _domainEvents.Remove(domainEvent);
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }
}