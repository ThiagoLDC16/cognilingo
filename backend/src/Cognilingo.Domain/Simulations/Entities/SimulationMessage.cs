namespace Cognilingo.Domain.Simulations.Entities;

public sealed class SimulationMessage : BaseEntity
{
    public Guid SimulationId { get; private set; }
    public MessageSender Sender { get; private set; }
    public string Content { get; private set; }
    public string TranslatedContent { get; private set; }
    
    public SimulationMessageFeedback? Feedback { get; private set; }
}