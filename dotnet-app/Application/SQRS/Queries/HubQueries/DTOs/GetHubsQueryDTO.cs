namespace Application.SQRS.Queries.HubQueries.DTOs;

public record GetHubsQueryDTO(string HubId, string GameName, int Players, bool Status);
