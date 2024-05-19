using AutoMapper;

namespace Pophub.Application.Game.Models;

public record GameDto
{
    public Guid Id { get; init; }
    public string? Name { get; init; }
    public string? Description { get; init; }
    public DateTime ReleaseDate { get; init; }
}

public class GameMappingProfile : Profile
{
    public GameMappingProfile()
    {
        CreateMap<Core.Entities.Game, GameDto>();
    }
}
