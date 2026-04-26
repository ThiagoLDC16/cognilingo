namespace Cognilingo.Application.Simulations.Queries.ListSimulationMessages;

public sealed record ListSimulationMessagesQuery(
    Guid SimulationId
) : IRequest<Response<IEnumerable<ListSimulationMessageDto>>>;