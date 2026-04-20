namespace Cognilingo.Domain.Simulations.ValueObjects;

public sealed class SimulationMessageFeedback
{
    public MessageFeedbackClassification Classification { get; private set; }
    public string Explanation { get; private set; }
    public string Correction { get; private set; }
}