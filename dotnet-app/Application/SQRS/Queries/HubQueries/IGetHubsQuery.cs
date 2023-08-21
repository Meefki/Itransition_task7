using Application.SQRS.Queries.HubQueries.DTOs;

namespace Application.SQRS.Queries.HubQueries;

public interface IGetHubsQuery
{
    Task<GetHubsQueryDTO> GetHubs(int pageSize, int pageNumber);
}