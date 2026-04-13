using Cognilingo.Api.Common.Controllers;
using Cognilingo.Application.Identity.Commands.Login;
using Cognilingo.Application.Identity.Commands.RefreshTokens;
using Cognilingo.Application.Identity.Commands.Register;
using Cognilingo.Application.Identity.Queries.GetLoggedUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cognilingo.Api.Identity.Controllers.Authentication;

[Route("api/auth")]
public class AuthController(IMediator _mediator) : BaseController
{
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginCommand command)
        => MapResponse(await _mediator.Send(command));

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterCommand command)
        => MapResponse(await _mediator.Send(command));

    [HttpPost("refresh")]
    public async Task<IActionResult> Refresh(RefreshTokenCommand command)
        => MapResponse(await _mediator.Send(command));

    [Authorize]
    [HttpGet("logged-user")]
    public async Task<IActionResult> GetLoggedUser(GetLoggedUserQuery query)
        => MapResponse(await _mediator.Send(query));
}