using Cognilingo.Application.Common.Interfaces.Persistence;
using Cognilingo.Application.Common.Responses;
using Cognilingo.Application.Common.Responses.Base;
using Cognilingo.Application.Identity.Authentication;
using Cognilingo.Application.Identity.Interfaces;
using Cognilingo.Application.Identity.Messages;
using Cognilingo.Application.Identity.Results;
using Cognilingo.Domain.Identity.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

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