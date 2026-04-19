namespace Cognilingo.Application.Identity.Commands.Login;

public sealed class LoginCommandHandler(
    IAppDbContext context,
    IPasswordHasher passwordHasher,
    ITokenService tokenService,
    AuthService authService
) : IRequestHandler<LoginCommand, Response<AuthResult>>
{
    public async Task<Response<AuthResult>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await context.Users
            .FirstOrDefaultAsync(u => u.Email == request.Email, cancellationToken);

        if (user is null)
            return new UnauthorizedResponse<AuthResult>(IdentityMessages.UserNotFound);

        var isPasswordMatch = passwordHasher.Verify(
            plainText: request.Password,
            hash: user.PasswordHash
        );

        if (!isPasswordMatch)
            return new UnauthorizedResponse<AuthResult>(IdentityMessages.WrongPassword);

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