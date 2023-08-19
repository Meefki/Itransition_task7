using Domain.Aggregates.Hub;

namespace Application.Repositories;

public interface IHubRepository
{
    Task<Hub> GetBy(HubId id);
    Task<IEnumerable<Hub>> Get(int pageSize, int pazeNumber);
    Task<int> GetCount();

    Task<Hub> Create(Hub hub);
    Task Update(Hub hub);
    Task Delete(Hub hub);
    Task Delete(HubId id);
}
