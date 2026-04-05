using Cognilingo.Application.Common.Responses.Base;
using MediatR;

namespace Cognilingo.Application.Identity.Commands.Login;

public sealed record LoginCommand(
    string email,
    string password
) : IRequest<Response<LoginResult>>;