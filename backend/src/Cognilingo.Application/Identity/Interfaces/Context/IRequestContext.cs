namespace Cognilingo.Application.Identity.Interfaces.Context;

public interface IRequestContext
{
    Guid? UserId { get; }
}
