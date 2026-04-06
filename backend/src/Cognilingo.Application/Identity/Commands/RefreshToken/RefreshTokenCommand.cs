using Cognilingo.Application.Common.Responses.Base;
using Cognilingo.Application.Identity.Results;
using FluentValidation;
using MediatR;

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
