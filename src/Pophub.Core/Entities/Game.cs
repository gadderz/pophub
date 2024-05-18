using Pophub.Core.Common;

namespace Pophub.Core.Entities;

public class Game : BaseAuditableEntity<Guid>
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public GameCategory? GameCategory { get; set; }
}
