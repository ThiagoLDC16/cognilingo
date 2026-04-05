using Cognilingo.Domain.Common;

namespace Cognilingo.Domain.Identity.Entities;

public sealed class RefreshToken : BaseEntity
{
    public const int DaysToExpire = 30;

    public Guid UserId { get; private set; }
    public string Token { get; private set; }
    public DateTime ExpiresAt { get; private set; }

    public RefreshToken(Guid userId, string token)
    {
        UserId = userId;
        Token = token;
        ExpiresAt = DateTime.UtcNow.AddDays(DaysToExpire);
    }
}