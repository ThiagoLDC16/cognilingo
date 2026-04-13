using System.Security.Claims;
using Cognilingo.Application.Identity.Authentication;
using Cognilingo.Application.Identity.Interfaces.Context;
using Microsoft.AspNetCore.Http;

namespace Cognilingo.Infrastructure.Identity.Context;

public class RequestContext(IHttpContextAccessor httpContextAccessor) : IRequestContext
{
    public Guid? UserId =>
        Guid.Parse(httpContextAccessor.HttpContext?.User?.FindFirstValue(AppClaimTypes.UserId) ?? string.Empty);
}