using Domain.Aggregates.Hub.DomainEvents;
using Domain.Aggregates.Hub.DomainExceptions;
using Domain.SeedWork;
using Domain.Shared;
using System.Collections.ObjectModel;

namespace Domain.Aggregates.Hub;

public sealed class Hub 
    : Entity<Guid>, IAggregateRoot
{
    public Hub(IGameFactory gameFactory, GameTypes gameType, Player hubLeader)
        : base(HubId.Create(Guid.NewGuid()))
    {
        players = new HashSet<Player>();
        AddPlayer(hubLeader);
        Game = gameFactory.Create(gameType);

        AddHubIsCreatedDomainEvent(id, Game);
    }

    private HubId id = null!;
    public override EntityIdentifier<Guid> Id
    {
        get => id;
        init => id = (HubId)value;
    }

    public Game Game { get; private set; }

    private readonly ISet<Player> players;
    public IReadOnlyCollection<Player> Players => new ReadOnlyCollection<Player>(players.ToList());

    public void ChangeLeader(Player player)
    {
        RemovePlayer(player);
        
    }

    public void ChangeGame(Game game)
    {
        if (game.PlayersCount < players.Count)
            MorePlayersThanNeededDomainException.Throw();

        Game = game;

        AddGameChangedDomainEvent(id, game.GameType);

        if (game.PlayersCount == players.Count)
            AddHubIsReadyDomainEvent(id, players);
    }

    public void AddPlayer(Player player)
    {
        if (Game.PlayersCount <= players.Count)
            MorePlayersThanNeededDomainException.Throw();

        player = players.Any(x => x.IsLeader) ?
            player.IsLeader ? new((PlayerId)player.Id, player.Name) : player :
            player.IsLeader ? player : new((PlayerId)player.Id, player.Name, true);

        players.Add(player);

        if (players.Count == Game.PlayersCount)
            AddHubIsReadyDomainEvent(id, players);
    }

    public void RemovePlayer(Player player)
    {
        if (!players.Contains(player))
            PlayerIsNotInHubDomainException.Throw(id, player);

        players.Remove(player);

        if (players.Count <= 0)
        {
            AddHubIsEmptyDomainEvent(id);
            return;
        }
            
        if(!players.Any(x => x.IsLeader))
        {
            Player newLeader = players.First(); 
            newLeader.ChangeLeadership(true);
            AddHubLeaderChangedDomainEvent(id, newLeader);
        }
    }

    #region Add Domain Events

    private void AddHubIsReadyDomainEvent(HubId id, IEnumerable<Player> players)
    {
        HubIsReadyDomainEvent domainEvent = new(id, players.ToList());
        AddDomainEvent(domainEvent);
    }

    private void AddHubIsEmptyDomainEvent(HubId id)
    {
        HubIsEmptyDomainEvent domainEvent = new(id);
        AddDomainEvent(domainEvent);
    }

    private void AddGameChangedDomainEvent(HubId id, GameTypes gameType)
    {
        GameChangedDomainEvent domainEvent = new(id, gameType);
        AddDomainEvent(domainEvent);
    }

    private void AddHubIsCreatedDomainEvent(HubId id, Game game)
    {
        HubIsCreatedDomainEvent domainEvent = new(id, game);
        AddDomainEvent(domainEvent);
    }

    private void AddHubLeaderChangedDomainEvent(HubId id, Player newLeader)
    {
        HubLeaderChangedDomainEvent domainEvent = new(id, newLeader);
        AddDomainEvent(domainEvent);
    }

    #endregion
}
