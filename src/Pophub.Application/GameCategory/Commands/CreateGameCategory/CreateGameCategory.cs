using MediatR;
using Pophub.Application.Common.Repositories;

namespace Pophub.Application.Game.Commands.CreateGameCategory;

public record CreateGameCategoryCommand : IRequest
{
    public string Name { get; init; } = string.Empty;
}

public class CreateGameCategoryCommandHandler : IRequestHandler<CreateGameCategoryCommand>
{
    private readonly IGameCategoryRepository _context;

    public CreateGameCategoryCommandHandler(IGameCategoryRepository context)
    {
        _context = context;
    }

    public async Task Handle(CreateGameCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = new Core.Entities.GameCategory { Name = request.Name, };

        await _context.AddAsync(entity);
    }
}
