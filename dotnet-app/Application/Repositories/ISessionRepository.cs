using Domain.Aggregates.Session;

namespace Application.Repositories;

public interface ISessionRepository
{
    Task<Session> GetBy(SessionId id);

    Task<Session> Create(Session session);
    Task Update(Session session);
    Task Delete(Session session);
    Task Delete(SessionId id);
}
