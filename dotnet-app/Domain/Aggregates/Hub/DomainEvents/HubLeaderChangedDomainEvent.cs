using Domain.SeedWork.DomainEvents;

namespace Domain.Aggregates.Hub.DomainEvents;

public sealed record HubLeaderChangedDomainEvent(HubId Id, Player NewLeader) : IDomainEvent;
