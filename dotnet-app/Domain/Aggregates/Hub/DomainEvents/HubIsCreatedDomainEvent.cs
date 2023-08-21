using Domain.SeedWork.DomainEvents;

namespace Domain.Aggregates.Hub.DomainEvents;

public sealed record HubIsCreatedDomainEvent(HubId Id, Game Game) : IDomainEvent;
