using Domain.SeedWork.DomainEvents;

namespace Domain.Aggregates.Hub.DomainEvents;

public sealed record HubIsEmptyDomainEvent(HubId Id) : IDomainEvent;
