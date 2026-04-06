using Cognilingo.Application.Common.Responses.Base;
using FluentValidation;
using MediatR;

namespace Cognilingo.Application.Identity.Commands.Login;

public sealed record LoginCommand(
    string Email,
    string Password
) : IRequest<Response<LoginResult>>;

public sealed class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(command => command.Email)
            .EmailAddress()
            .MaximumLength(255);

        RuleFor(command => command.Password)
            .NotEmpty();
    }
}