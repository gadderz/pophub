using MediatR;
using Pophub.Application.Common.Repositories;

namespace Pophub.Application.Game.Commands.CreateGame;

public record CreateGameCommand : IRequest
{
    public string Name { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
}

public class CreateGameCommandHandler : IRequestHandler<CreateGameCommand>
{
    private readonly IGameRepository _context;

    // public CreateGameCommandHandler(IGameRepository context)
    // {
    //     _context = context;
    // }

    public async Task Handle(CreateGameCommand request, CancellationToken cancellationToken)
    {
        return;

        var entity = new Core.Entities.Game
        {
            Name = request.Name,
            Description = request.Description,
        };

        await _context.AddAsync(entity);
    }
}
