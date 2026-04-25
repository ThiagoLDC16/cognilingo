namespace Cognilingo.Application.Identity.Results;

public sealed record AuthResult(
    string accessToken,
    string refreshToken
);