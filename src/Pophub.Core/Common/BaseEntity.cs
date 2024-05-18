namespace Pophub.Core.Common;

public abstract class BaseEntity<TId>
    where TId : struct, IEquatable<TId>
{
    public TId Id { get; set; }
}
