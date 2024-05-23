using MediatR;
using Pophub.Application.Common.Repositories;

namespace Pophub.Application.Game.Commands.UpdateGame;

public record UpdateGameCommand : IRequest
{
    public Guid Id { get; init; }
    public string? Name { get; init; }
    public string? Description { get; init; }
}

public class UpdateGameCommandHandler : IRequestHandler<UpdateGameCommand>
{
    private readonly IGameRepository _context;

    public UpdateGameCommandHandler(IGameRepository context)
    {
        _context = context;
    }

    public async Task Handle(UpdateGameCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.GetByIdAsync(request.Id);

        if (entity == null)
        {
            throw new Exception("Entity not found");
        }

        entity.Name = request.Name!;
        entity.Description = request.Description!;

        await _context.UpdateAsync(entity);
    }
}
