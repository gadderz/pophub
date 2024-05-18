using Pophub.Core.Common;

namespace Pophub.Core.Entities;

public class GameCategory : BaseAuditableEntity<int>
{
    public required string Name { get; set; }
}
