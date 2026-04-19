namespace Cognilingo.Application.Identity.Queries.GetLoggedUser;

public sealed record GetLoggedUserQuery() : IRequest<Response<LoggedUserResult>>;
