using Pophub.Domain.Common;

namespace Pophub.Domain.Entities;

public class GameCategory : BaseAuditableEntity<int>
{
    public required string Name { get; set; }
    public IList<Game> Games { get; set; } = [];
}
