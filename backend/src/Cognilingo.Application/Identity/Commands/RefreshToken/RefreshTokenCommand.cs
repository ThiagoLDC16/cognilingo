namespace Cognilingo.Application.Identity.Commands.RefreshTokens;

public sealed record RefreshTokenCommand(
    string RefreshToken
) : IRequest<Response<AuthResult>>;

public sealed class RefreshTokenCommandValidator : AbstractValidator<RefreshTokenCommand>
{
    public RefreshTokenCommandValidator()
    {
        RuleFor(command => command.RefreshToken)
            .NotEmpty();
    }
}
