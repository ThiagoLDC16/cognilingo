namespace Cognilingo.Application.Identity.Commands.Register;

public sealed record RegisterResult(
    string accessToken,
    string refreshToken
);