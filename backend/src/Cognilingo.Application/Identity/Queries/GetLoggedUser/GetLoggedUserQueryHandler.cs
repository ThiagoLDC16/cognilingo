namespace Cognilingo.Application.Identity.Queries.GetLoggedUser;

public sealed class GetLoggedUserQueryHandler(
    IAppDbContext context,
    IRequestContext requestContext
) : IRequestHandler<GetLoggedUserQuery, Response<LoggedUserResult>>
{
    public async Task<Response<LoggedUserResult>> Handle(GetLoggedUserQuery request, CancellationToken cancellationToken)
    {
        if (requestContext.UserId is null)
            return new UnauthorizedResponse<LoggedUserResult>(IdentityMessages.UserNotFound);

        var user = await context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Id == requestContext.UserId, cancellationToken);

        if (user is null)
            return new UnauthorizedResponse<LoggedUserResult>(IdentityMessages.UserNotFound);

        return new OkResponse<LoggedUserResult>(
            new LoggedUserResult(user.Id, user.Name, user.Email)
        );
    }
}
