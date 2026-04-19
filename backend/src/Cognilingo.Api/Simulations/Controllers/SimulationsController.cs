using Cognilingo.Application.Simulations.Queries.ListCategories;

namespace Cognilingo.Api.Simulations.Controllers;

[Route("api/simulations")]
public class SimulationsController(IMediator _mediator) : BaseController
{
    [HttpGet("categories")]
    public async Task<IActionResult> ListCategories([FromQuery] ListCategoriesQuery query)
        => MapResponse(await _mediator.Send(query));
}