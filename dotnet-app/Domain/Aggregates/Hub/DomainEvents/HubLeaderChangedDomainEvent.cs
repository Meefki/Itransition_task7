using Domain.SeedWork.DomainEvents;

namespace Domain.Aggregates.Hub.DomainEvents;

public record HubLeaderChangedDomainEvent(HubId Id, Player NewLeader) : IDomainEvent;
