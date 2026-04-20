namespace Cognilingo.Domain.Simulations.Entities;

public sealed class Simulation : AggregateRoot
{
    public Guid UserId { get; private set; }
    public Guid SituationId { get; private set; }
    public Guid VariantId { get; private set; }
    public SimulationStatus Status { get; private set; }
    public DateTime? CompletedAt { get; private set; }

    private readonly List<SimulationMessage> _messages = new();
    public IReadOnlyCollection<SimulationMessage> Messages => _messages;
    
    private readonly List<SimulationCompletedObjective> _completedObjectives = new();
    public IReadOnlyCollection<SimulationCompletedObjective> CompletedObjectives => _completedObjectives;
}