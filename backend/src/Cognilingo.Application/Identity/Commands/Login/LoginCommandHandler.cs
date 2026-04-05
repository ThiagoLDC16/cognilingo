using Cognilingo.Application.Common.Interfaces.Persistence;
using Cognilingo.Application.Common.Responses;
using Cognilingo.Application.Common.Responses.Base;
using Cognilingo.Application.Identity.Authentication;
using Cognilingo.Application.Identity.Interfaces;
using Cognilingo.Application.Identity.Messages;
using Cognilingo.Domain.Identity.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cognilingo.Application.Identity.Commands.Login;

public sealed class LoginCommandHandler(
    IAppDbContext context,
    IPasswordHasher passwordHasher,
    ITokenService tokenService,
    AuthService authService
) : IRequestHandler<LoginCommand, Response<LoginResult>>
{
    public async Task<Response<LoginResult>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await context.Users
            .FirstOrDefaultAsync(u => u.Email == request.email, cancellationToken);

        if (user is null)
            return new UnauthorizedResponse<LoginResult>(IdentityMessages.UserNotFound);

        var isPasswordMatch = passwordHasher.Verify(
            plainText: request.password,
            hash: user.PasswordHash
        );

        if (!isPasswordMatch)
            return new UnauthorizedResponse<LoginResult>(IdentityMessages.WrongPassword);

        var claims = authService.CreateUserTokenClaims(user);

        var accessToken = tokenService.GenerateAccessToken(claims);

        var refreshToken = new RefreshToken(
            userId: user.Id,
            token: tokenService.GenerateRefreshToken()
        );

        await context.RefreshTokens.AddAsync(refreshToken, cancellationToken);

        await context.SaveChangesAsync(cancellationToken);

        return new OkResponse<LoginResult>(
            data: new LoginResult(
                accessToken: accessToken,
                refreshToken: refreshToken.Token
            )
        );
    }
}