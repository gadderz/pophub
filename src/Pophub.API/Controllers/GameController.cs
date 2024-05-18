using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pophub.Application.Game.Commands.CreateGame;

namespace Pophub.API.Controllers;

[ApiController]
[Route("game")]
public class GameController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<GameController> _logger;

    public GameController(ILogger<GameController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> GetAsync(CreateGameCommand command)
    {
        await _mediator.Send(command);

        return Ok();
    }
}
