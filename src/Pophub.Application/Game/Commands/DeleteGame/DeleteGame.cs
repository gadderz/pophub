using MediatR;
using Pophub.Application.Common.Repositories;

namespace Pophub.Application.Game.Commands.DeleteGame;

public record DeleteGameCommand : IRequest
{
    public Guid Id { get; init; }
}

public class DeleteGameCommandHandler : IRequestHandler<DeleteGameCommand>
{
    private readonly IGameRepository _context;

    public DeleteGameCommandHandler(IGameRepository context)
    {
        _context = context;
    }

    public async Task Handle(DeleteGameCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.GetByIdAsync(request.Id);

        if (entity == null)
        {
            throw new Exception("Entity not found");
        }

        await _context.DeleteAsync(entity);
    }
}
