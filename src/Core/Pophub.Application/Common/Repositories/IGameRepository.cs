using Pophub.Application.Common.Interfaces;

namespace Pophub.Application.Common.Repositories;

public interface IGameRepository : IBaseRepository<Domain.Entities.Game, Guid> { }
