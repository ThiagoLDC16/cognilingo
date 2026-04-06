using Cognilingo.Application.Common.Interfaces.Persistence;
using Cognilingo.Application.Common.Responses;
using Cognilingo.Application.Common.Responses.Base;
using Cognilingo.Application.Identity.Authentication;
using Cognilingo.Application.Identity.Interfaces;
using Cognilingo.Application.Identity.Messages;
using Cognilingo.Application.Identity.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cognilingo.Application.Identity.Commands.RefreshTokens;

public sealed class RefreshTokenCommandHandler(
    IAppDbContext context,
    ITokenService tokenService,
    AuthService authService
) : IRequestHandler<RefreshTokenCommand, Response<AuthResult>>
{
    public async Task<Response<AuthResult>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        var refreshToken = await context.RefreshTokens
            .Include(rt => rt.User)
            .FirstOrDefaultAsync(rt => rt.Token == request.RefreshToken, cancellationToken);

        if (refreshToken is null)
            return new UnauthorizedResponse<AuthResult>(IdentityMessages.InvalidRefreshToken);

        if (refreshToken.IsExpired())
        {
            context.RefreshTokens.Remove(refreshToken);
            await context.SaveChangesAsync(cancellationToken);
            return new UnauthorizedResponse<AuthResult>(IdentityMessages.ExpiredRefreshToken);
        }

        var claims = authService.CreateUserTokenClaims(refreshToken.User);
        var accessToken = tokenService.GenerateAccessToken(claims);

        refreshToken.UpdateToken(
            tokenService.GenerateRefreshToken()
        );

        await context.SaveChangesAsync(cancellationToken);

        return new OkResponse<AuthResult>(
            data: new AuthResult(
                accessToken: accessToken,
                refreshToken: refreshToken.Token
            )
        );
    }
}