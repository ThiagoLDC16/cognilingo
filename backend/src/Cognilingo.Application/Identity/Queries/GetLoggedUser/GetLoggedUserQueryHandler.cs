namespace Cognilingo.Application.Identity.Queries.GetLoggedUser;

public sealed class GetLoggedUserQueryHandler(
    IAppDbContext context,
    IRequestContext requestContext
) : IRequestHandler<GetLoggedUserQuery, Response<GetLoggedUserDto>>
{
    public async Task<Response<GetLoggedUserDto>> Handle(
        GetLoggedUserQuery request,
        CancellationToken cancellationToken
    )
    {
        if (requestContext.UserId is null)
            return new UnauthorizedResponse<GetLoggedUserDto>(IdentityMessages.UserNotFound);

        var userId = requestContext.UserId.Value;

        var hasProfile = await context.UserProfiles
            .AsNoTracking()
            .AnyAsync(p => p.UserId == userId, cancellationToken);

        var user = await context.Users
            .AsNoTracking()
            .Select(u => new GetLoggedUserDto
            {
                Id = u.Id,
                Name = u.Name,
                Email = u.Email,
                HasProfile = hasProfile
            })
            .FirstOrDefaultAsync(u => u.Id == userId, cancellationToken);

        if (user is null)
            return new UnauthorizedResponse<GetLoggedUserDto>(IdentityMessages.UserNotFound);

        return new OkResponse<GetLoggedUserDto>(user);
    }
}