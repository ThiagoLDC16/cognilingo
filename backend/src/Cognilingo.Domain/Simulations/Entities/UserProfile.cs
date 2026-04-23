namespace Cognilingo.Domain.Simulations.Entities;

public sealed class UserProfile : BaseEntity
{
    public Guid UserId { get; private set; }
    public string NativeLanguage { get; private set; }
    public string LearningLanguage { get; private set; }
    public Guid? NextRecommendedSimulation { get; private set; }
}