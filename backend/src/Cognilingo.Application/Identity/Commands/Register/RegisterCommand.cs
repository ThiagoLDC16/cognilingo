using Cognilingo.Application.Common.Responses.Base;
using MediatR;

namespace Cognilingo.Application.Identity.Commands.Register;

public sealed record RegisterCommand(
    string name,
    string email,
    string password
) : IRequest<Response<RegisterResult>>;