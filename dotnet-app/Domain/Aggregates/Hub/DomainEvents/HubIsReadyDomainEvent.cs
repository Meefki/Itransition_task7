using Domain.SeedWork.DomainEvents;
using System.Collections.ObjectModel;

namespace Domain.Aggregates.Hub.DomainEvents;

public sealed record HubIsReadyDomainEvent(HubId Id, IReadOnlyCollection<Player> Players) : IDomainEvent;
