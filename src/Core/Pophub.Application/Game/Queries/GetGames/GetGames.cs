using AutoMapper;
using MediatR;
using Pophub.Application.Game.Models;
using Pophub.Domain.Repositories;

namespace Pophub.Application.Game.Queries.GetGames;

public record GetGamesQuery : IRequest<IEnumerable<GameDto>> { }

public class GetGamesQueryHandler : IRequestHandler<GetGamesQuery, IEnumerable<GameDto>>
{
    private readonly IGameRepository _gameRepository;
    private readonly IMapper _mapper;

    public GetGamesQueryHandler(IGameRepository gameRepository, IMapper mapper)
    {
        _gameRepository = gameRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GameDto>> Handle(
        GetGamesQuery request,
        CancellationToken cancellationToken
    )
    {
        var games = await _gameRepository.ListAllAsync();

        var response = _mapper.Map<IEnumerable<GameDto>>(games);
        return response;
    }
}
