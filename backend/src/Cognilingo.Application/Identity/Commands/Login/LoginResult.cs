namespace Cognilingo.Application.Identity.Commands.Login;

public sealed record LoginResult(
    string accessToken,
    string refreshToken
);