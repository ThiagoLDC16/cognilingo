namespace Cognilingo.Application.Identity.Queries.GetLoggedUser;

public sealed record LoggedUserResult(
    Guid Id,
    string Name,
    string Email
);
