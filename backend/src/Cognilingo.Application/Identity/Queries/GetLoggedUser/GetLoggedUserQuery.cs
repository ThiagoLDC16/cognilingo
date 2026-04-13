using Cognilingo.Application.Common.Responses.Base;
using Cognilingo.Application.Identity.Results;
using MediatR;

namespace Cognilingo.Application.Identity.Queries.GetLoggedUser;

public sealed record GetLoggedUserQuery() : IRequest<Response<LoggedUserResult>>;
