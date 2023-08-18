using Domain.SeedWork.DomainEvents;

namespace Domain.SeedWork;

public interface IEntity
{
    public IReadOnlyCollection<IDomainEvent> DomainEvents { get; }
    public void ClearDomainEvents();
}
