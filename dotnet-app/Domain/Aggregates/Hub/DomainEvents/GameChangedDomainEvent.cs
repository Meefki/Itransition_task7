using Domain.SeedWork.DomainEvents;
using Domain.Shared;

namespace Domain.Aggregates.Hub.DomainEvents;

public record GameChangedDomainEvent(HubId Id, GameTypes GameType) : IDomainEvent;
