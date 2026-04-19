namespace Cognilingo.Application.Identity.Commands.Register;

public sealed class RegisterCommandHandler(
    IAppDbContext context,
    IPasswordHasher passwordHasher,
    ITokenService tokenService,
    AuthService authService
) : IRequestHandler<RegisterCommand, Response<AuthResult>>
{
    public async Task<Response<AuthResult>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var hasUser = await context.Users
            .AnyAsync(u => u.Email == request.Email, cancellationToken);

        if (hasUser)
            return new UnprocessableResponse<AuthResult>(IdentityMessages.EmailAlreadyUsed);

        var user = new User(
            name: request.Name,
            email: request.Email,
            passwordHash: passwordHasher.Hash(request.Password)
        );

        await context.Users.AddAsync(user, cancellationToken);

        var claims = authService.CreateUserTokenClaims(user);

        var accessToken = tokenService.GenerateAccessToken(claims);

        var refreshToken = new RefreshToken(
            userId: user.Id,
            token: tokenService.GenerateRefreshToken()
        );

        await context.RefreshTokens.AddAsync(refreshToken, cancellationToken);

        await context.SaveChangesAsync(cancellationToken);

        return new OkResponse<AuthResult>(
            data: new AuthResult(
                accessToken: accessToken,
                refreshToken: refreshToken.Token
            )
        );
    }
}