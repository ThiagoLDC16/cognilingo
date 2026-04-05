using System.Security.Claims;
using Cognilingo.Application.Common.Interfaces.Persistence;
using Cognilingo.Application.Common.Responses;
using Cognilingo.Application.Common.Responses.Base;
using Cognilingo.Application.Identity.Authentication;
using Cognilingo.Application.Identity.Interfaces;
using Cognilingo.Application.Identity.Messages;
using Cognilingo.Domain.Identity.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cognilingo.Application.Identity.Commands.Register;

public sealed class RegisterCommandHandler(
    IAppDbContext context,
    IPasswordHasher passwordHasher,
    ITokenService tokenService,
    AuthService authService
) : IRequestHandler<RegisterCommand, Response<RegisterResult>>
{
    public async Task<Response<RegisterResult>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var hasUser = await context.Users
            .AnyAsync(u => u.Email == request.email, cancellationToken);

        if (hasUser)
            return new UnprocessableResponse<RegisterResult>(IdentityMessages.EmailAlreadyUsed);

        var user = new User(
            name: request.name,
            email: request.email,
            passwordHash: passwordHasher.Hash(request.password)
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

        return new OkResponse<RegisterResult>(
            data: new RegisterResult(
                accessToken: accessToken,
                refreshToken: refreshToken.Token
            )
        );
    }
}