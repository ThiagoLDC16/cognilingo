namespace Cognilingo.Api.Simulations.Controllers;

[Route("api/simulations")]
[Authorize]
public class SimulationsController(IMediator _mediator) : BaseController
{
    [HttpGet("categories")]
    public async Task<IActionResult> ListCategories([FromQuery] ListCategoriesQuery query)
        => MapResponse(await _mediator.Send(query));

    [HttpGet("categories/{categoryId:guid}/situations")]
    public async Task<IActionResult> ListSituations(Guid categoryId, [FromQuery] string languageCode)
        => MapResponse(await _mediator.Send(new ListSituationsQuery(categoryId, languageCode)));

    [HttpPost]
    public async Task<IActionResult> StartSimulation([FromBody] StartSimulationCommand command)
        => MapResponse(await _mediator.Send(command));

    [HttpPost("{id:guid}/messages")]
    public async Task<IActionResult> SendMessage(Guid id, [FromBody] SendMessagePayload payload)
        => MapResponse(await _mediator.Send(payload.AsCommand(id)));
}