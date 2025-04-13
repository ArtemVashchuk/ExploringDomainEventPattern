namespace Gatherly.Domain.Primitives;

public class AggregateRoot(Guid id) : Entity(id)
{
    private static readonly List<IDomainEvent> _domainEvents = new();

    public static void RaiseDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
}