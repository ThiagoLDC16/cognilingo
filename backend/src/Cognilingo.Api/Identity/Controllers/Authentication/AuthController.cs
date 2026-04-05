using Cognilingo.Api.Common.Controllers;
using Cognilingo.Application.Identity.Commands.Login;
using Cognilingo.Application.Identity.Commands.Register;
using MediatR;
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

    // TODO
    // [HttpPost("refresh")]
    // public async Task<IActionResult> Refresh(RefreshTokenCommand command)
    //     => Ok(await _mediator.Send(command));
}