using Domain.SeedWork.DomainEvents;

namespace Domain.Aggregates.Hub.DomainEvents;

public record HubIsEmptyDomainEvent(HubId Id) : IDomainEvent;
