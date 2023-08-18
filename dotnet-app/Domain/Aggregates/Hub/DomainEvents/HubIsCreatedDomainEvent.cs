using Domain.SeedWork.DomainEvents;
using Domain.Shared;

namespace Domain.Aggregates.Hub.DomainEvents;

public record HubIsCreatedDomainEvent(HubId Id, Game Game) : IDomainEvent;
