namespace Cognilingo.Domain.Simulations.ValueObjects;

public sealed record SimulationCompletedObjective
{
    public Guid SimulationId { get; private set; }
    public Guid ObjectiveId { get; private set; }
    public DateTime? CompletedAt { get; private set; }
}